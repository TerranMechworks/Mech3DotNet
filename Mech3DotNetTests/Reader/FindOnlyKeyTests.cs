using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class FindOnlyKeyTests
    {
        [TestMethod]
        public void NotArray_Throws()
        {
            var value = RI(42);
            Assert.ThrowsException<ConversionException>(() => value / Only("foo"));
        }

        [TestMethod]
        public void MissingKey_Throws()
        {
            var value = RL("foo", 42);
            Assert.ThrowsException<NotFoundException>(() => value / Only("bar"));
        }

        [TestMethod]
        public void ValidKeys_Throws()
        {
            var value = RL("foo", 42, "foo", 43);
            Assert.ThrowsException<NotFoundException>(() => value / Only("foo"));
        }

        [TestMethod]
        public void ValidKey_ReturnsItems()
        {
            var value = RL("foo", 42);
            var item = value / Only("foo");
            Assert.AreEqual(RI(42), item.Value);
        }

        [TestMethod]
        public void Apply_ModifiesPath()
        {
            var value = RL("foo", 42);
            var query = value / Only("foo");
            var expected = "/foo/.only: 42";
            Assert.AreEqual(expected, query.ToString().Replace(System.Environment.NewLine, ""));
        }
    }
}
