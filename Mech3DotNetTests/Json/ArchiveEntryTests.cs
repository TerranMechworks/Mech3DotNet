using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class ArchiveEntryTests
    {
        private static readonly byte[] testBinary = System.Text.Encoding.ASCII.GetBytes("Hello world");
        private static readonly string testBase64 = System.Convert.ToBase64String(testBinary);

        [TestMethod]
        public void Base64Roundtrip()
        {
            var expected = $@"{{""name"":""Foo"",""garbage"":""{testBase64}""}}";
            var entry = JsonSerializer.Deserialize<ArchiveEntry>(expected);
            Assert.IsNotNull(entry);
            Assert.AreEqual("Foo", entry.name);
            CollectionAssert.AreEqual(testBinary, entry.garbage);
            var actual = JsonSerializer.Serialize(entry);
            Assert.AreEqual(expected, actual);
        }
    }
}
