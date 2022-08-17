using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class FindOnlyTests
    {
        [TestMethod]
        public void FindOnly_NotArray_Throws()
        {
            var value = RI(42);
            Assert.ThrowsException<ConversionException>(() => value / Only());
        }

        [TestMethod]
        public void FindOnly_NoItems_Throws()
        {
            var value = RL();
            Assert.ThrowsException<NotFoundException>(() => value / Only());
        }

        [TestMethod]
        public void FindOnly_HasItems_Throws()
        {
            var value = RL(42, 42);
            Assert.ThrowsException<NotFoundException>(() => value / Only());
        }

        [TestMethod]
        public void FindOnly_HasItem_ReturnsOnly()
        {
            var value = RL(42);
            var first = value / Only() / Int();
            Assert.AreEqual(42, first);
        }

        [TestMethod]
        public void FindOnly_Applied_ModifiesPath()
        {
            var value = RL(42);
            var query = value / Only();
            Assert.AreEqual("/.only: 42", query.ToString());
        }
    }
}
