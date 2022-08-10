using System;
using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class InterpreterScriptTests
    {
        [TestMethod]
        public void SerDe_Default_Roundtrips()
        {
            var expected = Normalize(@"{
  'name': 'Support\\foo.gw',
  'last_modified': '1999-04-01T23:05:42Z',
  'lines': ['Command Arg1 Arg2']
}");
            var interp = JsonConvert.DeserializeObject<InterpreterScript>(expected);
            Assert.AreEqual("Support\\foo.gw", interp.name);
            Assert.AreEqual(new DateTime(1999, 04, 01, 23, 05, 42, DateTimeKind.Utc), interp.lastModified);
            CollectionAssert.AreEquivalent(new string[] { "Command Arg1 Arg2" }, interp.lines);
            var actual = JsonConvert.SerializeObject(interp, Formatting.None);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deserialise_NameMissing_Throws()
        {
            var e = Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<InterpreterScript>(@"{
  'last_modified': '1999-04-01T23:05:42Z',
  'lines': ['Command Arg1 Arg2']
}"));
            StringAssert.Contains(e.Message, "name");
        }

        [TestMethod]
        public void Deserialise_LastModifiedMissing_Throws()
        {
            var e = Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<InterpreterScript>(@"{
  'name': 'Support\\foo.gw',
  'lines': ['Command Arg1 Arg2']
}"));
            StringAssert.Contains(e.Message, "last_modified");
        }

        [TestMethod]
        public void Deserialise_LinesMissing_Throws()
        {
            var e = Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<InterpreterScript>(@"{
  'name': 'Support\\foo.gw',
  'last_modified': '1999-04-01T23:05:42Z'
}"));
            StringAssert.Contains(e.Message, "lines");
        }
    }
}
