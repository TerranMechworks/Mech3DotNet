using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.Reader.Query;
using static Mech3DotNetTests.Reader.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class FindByIndexTests
    {
        [TestMethod]
        public void NotArray_Throws()
        {
            var value = RI(42);
            Assert.ThrowsException<ConversionException>(() => value / 0);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(-2)]
        [DataRow(-3)]
        public void InvalidIndex_Throws(int index)
        {
            var value = RL(42);
            Assert.ThrowsException<NotFoundException>(() => value / index);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void ValidIndex_ReturnsItem(int index)
        {
            var value = RL(42);
            var item = value / index / Int();
            Assert.AreEqual(42, item);
        }

        [TestMethod]
        public void Apply_ModifiesPath()
        {
            var value = RL(42, 43);
            var query = value / 1;
            Assert.AreEqual("/1: 43", query.ToString());
        }
    }
}
