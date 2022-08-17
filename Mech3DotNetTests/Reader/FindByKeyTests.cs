using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class FindByKeyTests
    {
        [TestMethod]
        public void NotArray_Throws()
        {
            var value = RI(42);
            Assert.ThrowsException<ConversionException>(() => value / "foo");
        }

        [TestMethod]
        public void MissingKey_Throws()
        {
            var value = RL("foo", 42);
            Assert.ThrowsException<NotFoundException>(() => value / "bar");
        }

        [TestMethod]
        public void ValidKey_ReturnsItems()
        {
            var value = RL("foo", 42);
            // this works because ToInt() flattens a single list
            var item = value / "foo" / Int();
            Assert.AreEqual(42, item);
        }

        [TestMethod]
        public void ValidKeys_ReturnsItems()
        {
            var value = RL("foo", 42, "foo", 43);
            var items = value / "foo" / Array(Int());
            CollectionAssert.AreEqual(new int[] { 42, 43 }, items);
        }

        [TestMethod]
        public void Apply_ModifiesPath()
        {
            var value = RL("foo", 42);
            var query = value / "foo";
            var expected = "/foo: [  42,]";
            Assert.AreEqual(expected, query.ToString().Replace(System.Environment.NewLine, ""));
        }
    }
}
