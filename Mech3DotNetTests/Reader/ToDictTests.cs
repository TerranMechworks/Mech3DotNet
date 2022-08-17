using System.Collections.Generic;
using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ToDictTests
    {
        public static IEnumerable<object[]> ValidCases()
        {
            yield return O(RL());
            yield return O(RL("foo", 42), ("foo", 42));
            yield return O(RL("foo", 42, "bar", 43), ("foo", 42), ("bar", 43));
            // the following are kind of testing `ToString()`/`ToInt()` behaviour, too
            yield return O(RL(RL("foo"), 42), ("foo", 42));
            yield return O(RL("foo", RL(42)), ("foo", 42));
        }

        [DynamicData(nameof(ValidCases), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void Valid(ReaderValue value, params (string key, int value)[] values)
        {
            var expected = new Dictionary<string, int>(values.Length);
            foreach (var kv in values)
                expected.Add(kv.key, kv.value);
            var actual = ConvertSuccess(value, Dict(Int()));
            CollectionAssert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> InvalidCases()
        {
            yield return O(RI(42)); // direct int
            yield return O(RF(42f)); // direct float
            yield return O(RS("foo")); // direct string
            yield return O(RL("foo")); // uneven
            yield return O(RL("foo", 42, "bar")); // uneven
            yield return O(RL("foo", 42, "foo", 43)); // duplicate key
        }

        [DynamicData(nameof(InvalidCases), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void Invalid(ReaderValue value)
        {
            var message = ConvertFailure(value, Dict(Int()));
            StringAssert.Contains(message, ". Path '/path'.");
        }

        [TestMethod]
        public void InvalidKeyHasPath()
        {
            var value = RL(RL(), 42);
            var message = ConvertFailure(value, Dict(Int()));
            StringAssert.Contains(message, ". Path '/path/0'.");
        }

        [TestMethod]
        public void InvalidValueHasPath()
        {
            var value = RL("foo", RL());
            var message = ConvertFailure(value, Dict(Int()));
            StringAssert.Contains(message, ". Path '/path/1'.");
        }
    }
}
