using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class ArchiveEntryTests
    {
        private static readonly byte[] testBinary = System.Text.Encoding.ASCII.GetBytes("Hello world");
        private static readonly string testBase64 = System.Convert.ToBase64String(testBinary);

        [TestMethod]
        public void SerDe_Default_Roundtrips()
        {
            var expected = Normalize("{'name': 'Foo', 'garbage': '" + testBase64 + "'}");
            var entry = JsonConvert.DeserializeObject<ArchiveEntry>(expected);
            Assert.AreEqual("Foo", entry.name);
            CollectionAssert.AreEqual(testBinary, entry.garbage);
            var actual = JsonConvert.SerializeObject(entry, Formatting.None);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deserialize_NameMissing_Throws()
        {
            var e = Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<ArchiveEntry>("{'garbage': ''}"));
            StringAssert.Contains(e.Message, "name");
        }

        [TestMethod]
        public void Deserialize_GarbageMissing_Throws()
        {
            var e = Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<ArchiveEntry>("{'name': 'Foo'}"));
            StringAssert.Contains(e.Message, "garbage");
        }
    }
}