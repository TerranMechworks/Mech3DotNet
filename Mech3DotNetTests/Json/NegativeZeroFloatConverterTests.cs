using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using static Mech3DotNet.Json.NegativeZeroFloatConverter;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class NegativeZeroFloatConverterTests
    {
        private static readonly JsonConverter converter = new NegativeZeroFloatConverter();

        [TestMethod]
        public void EncodeDecode_OnlyNegativeZero_IsReplaced()
        {
            var json = NEGATIVE_ZERO_STRING;
            var encoded = EncodeNegativeZero(json);
            Assert.AreEqual(NEGATIVE_ZERO_REPLACE, encoded);
            var decoded = DecodeNegativeZero(encoded);
            Assert.AreEqual(json, decoded);
        }

        [TestMethod]
        public void EncodeDecode_EmbeddedNegativeZero_IsReplaced()
        {
            var json = "{\"value\": -0.0}";
            var encoded = EncodeNegativeZero(json);
            Assert.AreEqual("{\"value\": \"-0.0\"}", encoded);
            var decoded = DecodeNegativeZero(encoded);
            Assert.AreEqual(json, decoded);
        }

        [TestMethod]
        public void EncodeNegativeZero_NotNegativeZero_IsNotChanged()
        {
            var json = "{\"value\": -0.01}";
            var encoded = EncodeNegativeZero(json);
            Assert.AreEqual(json, encoded);
            var decoded = DecodeNegativeZero(encoded);
            Assert.AreEqual(json, decoded);
        }

        [TestMethod]
        public void ReadJson_EscapedNegativeZero_IsRead()
        {
            var value = JsonConvert.DeserializeObject<float>(NEGATIVE_ZERO_REPLACE, converter);
            var actual = FloatToUInt32Bits(value);
            Assert.AreEqual(NEGATIVE_ZERO_BITS, actual, $"{NEGATIVE_ZERO_BITS:X8} != {actual:X8}");
        }

        [TestMethod]
        public void WriteJson_NegativeZero_IsWrittenEscaped()
        {
            var json = JsonConvert.SerializeObject(NEGATIVE_ZERO_FLOAT, converter);
            Assert.AreEqual(NEGATIVE_ZERO_REPLACE, json);
        }

        [TestMethod]
        public void SerDe_EscapedNegativeZero_Roundtrips()
        {
            var value = JsonConvert.DeserializeObject<float>(NEGATIVE_ZERO_REPLACE, converter);
            var json = JsonConvert.SerializeObject(value, converter);
            Assert.AreEqual(NEGATIVE_ZERO_REPLACE, json);
        }

        public static void FloatsAreEqual(float expected, float actual)
        {
            var expectedBits = FloatToUInt32Bits(expected);
            var actualBits = FloatToUInt32Bits(actual);
            Assert.AreEqual(
                expectedBits, actualBits, $"{expected} ({expectedBits:X8}) != {actual} ({actualBits:X8})");
        }

        [DataTestMethod]
        [DataRow(0f)]
        [DataRow(0.1f)]
        [DataRow(-0.1f)]
        [DataRow(0.01f)]
        [DataRow(-0.01f)]
        [DataRow(1f)]
        [DataRow(-1f)]
        [DataRow(10f)]
        [DataRow(-10f)]
        public void SerDe_OtherFloats_Roundtrip(float expected)
        {
            var json = JsonConvert.SerializeObject(expected, converter);
            var actual = JsonConvert.DeserializeObject<float>(json, converter);
            FloatsAreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("0.0")]
        [DataRow("0.1")]
        [DataRow("-0.1")]
        [DataRow("0.01")]
        [DataRow("-0.01")]
        [DataRow("1.0")]
        [DataRow("-1.0")]
        [DataRow("10.0")]
        [DataRow("-10.0")]
        [DataRow("42")]
        [DataRow("false")]
        public void ReadJson_ValidToken_ProducesSameResult(string json)
        {
            var expected = JsonConvert.DeserializeObject<float>(json);
            var actual = JsonConvert.DeserializeObject<float>(json, converter);
            FloatsAreEqual(expected, actual);

        }

        [DataTestMethod]
        [DataRow("'foo'")]
        [DataRow("null")]
        [DataRow("{}")]
        [DataRow("[]")]
        public void ReadJson_InvalidToken_ThrowsSameException(string json)
        {
            var expected = Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<float>(json));
            var actual = Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<float>(json, converter));
            Console.WriteLine("Expected: {0}", expected.Message);
            Console.WriteLine("Actual: {0}", actual.Message);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        private class TestNullable
        {
            [JsonProperty(Required = Required.AllowNull)]
            public float? value = null;
            [JsonConstructor]
            private TestNullable() { }
        }

        [TestMethod]
        public void SerDe_Nullable_Roundtrip()
        {
            var expected = Helpers.Normalize("{'value': null}");
            var test = JsonConvert.DeserializeObject<TestNullable>(expected, converter);
            Assert.IsNull(test.value);
            var actual = JsonConvert.SerializeObject(test, converter);
            Assert.AreEqual(expected, actual);
        }
    }
}
