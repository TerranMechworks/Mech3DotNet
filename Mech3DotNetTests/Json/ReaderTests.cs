using Mech3DotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class ReaderTests
    {
        [TestMethod]
        public void ReadWrite_Roundtrip_ReturnsSameJson()
        {
            var expected = Normalize("[['foo']]");
            var reader = Reader.Parse(expected);
            var actual = Normalize(reader.GetJson());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Read_MultipleChildren_ThrowsInvalidRoot()
        {
            Assert.ThrowsException<Reader.InvalidRootException>(
                () => Reader.Parse("[['foo'], ['bar']]"));
        }

        [TestMethod]
        public void Query_RootPath_ReturnsRoot()
        {
            var root = JArray.Parse("['foo']");
            var reader = new Reader(root);
            var query = reader.Query("/");
            Assert.AreEqual(root, query);
        }

        [DataTestMethod]
        [DataRow("['foo', 'bar']", "/foo")]
        [DataRow("['foo', ['baz', 'bar']]", "/foo/baz")]
        public void Query_KeyAndValueExists_ReturnsValue(string json, string path)
        {
            var root = JArray.Parse(json);
            var reader = new Reader(root);
            var query = reader.Query(path);
            Assert.AreEqual("bar", (string)query);
        }

        [DataTestMethod]
        [DataRow(@"['bar']", "/0")]
        [DataRow(@"['foo', 'bar']", "/1")]
        [DataRow(@"['bar']", "/-1")]
        [DataRow(@"[['bar']]", "/0/0")]
        [DataRow(@"[['bar']]", "/-1/0")]
        [DataRow(@"[['bar']]", "/0/-1")]
        public void Query_ValidIndex_ReturnsValue(string json, string path)
        {
            var root = JArray.Parse(json);
            var reader = new Reader(root);
            var query = reader.Query(path);
            Assert.AreEqual("bar", (string)query);
        }

        [TestMethod]
        public void Query_KeyMultipleAll_ReturnsValues()
        {
            var root = JArray.Parse("['foo', 1, 'foo', 2, 'foo', 3]");
            var reader = new Reader(root);
            var query = reader.Query("/foo");
            CollectionAssert.AreEquivalent(new JArray(1, 2, 3), (JArray)query);
        }

        [TestMethod]
        public void Query_KeyMultipleOne_ReturnsValue()
        {
            var root = JArray.Parse("['foo', 1, 'foo', 'bar', 'foo', 3]");
            var reader = new Reader(root);
            var query = reader.Query("/foo/1");
            Assert.AreEqual("bar", (string)query);
        }

        [DataTestMethod]
        [DataRow("[]", "/foo")]
        [DataRow("['bar']", "/foo")]
        [DataRow("[['bar']]", "/0/foo")]
        public void Query_KeyMissing_ThrowsNotFound(string json, string path)
        {
            var root = JArray.Parse(json);
            var reader = new Reader(root);
            var e = Assert.ThrowsException<Reader.NotFoundException>(() => reader.Query(path));
            StringAssert.Contains(e.ToString(), "no key");
        }

        [DataTestMethod]
        [DataRow(@"['foo']", "/foo")]
        [DataRow(@"[['foo']]", "/0/foo")]
        public void Query_KeyExistsValueMissing_ThrowsNotFound(string json, string path)
        {
            var root = JArray.Parse(json);
            var reader = new Reader(root);
            var e = Assert.ThrowsException<Reader.NotFoundException>(() => reader.Query(path));
            StringAssert.Contains(e.ToString(), "no value");
        }

        [DataTestMethod]
        [DataRow(@"[]", "/0")]
        [DataRow(@"[]", "/-1")]
        [DataRow(@"['foo']", "/1")]
        [DataRow(@"['foo']", "/-2")]
        public void Query_InvalidIndex_ThrowsNotFound(string json, string path)
        {
            var root = JArray.Parse(json);
            var reader = new Reader(root);
            var e = Assert.ThrowsException<Reader.NotFoundException>(() => reader.Query(path));
            StringAssert.Contains(e.ToString(), "index");
        }

        [DataTestMethod]
        [DataRow(@"['foo']", "/0/0")]
        [DataRow(@"['foo']", "/0/bar")]
        [DataRow(@"[42]", "/0/0")]
        [DataRow(@"[42]", "/0/bar")]
        [DataRow(@"[0.5]", "/0/0")]
        [DataRow(@"[0.5]", "/0/bar")]
        public void Query_NotAnArray_ThrowsNotFound(string json, string path)
        {
            var root = JArray.Parse(json);
            var reader = new Reader(root);
            var e = Assert.ThrowsException<Reader.NotFoundException>(() => reader.Query(path));
            StringAssert.Contains(e.ToString(), "not an array");
        }
    }
}
