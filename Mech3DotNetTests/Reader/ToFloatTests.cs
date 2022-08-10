using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ToFloatTests
    {
        [DataRow(@"42.1")]
        [DataRow(@"[42.1]")]
        [DataTestMethod]
        public void Valid(string json)
        {
            var actual = ConvertSuccess(json, Float());
            Assert.AreEqual(42.1, actual, 0.0001);
        }

        [DataRow(@"42")]
        [DataRow(@"[42]")]
        [DataTestMethod]
        public void Integers(string json)
        {
            var actual = ConvertSuccess(json, Float());
            Assert.AreEqual(42.0, actual, 0.0001);
        }

        [DataRow(@"null")] // direct null
        // [DataRow(@"42")] // direct int
        [DataRow(@"""foo""")] // direct string
        [DataRow(@"true")] // direct bool
        [DataRow(@"false")] // direct bool
        [DataRow(@"[null]")] // nested null
        // [DataRow(@"[42]")] // nested int
        [DataRow(@"[""foo""]")] // nested string
        [DataRow(@"[true]")] // nested bool
        [DataRow(@"[false]")] // nested bool
        [DataRow(@"[[]]")] // nested array
        [DataRow(@"[]")] // empty array
        [DataRow(@"[42.1,43.1]")] // multi array
        [DataRow(@"{}")]
        [DataTestMethod]
        public void Invalid(string json)
        {
            var message = ConvertFailure(json, Float());
            StringAssert.EndsWith(message, ". Path '/path'.");
        }
    }
}
