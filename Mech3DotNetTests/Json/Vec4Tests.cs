using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class Vec4Tests
    {
        [TestMethod]
        public void SerDe_Default_Roundtrips()
        {
            var expected = Normalize("[0.1, 0.2, 0.3, 0.4]");
            var vec = JsonConvert.DeserializeObject<Vec4>(expected);
            Assert.AreEqual(0.1f, vec.x, 0.001f);
            Assert.AreEqual(0.2f, vec.y, 0.001f);
            Assert.AreEqual(0.3f, vec.z, 0.001f);
            Assert.AreEqual(0.4f, vec.w, 0.001f);
            var actual = JsonConvert.SerializeObject(vec, Formatting.None);
            Assert.AreEqual(expected, actual);
        }
    }
}
