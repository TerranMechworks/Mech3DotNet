using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ToBoolTests
    {
        [DataRow(@"""true""", true)]
        [DataRow(@"[""true""]", true)]
        [DataRow(@"""false""", false)]
        [DataRow(@"[""false""]", false)]
        [DataTestMethod]
        public void Valid(string json, bool expected)
        {
            var actual = ConvertSuccess(json, Bool());
            Assert.AreEqual(expected, actual);
        }

        [DataRow(@"null")] // direct null
        [DataRow(@"42")] // direct int
        [DataRow(@"42.1")] // direct float
        [DataRow(@"true")] // direct bool
        [DataRow(@"false")] // direct bool
        [DataRow(@"""foo""")] // direct string
        [DataRow(@"[null]")] // nested null
        [DataRow(@"[42]")] // nested int
        [DataRow(@"[42.1]")] // nested float
        [DataRow(@"[true]")] // nested bool
        [DataRow(@"[false]")] // nested bool
        [DataRow(@"[""foo""]")] // nested string
        [DataRow(@"[[]]")] // nested array
        [DataRow(@"[]")] // empty array
        [DataRow(@"[""foo"",""bar""]")] // multi array
        [DataRow(@"{}")]
        [DataTestMethod]
        public void Invalid(string json)
        {
            var message = ConvertFailure(json, Bool());
            StringAssert.Contains(message, ". Path '/path'.");
        }
    }
}
