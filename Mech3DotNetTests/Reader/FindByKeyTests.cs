using System.Collections.Generic;
using System.Text.Json.Nodes;
using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class FindByKeyTests
    {
        [TestMethod]
        public void NotArray_Throws()
        {
            var element = JsonNode.Parse(@"42");
            Assert.ThrowsException<ConversionException>(() => Q(element) / "foo");
        }

        [TestMethod]
        public void MissingKey_Throws()
        {
            var element = JsonNode.Parse(@"[""foo"",42]");
            Assert.ThrowsException<NotFoundException>(() => Q(element) / "bar");
        }

        [TestMethod]
        public void ValidKey_ReturnsItems()
        {
            var element = JsonNode.Parse(@"[""foo"",42]");
            // this works because ToInt() flattens a single list
            var item = Q(element) / "foo" / Int();
            Assert.AreEqual(42, item);
        }

        [TestMethod]
        public void ValidKeys_ReturnsItems()
        {
            var element = JsonNode.Parse(@"[""foo"",42,""foo"",43]");
            var items = Q(element) / "foo" / Array(Int());
            CollectionAssert.AreEqual(new int[] { 42, 43 }, items);
        }

        [TestMethod]
        public void Apply_ModifiesPath()
        {
            var element = JsonNode.Parse(@"[""foo"",42]");
            var query = Q(element) / "foo";
            var expected = "/foo: [\n  42\n]".Replace("\n", System.Environment.NewLine);
            Assert.AreEqual(expected, query.ToString());
        }
    }
}
