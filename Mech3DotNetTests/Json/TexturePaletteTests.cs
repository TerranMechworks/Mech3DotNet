using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class TexturePaletteTests
    {
        private static readonly byte[] testBinary = System.Text.Encoding.ASCII.GetBytes("Hello world");
        private static readonly string testBase64 = System.Convert.ToBase64String(testBinary);

        [TestMethod]
        public void SerDe_None_Roundtrips()
        {
            var expected = Normalize("'None'");
            var palette = JsonConvert.DeserializeObject<TexturePalette>(expected);
            Assert.IsTrue(palette.Is<TexturePalette.None>());
            var actual = JsonConvert.SerializeObject(palette, Formatting.None);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SerDe_Local_Roundtrips()
        {
            var expected = Normalize("{'Local': '" + testBase64 + "'}");
            var palette = JsonConvert.DeserializeObject<TexturePalette>(expected);
            Assert.IsTrue(palette.Is<TexturePalette.Local>());
            var local = palette.As<TexturePalette.Local>();
            CollectionAssert.AreEqual(testBinary, local.palette);
            var actual = JsonConvert.SerializeObject(palette, Formatting.None);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SerDe_Global_Roundtrips()
        {
            var expected = Normalize("{'Global': [20, 42]}");
            var palette = JsonConvert.DeserializeObject<TexturePalette>(expected);
            Assert.IsTrue(palette.Is<TexturePalette.Global>());
            var global = palette.As<TexturePalette.Global>();
            Assert.AreEqual(20, global.index);
            Assert.AreEqual(42, global.length);
            var actual = JsonConvert.SerializeObject(palette, Formatting.None);
            Assert.AreEqual(expected, actual);
        }
    }
}