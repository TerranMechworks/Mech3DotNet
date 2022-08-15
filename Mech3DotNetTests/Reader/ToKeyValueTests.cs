using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ToKeyValueTests
    {
        public static IEnumerable<object[]> ValidCases()
        {
            yield return new object[] { @"[]" };
            yield return new object[] { @"[""foo"", 42]", ("foo", 42) };
            yield return new object[] { @"[""foo"", 42, ""bar"", 43]", ("foo", 42), ("bar", 43) };
            yield return new object[] { @"[""foo"", 42, ""foo"", 43]", ("foo", 42), ("foo", 43) };
            // the following are kind of testing `ToString()`/`ToInt()` behaviour, too
            yield return new object[] { @"[[""foo""], 42]", ("foo", 42) };
            yield return new object[] { @"[""foo"", [42]]", ("foo", 42) };
        }

        [DynamicData(nameof(ValidCases), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void Valid(string json, params (string key, int value)[] values)
        {
            var expected = new List<(string key, int value)>(values);
            var actual = ConvertSuccess(json, KeyValue(Int()));
            CollectionAssert.AreEqual(expected, actual);
        }

        [DataRow(@"null")] // direct null
        [DataRow(@"42")] // direct int
        [DataRow(@"42.1")] // direct float
        [DataRow(@"""foo""")] // direct string
        [DataRow(@"true")] // direct bool
        [DataRow(@"false")] // direct bool
        [DataRow(@"{}")]
        [DataRow(@"[""foo""]")] // uneven
        [DataRow(@"[""foo"", 42, ""bar""]")] // uneven
        [DataTestMethod]
        public void InvalidOuter(string json)
        {
            var message = ConvertFailure(json, KeyValue(Int()));
            StringAssert.Contains(message, ". Path '/path'.");
        }

        [TestMethod]
        public void InvalidKeyHasPath()
        {
            var json = @"[[], 42]";
            var message = ConvertFailure(json, KeyValue(Int()));
            StringAssert.Contains(message, ". Path '/path/0'.");
        }

        [TestMethod]
        public void InvalidValueHasPath()
        {
            var json = @"[""foo"", []]";
            var message = ConvertFailure(json, KeyValue(Int()));
            StringAssert.Contains(message, ". Path '/path/1'.");
        }
    }
}
