using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class ColorTests
    {
        [TestMethod]
        public void Serde_Default_Roundtrips()
        {
            var expected = Normalize("[0.1, 0.2, 0.3]");
            var color = JsonConvert.DeserializeObject<Color>(expected);
            Assert.AreEqual(0.1f, color.r, 0.001f);
            Assert.AreEqual(0.2f, color.g, 0.001f);
            Assert.AreEqual(0.3f, color.b, 0.001f);
            var actual = JsonConvert.SerializeObject(color, Formatting.None);
            Assert.AreEqual(expected, actual);
        }
    }
}
