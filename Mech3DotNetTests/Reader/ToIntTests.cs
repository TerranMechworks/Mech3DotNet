using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ToIntTests
    {
        [DataRow(@"42")]
        [DataRow(@"[42]")]
        [DataTestMethod]
        public void Valid(string json)
        {
            var actual = ConvertSuccess(json, Int());
            Assert.AreEqual(42, actual);
        }

        [DataRow(@"null")] // direct null
        [DataRow(@"42.1")] // direct float
        [DataRow(@"""foo""")] // direct string
        [DataRow(@"true")] // direct bool
        [DataRow(@"false")] // direct bool
        [DataRow(@"[null]")] // nested null
        [DataRow(@"[42.1]")] // nested float
        [DataRow(@"[""foo""]")] // nested string
        [DataRow(@"[true]")] // nested bool
        [DataRow(@"[false]")] // nested bool
        [DataRow(@"[[]]")] // nested array
        [DataRow(@"[]")] // empty array
        [DataRow(@"[42,43]")] // multi array
        [DataRow(@"{}")]
        [DataTestMethod]
        public void Invalid(string json)
        {
            var message = ConvertFailure(json, Int());
            StringAssert.EndsWith(message, ". Path '/path'.");
        }
    }
}
