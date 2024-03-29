using System.Collections.Generic;
using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ToIntTests
    {
        [TestMethod]
        public void Valid()
        {
            var actual = ConvertSuccess(RI(42), Int());
            Assert.AreEqual(42, actual);
            actual = ConvertSuccess(RL(42), Int());
            Assert.AreEqual(42, actual);
        }

        public static IEnumerable<object[]> InvalidCases()
        {
            yield return O(RF(42.1f));
            yield return O(RS("foo"));
            yield return O(RL());
            yield return O(RL(42.1f));
            yield return O(RL("foo"));
            yield return O(RL(42, 43));
            yield return O(RL(RL()));
        }

        [DynamicData(nameof(InvalidCases), DynamicDataSourceType.Method)]
        public void Invalid(ReaderValue value)
        {
            var message = ConvertFailure(value, Int());
            StringAssert.Contains(message, ". Path '/path'.");
        }
    }
}
