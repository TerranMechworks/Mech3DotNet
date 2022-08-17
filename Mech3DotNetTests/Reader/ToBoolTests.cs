using System.Collections.Generic;
using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ToBoolTests
    {
        public static IEnumerable<object[]> ValidCases()
        {
            yield return O(RS("true"), true);
            yield return O(RL("true"), true);
            yield return O(RS("false"), false);
            yield return O(RL("false"), false);
        }

        [DynamicData(nameof(ValidCases), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void Valid(ReaderValue value, bool expected)
        {
            var actual = ConvertSuccess(value, Bool());
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> InvalidCases()
        {
            yield return O(RI(42));
            yield return O(RF(42f));
            yield return O(RS("foo"));
            yield return O(RL());
            yield return O(RL(42));
            yield return O(RL(42f));
            yield return O(RL("foo"));
            yield return O(RL("true", "false"));
            yield return O(RL(RL()));
        }

        [DynamicData(nameof(InvalidCases), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void Invalid(ReaderValue value)
        {
            var message = ConvertFailure(value, Bool());
            StringAssert.Contains(message, ". Path '/path'.");
        }
    }
}
