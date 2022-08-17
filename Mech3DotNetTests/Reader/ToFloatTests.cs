using System.Collections.Generic;
using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ToFloatTests
    {
        [TestMethod]
        public void Valid()
        {
            var actual = ConvertSuccess(RF(42.1f), Float());
            Assert.AreEqual(42.1, actual, 0.0001);
            actual = ConvertSuccess(RL(42.1f), Float());
            Assert.AreEqual(42.1, actual, 0.0001);
        }

        public static IEnumerable<object[]> InvalidCases()
        {
            yield return O(RI(42));
            yield return O(RS("foo"));
            yield return O(RL());
            yield return O(RL(42));
            yield return O(RL("foo"));
            yield return O(RL(42f, 43f));
            yield return O(RL(RL()));
        }

        [DynamicData(nameof(InvalidCases), DynamicDataSourceType.Method)]
        public void Invalid(ReaderValue value)
        {
            var message = ConvertFailure(value, Float());
            StringAssert.Contains(message, ". Path '/path'.");
        }
    }
}
