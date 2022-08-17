using System.Collections.Generic;
using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ToStrTests
    {
        [TestMethod]
        public void Valid()
        {
            var actual = ConvertSuccess(RS("foo"), String());
            Assert.AreEqual("foo", actual);
            actual = ConvertSuccess(RL("foo"), String());
            Assert.AreEqual("foo", actual);
        }

        public static IEnumerable<object[]> InvalidCases()
        {
            yield return O(RI(42));
            yield return O(RF(42.1f));
            yield return O(RL());
            yield return O(RL(42));
            yield return O(RL(42.1f));
            yield return O(RL("foo", "bar"));
            yield return O(RL(RL()));
        }

        [DynamicData(nameof(InvalidCases), DynamicDataSourceType.Method)]
        public void Invalid(ReaderValue value)
        {
            var message = ConvertFailure(value, String());
            StringAssert.Contains(message, ". Path '/path'.");
        }
    }
}
