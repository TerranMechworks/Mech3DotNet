using Mech3DotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests
{
    [TestClass]
    public class MessagesTests
    {
        [TestMethod]
        public void SerDe()
        {
            var expected = Normalize("{'language_id': 1033, 'entries': [['MSG_BACK', 1, 'Back']]}");
            var messages = JsonConvert.DeserializeObject<Messages>(expected);
            Assert.AreEqual(1033, messages.languageId);
            Assert.AreEqual(1, messages.entries.Count);
            var entry = messages.entries[0];
            Assert.AreEqual("MSG_BACK", entry.key);
            Assert.AreEqual(1, entry.id);
            Assert.AreEqual("Back", entry.value);
            var actual = JsonConvert.SerializeObject(messages, Formatting.None);
            Assert.AreEqual(expected, actual);
        }
    }
}
