using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class MessageEntryTests
    {
        [TestMethod]
        public void SerDe_Default_Roundtrips()
        {
            var expected = Normalize("['MSG_BACK', 1, 'Back']");
            var entry = JsonConvert.DeserializeObject<MessageEntry>(expected);
            Assert.AreEqual("MSG_BACK", entry.key);
            Assert.AreEqual(1, entry.id);
            Assert.AreEqual("Back", entry.value);
            var actual = JsonConvert.SerializeObject(entry, Formatting.None);
            Assert.AreEqual(expected, actual);
        }
    }
}
