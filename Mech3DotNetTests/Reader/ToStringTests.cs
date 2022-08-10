using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ToStringTests
    {
        [DataRow(@"""foo""")]
        [DataRow(@"[""foo""]")]
        [DataTestMethod]
        public void Valid(string json)
        {
            var actual = ConvertSuccess(json, String());
            Assert.AreEqual("foo", actual);
        }

        [DataRow(@"null")] // direct null
        [DataRow(@"42")] // direct int
        [DataRow(@"42.1")] // direct float
        [DataRow(@"true")] // direct bool
        [DataRow(@"false")] // direct bool
        [DataRow(@"[null]")] // nested null
        [DataRow(@"[42]")] // nested int
        [DataRow(@"[42.1]")] // nested float
        [DataRow(@"[true]")] // nested bool
        [DataRow(@"[false]")] // nested bool
        [DataRow(@"[[]]")] // nested array
        [DataRow(@"[]")] // empty array
        [DataRow(@"[""foo"",""bar""]")] // multi array
        [DataRow(@"{}")]
        [DataTestMethod]
        public void Invalid(string json)
        {
            var message = ConvertFailure(json, String());
            StringAssert.EndsWith(message, ". Path '/path'.");
        }
    }
}
