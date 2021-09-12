using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class NodeFlagsTests
    {
        [TestMethod]
        public void Serde_Empty_Roundtrips()
        {
            var expected = Normalize("{}");
            var flags = JsonConvert.DeserializeObject<NodeFlags>(expected);
            Assert.IsFalse(flags.altitudeSurface);
            Assert.IsFalse(flags.intersectSurface);
            Assert.IsFalse(flags.intersectBbox);
            Assert.IsFalse(flags.landmark);
            Assert.IsFalse(flags.unk08);
            Assert.IsFalse(flags.hasMesh);
            Assert.IsFalse(flags.unk10);
            Assert.IsFalse(flags.terrain);
            Assert.IsFalse(flags.canModify);
            Assert.IsFalse(flags.clipTo);
            Assert.IsFalse(flags.unk25);
            Assert.IsFalse(flags.unk28);
            AssertFieldsDefault(flags);
            var actual = JsonConvert.SerializeObject(flags, Formatting.None);
            Assert.AreEqual(expected, actual);
        }
    }
}
