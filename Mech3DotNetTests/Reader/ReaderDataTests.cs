using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ReaderDataTests
    {
        [TestMethod]
        public void ReadWrite_Roundtrip_ReturnsSameJson()
        {
            var expected = Normalize("[['foo']]");
            var reader = ReaderData.Deserialize(expected);
            var actual = Normalize(reader.Serialize());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Read_MultipleChildren_ThrowsInvalidRoot()
        {
            Assert.ThrowsException<InvalidRootException>(() => ReaderData.Deserialize("[['foo'], ['bar']]"));
        }

        [TestMethod]
        public void Read_NoChildren_ThrowsInvalidRoot()
        {
            Assert.ThrowsException<InvalidRootException>(() => ReaderData.Deserialize("[]"));
        }
    }
}
