using System.Collections.Generic;
using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ToListTests
    {
        public static IEnumerable<object[]> ValidIntCases()
        {
            yield return O(RL());
            yield return O(RL(42), 42);
            yield return O(RL(42, 43), 42, 43);
            yield return O(RL(42, 43, 44), 42, 43, 44);
            // the following are kind of testing `ToInt()` behaviour, too
            yield return O(RL(RL(42)), 42);
            yield return O(RL(RL(42), RL(43)), 42, 43);
            yield return O(RL(RL(42), RL(43), RL(44)), 42, 43, 44);
            yield return O(RL(42, RL(43)), 42, 43);
            yield return O(RL(RL(42), 43), 42, 43);
        }

        [DynamicData(nameof(ValidIntCases), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void ValidInt(ReaderValue value, params int[] values)
        {
            var expected = new List<int>(values);
            var actual = ConvertSuccess(value, List(Int()));
            CollectionAssert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> ValidStringCases()
        {
            yield return O(RL());
            yield return O(RL("foo"), "foo");
            yield return O(RL("foo", "bar"), "foo", "bar");
            yield return O(RL("foo", "bar", "baz"), "foo", "bar", "baz");
            // the following are kind of testing `ToString()` behaviour, too
            yield return O(RL(RL("foo")), "foo");
            yield return O(RL(RL("foo"), RL("bar")), "foo", "bar");
            yield return O(RL(RL("foo"), RL("bar"), RL("baz")), "foo", "bar", "baz");
            yield return O(RL("foo", RL("bar")), "foo", "bar");
            yield return O(RL(RL("foo"), "bar"), "foo", "bar");
        }

        [DynamicData(nameof(ValidStringCases), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void ValidString(ReaderValue value, params string[] values)
        {
            var expected = new List<string>(values);
            var actual = ConvertSuccess(value, List(String()));
            CollectionAssert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> InvalidCases()
        {
            yield return O(RI(42));
            yield return O(RF(42f));
            yield return O(RS("foo"));
        }

        [DynamicData(nameof(InvalidCases), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void InvalidOuter(ReaderValue value)
        {
            var message = ConvertFailure(value, List(Int()));
            StringAssert.Contains(message, ". Path '/path'.");
        }

        [TestMethod]
        public void InvalidInnerHasPath()
        {
            var value = RL(42, "invalid");
            var message = ConvertFailure(value, List(Int()));
            StringAssert.Contains(message, ". Path '/path/1'.");
        }
    }
}
