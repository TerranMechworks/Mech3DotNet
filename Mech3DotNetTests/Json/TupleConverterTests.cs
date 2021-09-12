using System;
using System.Collections.Generic;
using Mech3DotNet;
using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Json
{
    [JsonConverter(typeof(TupleConverter<TestTuple>))]
    class TestTuple
    {
        public float A;
        public float B;

        public TestTuple(float a, float b)
        {
            A = a;
            B = b;
        }
    }

    [TestClass]
    public class TupleConverterTests
    {
        [TestMethod]
        public void SerDe_Tuple_Roundtrips()
        {
            var expected = Normalize("[0.1, 0.2]");
            var test = JsonConvert.DeserializeObject<TestTuple>(expected);
            Assert.AreEqual(0.1f, test.A, 0.00001f);
            Assert.AreEqual(0.2f, test.B, 0.00001f);
            var actual = JsonConvert.SerializeObject(test, Formatting.None);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deserialize_ValueObjectToken_Throws()
        {
            Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<TestTuple>("[0.1, {}]"));
        }

        [TestMethod]
        public void Deserialize_ValueStringTokenLenient_Works()
        {
            var tuple = JsonConvert.DeserializeObject<TestTuple>("['0.1', 0.2]");
            Assert.AreEqual(0.1f, tuple.A, 0.00001f);
        }

        private Tuple<string, string> CompareDeserialize<T>(string json) where T : Exception
        {
            var expected = Assert.ThrowsException<T>(
                () => JsonConvert.DeserializeObject<List<float>>(json));
            var actual = Assert.ThrowsException<T>(
                () => JsonConvert.DeserializeObject<TestTuple>(json));
            Console.WriteLine("Expected: {0}", expected.Message);
            Console.WriteLine("Actual: {0}", actual.Message);
            return new Tuple<string, string>(expected.Message, actual.Message);
        }

        private void CompareErrors<T>(string json) where T : Exception
        {
            var result = CompareDeserialize<T>(json);
            Assert.AreEqual(result.Item1, result.Item2);
        }

        [TestMethod]
        public void Deserialize_InvalidStart_Throws()
        {
            // sometimes, there is no rhyme or reason to Json.NET's error messages:
            var result = CompareDeserialize<JsonSerializationException>("{");
            Assert.AreEqual(
                "Unexpected end when reading JSON. Path '', line 1, position 1.",
                result.Item1);
            Assert.AreEqual(
                $"Unexpected token when deserializing array: {JsonToken.StartObject}. Path '', line 1, position 1.",
                result.Item2);
        }

        [TestMethod]
        public void Deserialize_IncompleteArrayAfterStart_Throws()
        {
            CompareErrors<JsonSerializationException>("[");
        }

        [TestMethod]
        public void Deserialize_IncompleteArrayAfterOne_Throws()
        {
            CompareErrors<JsonSerializationException>("[0.1");
        }

        [TestMethod]
        public void Deserialize_IncompleteArrayAfterColon_Throws()
        {
            CompareErrors<JsonSerializationException>("[0.1,");
        }

        [TestMethod]
        public void Deserialize_IncompleteArrayAfterTwo_Throws()
        {
            CompareErrors<JsonSerializationException>("[0.1,0.2");
        }

        [TestMethod]
        public void Deserialize_InvalidEnd_Throws()
        {
            // sometimes, there is no rhyme or reason to Json.NET's error messages:
            var result = CompareDeserialize<JsonReaderException>("[0.1,0.2}");
            Assert.AreEqual(
                "Unexpected character encountered while parsing value: }. Path '[1]', line 1, position 9.",
                result.Item1);
            Assert.AreEqual(
                $"JsonToken {JsonToken.EndObject} is not valid for closing JsonType Array. Path '', line 1, position 9.",
                result.Item2);
        }

        [TestMethod]
        public void Deserialize_TooFewElementsZero_Throws()
        {
            var json = "[]";
            var e = Assert.ThrowsException<JsonReaderException>(
                () => JsonConvert.DeserializeObject<TestTuple>(json));
            Assert.AreEqual(
                $"Too few elements for {nameof(TestTuple)}. Path '', line 1, position {json.Length}.",
                e.Message);
        }

        [TestMethod]
        public void Deserialize_TooFewElementsOne_Throws()
        {
            var json = "[0.1]";
            var e = Assert.ThrowsException<JsonReaderException>(
                () => JsonConvert.DeserializeObject<TestTuple>(json));
            Assert.AreEqual(
                $"Too few elements for {nameof(TestTuple)}. Path '[0]', line 1, position {json.Length}.",
                e.Message);
        }

        [TestMethod]
        public void Deserialize_TooManyElements_Throws()
        {
            var e = Assert.ThrowsException<JsonReaderException>(
                () => JsonConvert.DeserializeObject<TestTuple>("[0.1,0.2,0.3]"));
            var json = "[0.1,0.2,0.3";
            Assert.AreEqual(
                $"Too many elements for {nameof(TestTuple)}. Path '[2]', line 1, position {json.Length}.",
                e.Message);
        }

        [TestMethod]
        public void Deserialize_Converters_AreCalled()
        {
            // this tests proves we are using the converters in the settings
            var settings = Settings.GetSerializerSettings(new FailConverter<float>());
            Assert.ThrowsException<FailConverter<float>.Fail>(
                () => JsonConvert.DeserializeObject<TestTuple>("[0.1, 0.2]", settings));
        }
    }
}
