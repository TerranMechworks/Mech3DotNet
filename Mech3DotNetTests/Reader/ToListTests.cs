using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ToListTests
    {
        [DataRow(@"[]")]
        [DataRow(@"[42]", 42)]
        [DataRow(@"[42,43]", 42, 43)]
        [DataRow(@"[42,43,44]", 42, 43, 44)]
        // the following are kind of testing `ToInt()` behaviour, too
        [DataRow(@"[[42]]", 42)]
        [DataRow(@"[[42],[43]]", 42, 43)]
        [DataRow(@"[[42],[43],[44]]", 42, 43, 44)]
        [DataRow(@"[42,[43]]", 42, 43)]
        [DataRow(@"[[42],43]", 42, 43)]
        [DataTestMethod]
        public void ValidInt(string json, params int[] values)
        {
            var expected = new List<int>(values);
            var actual = ConvertSuccess(json, List(Int()));
            CollectionAssert.AreEqual(expected, actual);
        }

        [DataRow(@"[]")]
        [DataRow(@"[""foo""]", "foo")]
        [DataRow(@"[""foo"",""bar""]", "foo", "bar")]
        [DataRow(@"[""foo"",""bar"",""baz""]", "foo", "bar", "baz")]
        // the following are kind of testing `ToString()` behaviour, too
        [DataRow(@"[[""foo""]]", "foo")]
        [DataRow(@"[[""foo""],[""bar""]]", "foo", "bar")]
        [DataRow(@"[[""foo""],[""bar""],[""baz""]]", "foo", "bar", "baz")]
        [DataRow(@"[""foo"",[""bar""]]", "foo", "bar")]
        [DataRow(@"[[""foo""],""bar""]", "foo", "bar")]
        [DataTestMethod]
        public void ValidString(string json, params string[] values)
        {
            var expected = new List<string>(values);
            var actual = ConvertSuccess(json, List(String()));
            CollectionAssert.AreEqual(expected, actual);
        }

        [DataRow(@"null")] // direct null
        [DataRow(@"42")] // direct int
        [DataRow(@"42.1")] // direct float
        [DataRow(@"""foo""")] // direct string
        [DataRow(@"true")] // direct bool
        [DataRow(@"false")] // direct bool
        [DataRow(@"{}")]
        [DataTestMethod]
        public void InvalidOuter(string json)
        {
            var message = ConvertFailure(json, List(Int()));
            StringAssert.Contains(message, ". Path '/path'.");
        }

        [TestMethod]
        public void InvalidInnerHasPath()
        {
            var json = @"[42,null]";
            var message = ConvertFailure(json, List(Int()));
            StringAssert.Contains(message, ". Path '/path/1'.");
        }
    }
}
