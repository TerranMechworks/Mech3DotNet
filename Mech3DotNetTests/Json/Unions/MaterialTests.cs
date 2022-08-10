using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class MaterialTests
    {
        [TestMethod]
        public void SerDe_TexturedPointer_Roundtrips()
        {
            var expected = Normalize(@"{'Textured': {
    'texture': 'foo',
    'pointer': 4294967295,
    'unk32': 4294967295,
    'flag': true
}}");
            var material = JsonConvert.DeserializeObject<Material>(expected);
            Assert.IsTrue(material.Is<Material.Textured>());
            Assert.IsFalse(material.Is<Material.Colored>());
            var texture = material.As<Material.Textured>();
            Assert.IsNotNull(texture);
            Assert.AreEqual("foo", texture.texture);
            Assert.AreEqual(uint.MaxValue, texture.pointer);
            Assert.IsNull(texture.cycle);
            Assert.AreEqual(uint.MaxValue, texture.unk32);
            Assert.IsTrue(texture.flag);
            var actual = JsonConvert.SerializeObject(material, Formatting.None);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SerDe_TexturedCycle_Roundtrips()
        {
            var expected = Normalize(@"{'Textured': {
    'texture': 'foo',
    'cycle': {
        'textures': ['foo1', 'foo2', 'foo3'],
        'unk00': true,
        'unk04': 4294967295,
        'unk12': 0.5,
        'info_ptr': 4294967294,
        'data_ptr': 4294967293
    },
    'unk32': 4294967295,
    'flag': true
}}");
            var material = JsonConvert.DeserializeObject<Material>(expected);
            Assert.IsTrue(material.Is<Material.Textured>());
            Assert.IsFalse(material.Is<Material.Colored>());
            var texture = material.As<Material.Textured>();
            Assert.IsNotNull(texture);
            Assert.AreEqual("foo", texture.texture);
            Assert.AreEqual(uint.MinValue, texture.pointer);
            var cycle = texture.cycle;
            Assert.IsNotNull(cycle);
            CollectionAssert.AreEquivalent(new string[] { "foo1", "foo2", "foo3" }, cycle.textures);
            Assert.IsTrue(cycle.unk00);
            Assert.AreEqual(uint.MaxValue - 0, cycle.unk04);
            Assert.AreEqual(0.5f, cycle.unk12, 0.001f);
            Assert.AreEqual(uint.MaxValue - 1, cycle.infoPtr);
            Assert.AreEqual(uint.MaxValue - 2, cycle.dataPtr);
            Assert.AreEqual(uint.MaxValue, texture.unk32);
            Assert.IsTrue(texture.flag);
            var actual = JsonConvert.SerializeObject(material, Formatting.None);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SerDe_Colored_Roundtrips()
        {
            var expected = Normalize("{'Colored': {'color': [0.1, 0.2, 0.3], 'unk00': 255, 'unk32': 4294967295}}");
            var material = JsonConvert.DeserializeObject<Material>(expected);
            Assert.IsTrue(material.Is<Material.Colored>());
            Assert.IsFalse(material.Is<Material.Textured>());
            var color = material.As<Material.Colored>();
            Assert.IsNotNull(color);
            Assert.AreEqual(new Color(0.1f, 0.2f, 0.3f), color.color);
            Assert.AreEqual(byte.MaxValue, color.unk00);
            Assert.AreEqual(uint.MaxValue, color.unk32);
            var actual = JsonConvert.SerializeObject(material, Formatting.None);
            Assert.AreEqual(expected, actual);
        }
    }
}
