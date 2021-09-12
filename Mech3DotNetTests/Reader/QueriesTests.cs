using System.Collections.Generic;
using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using static Mech3DotNet.Reader.Convert;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class QueriesTests
    {
        [TestMethod]
        public void FindByIndex_NotArray_Throws()
        {
            var token = JToken.Parse(@"42");
            Assert.ThrowsException<NotFoundException>(() => Q(token, null) / 0);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(-2)]
        [DataRow(-3)]
        public void FindByIndex_InvalidIndex_Throws(int index)
        {
            var token = JToken.Parse(@"[42]");
            Assert.ThrowsException<NotFoundException>(() => Q(token, null) / index);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void FindByIndex_ValidIndex_ReturnsItem(int index)
        {
            var token = JToken.Parse(@"[42]");
            var item = Q(token, null) / index / Int();
            Assert.AreEqual(42, item);
        }

        [TestMethod]
        public void FindByIndex_Applied_ModifiesPath()
        {
            var token = JToken.Parse(@"[42, 43]");
            var query = Q(token, null) / 1;
            Assert.AreEqual("/1: 43", query.ToString());
        }

        [TestMethod]
        public void FindByKey_NotArray_Throws()
        {
            var token = JToken.Parse(@"42");
            Assert.ThrowsException<NotFoundException>(() => Q(token, null) / "foo");
        }

        [TestMethod]
        public void FindByKey_MissingKey_Throws()
        {
            var token = JToken.Parse(@"['foo', 42]");
            Assert.ThrowsException<NotFoundException>(() => Q(token, null) / "bar");
        }

        [TestMethod]
        public void FindByKey_ValidKey_ReturnsItem()
        {
            var token = JToken.Parse(@"['foo', 42]");
            // this works because ToInt() flattens a single list
            var item = Q(token, null) / "foo" / Int();
            Assert.AreEqual(42, item);
        }

        [TestMethod]
        public void FindByKey_ValidKey_ReturnsItems()
        {
            var token = JToken.Parse(@"['foo', 42, 'foo', 43]");
            var items = Q(token, null) / "foo" / Map(Int());
            CollectionAssert.AreEqual(new List<int>() { 42, 43 }, items);
        }

        [TestMethod]
        public void FindByKey_Applied_ModifiesPath()
        {
            var token = JToken.Parse(@"['foo', 42]");
            var query = Q(token, null) / "foo";
            Assert.AreEqual("/foo: [\n  42\n]", query.ToString());
        }

        [TestMethod]
        public void FindFirst_NotArray_Throws()
        {
            var token = JToken.Parse(@"42");
            Assert.ThrowsException<NotFoundException>(() => Q(token, null) / First());
        }

        [TestMethod]
        public void FindFirst_NoItems_Throws()
        {
            var token = JToken.Parse(@"[]");
            Assert.ThrowsException<NotFoundException>(() => Q(token, null) / First());
        }

        [TestMethod]
        public void FindFirst_HasItems_ReturnsFirst()
        {
            var token = JToken.Parse(@"[42, 43]");
            var first = Q(token, null) / First() / Int();
            Assert.AreEqual(42, first);
        }

        [TestMethod]
        public void FindFirst_Applied_ModifiesPath()
        {
            var token = JToken.Parse(@"[42, 43]");
            var query = Q(token, null) / First();
            Assert.AreEqual("/.first: 42", query.ToString());
        }

        [TestMethod]
        public void FindOnly_NotArray_Throws()
        {
            var token = JToken.Parse(@"42");
            Assert.ThrowsException<NotFoundException>(() => Q(token, null) / Only());
        }

        [TestMethod]
        public void FindOnly_NoItems_Throws()
        {
            var token = JToken.Parse(@"[]");
            Assert.ThrowsException<NotFoundException>(() => Q(token, null) / Only());
        }

        [TestMethod]
        public void FindOnly_HasItems_Throws()
        {
            var token = JToken.Parse(@"[42, 43]");
            Assert.ThrowsException<NotFoundException>(() => Q(token, null) / Only());
        }

        [TestMethod]
        public void FindOnly_HasItem_ReturnsOnly()
        {
            var token = JToken.Parse(@"[42]");
            var first = Q(token, null) / Only() / Int();
            Assert.AreEqual(42, first);
        }

        [TestMethod]
        public void FindOnly_Applied_ModifiesPath()
        {
            var token = JToken.Parse(@"[42]");
            var query = Q(token, null) / Only();
            Assert.AreEqual("/.only: 42", query.ToString());
        }

    }
}
