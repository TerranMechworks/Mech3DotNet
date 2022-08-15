using System.Text.Json.Nodes;
using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class FindByIndexTests
    {
        [TestMethod]
        public void NotArray_Throws()
        {
            var element = JsonNode.Parse(@"42");
            Assert.ThrowsException<ConversionException>(() => Q(element) / 0);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(-2)]
        [DataRow(-3)]
        public void InvalidIndex_Throws(int index)
        {
            var element = JsonNode.Parse(@"[42]");
            Assert.ThrowsException<NotFoundException>(() => Q(element) / index);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void ValidIndex_ReturnsItem(int index)
        {
            var element = JsonNode.Parse(@"[42]");
            var item = Q(element) / index / Int();
            Assert.AreEqual(42, item);
        }

        [TestMethod]
        public void Apply_ModifiesPath()
        {
            var element = JsonNode.Parse(@"[42,43]");
            var query = Q(element) / 1;
            Assert.AreEqual("/1: 43", query.ToString());
        }
    }
}
