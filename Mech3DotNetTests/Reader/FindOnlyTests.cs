using System.Text.Json.Nodes;
using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class FindOnlyTests
    {
        [TestMethod]
        public void FindOnly_NotArray_Throws()
        {
            var element = JsonNode.Parse(@"42");
            Assert.ThrowsException<ConversionException>(() => Q(element) / Only());
        }

        [TestMethod]
        public void FindOnly_NoItems_Throws()
        {
            var element = JsonNode.Parse(@"[]");
            Assert.ThrowsException<NotFoundException>(() => Q(element) / Only());
        }

        [TestMethod]
        public void FindOnly_HasItems_Throws()
        {
            var element = JsonNode.Parse(@"[42,43]");
            Assert.ThrowsException<NotFoundException>(() => Q(element) / Only());
        }

        [TestMethod]
        public void FindOnly_HasItem_ReturnsOnly()
        {
            var element = JsonNode.Parse(@"[42]");
            var first = Q(element) / Only() / Int();
            Assert.AreEqual(42, first);
        }

        [TestMethod]
        public void FindOnly_Applied_ModifiesPath()
        {
            var element = JsonNode.Parse(@"[42]");
            var query = Q(element) / Only();
            Assert.AreEqual("/.only: 42", query.ToString());
        }
    }
}
