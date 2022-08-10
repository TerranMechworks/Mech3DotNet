using System;
using System.Text.Json;
using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class ScriptTests
    {
        [TestMethod]
        public void DatetimeRoundtrip()
        {
            var expected = @"{""name"":""Support\\foo.gw"",""last_modified"":""1999-04-01T23:05:42Z"",""lines"":[""Command Arg1 Arg2""]}";
            var script = JsonSerializer.Deserialize<Script>(expected);
            Assert.IsNotNull(script);
            Assert.AreEqual("Support\\foo.gw", script.name);
            Assert.AreEqual(new DateTime(1999, 04, 01, 23, 05, 42, DateTimeKind.Utc), script.lastModified);
            CollectionAssert.AreEquivalent(new string[] { "Command Arg1 Arg2" }, script.lines);
            var actual = JsonSerializer.Serialize(script);
            Assert.AreEqual(expected, actual);
        }
    }
}
