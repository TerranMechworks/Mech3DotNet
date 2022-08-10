using System;
using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Mech3DotNetTests.Json
{
    struct TestStruct
    {
        public float A;
        public float B;

        public TestStruct(float a, float b)
        {
            A = a;
            B = b;
        }
    }

    [TestClass]
    public class StructTupleConverterTests
    {
        [TestMethod]
        public void Deserialize()
        {
            var converter = new StructTupleConverter(typeof(TestStruct), new Type[] { typeof(float), typeof(float) });
            var test = JsonConvert.DeserializeObject<TestTuple>("[0.1, 0.2]", converter);
            Assert.AreEqual(0.1f, test.A, 0.00001f);
            Assert.AreEqual(0.2f, test.B, 0.00001f);
        }
    }
}
