using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Json
{
    [JsonConverter(typeof(TransparentConverter<TestProxy>))]
    class TestProxy
    {
        public float A;

        public TestProxy(float a)
        {
            A = a;
        }
    }

    [TestClass]
    public class TransparentConverterTests
    {
        [TestMethod]
        public void SerDe_Proxy_Roundtrips()
        {
            var expected = Normalize("0.1");
            var test = JsonConvert.DeserializeObject<TestProxy>(expected);
            Assert.AreEqual(0.1f, test.A, 0.00001f);
            var actual = JsonConvert.SerializeObject(test, Formatting.None);
            Assert.AreEqual(expected, actual);
        }
    }
}
