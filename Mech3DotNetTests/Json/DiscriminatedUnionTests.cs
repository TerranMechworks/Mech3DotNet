using Mech3DotNet;
using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Json
{
    [JsonConverter(typeof(DiscriminatedUnionConverter<TestUnion>))]
    class TestUnion : DiscriminatedUnion
    {
        public sealed class Foo
        {
            [JsonProperty(Required = Required.Always)]
            public int Value;
            public Foo() { }
        }
        public sealed class Bar { public Bar() { } }
        public TestUnion(Foo value) { this.value = value; }
        public TestUnion(Bar value) { this.value = value; }
    }

    [TestClass]
    public class TestUnionTests
    {
        [TestMethod]
        public void Foo()
        {
            var expected = new TestUnion.Foo();
            expected.Value = 42;
            var test = new TestUnion(expected);
            Assert.IsTrue(test.Is<TestUnion.Foo>());
            Assert.IsFalse(test.Is<TestUnion.Bar>());
            var actual = test.As<TestUnion.Foo>();
            Assert.AreSame(expected, actual);
            Assert.ThrowsException<InvalidCastException>(() => test.As<TestUnion.Bar>());
        }

        [TestMethod]
        public void Bar()
        {
            var expected = new TestUnion.Bar();
            var test = new TestUnion(expected);
            Assert.IsTrue(test.Is<TestUnion.Bar>());
            Assert.IsFalse(test.Is<TestUnion.Foo>());
            var actual = test.As<TestUnion.Bar>();
            Assert.AreSame(expected, actual);
            Assert.ThrowsException<InvalidCastException>(() => test.As<TestUnion.Foo>());
        }
    }

    [TestClass]
    public class DiscriminatedUnionTests
    {
        [TestMethod]
        public void SerDe_Foo_Roundtrips()
        {
            var expected = Normalize("{'Foo': {'Value': 42}}");
            var test = JsonConvert.DeserializeObject<TestUnion>(expected);
            Assert.IsTrue(test.Is<TestUnion.Foo>());
            var foo = test.As<TestUnion.Foo>();
            Assert.AreEqual(42, foo.Value);
            var actual = JsonConvert.SerializeObject(test, Formatting.None);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SerDe_Bar_Roundtrips()
        {
            var expected = Normalize("'Bar'");
            var test = JsonConvert.DeserializeObject<TestUnion>(expected);
            Assert.IsTrue(test.Is<TestUnion.Bar>());
            var actual = JsonConvert.SerializeObject(test, Formatting.None);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deserialize_RequiresValues_Throws()
        {
            var json = "'Foo'";
            var e = Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<TestUnion>(json));
            Assert.AreEqual(
                $"Discriminant 'Foo' for {nameof(TestUnion)} requires values. Path '', line 1, position {json.Length}.",
                e.Message);
        }

        [TestMethod]
        public void Deserialize_RequiresNoValues_Throws()
        {
            var json = "{'Bar':";
            var e = Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<TestUnion>(json));
            Assert.AreEqual(
                $"Discriminant 'Bar' for {nameof(TestUnion)} has no values. Path 'Bar', line 1, position {json.Length}.",
                e.Message);
        }

        [TestMethod]
        public void Deserialize_InvalidStart_Throws()
        {
            // sometimes, there is no rhyme or reason to Json.NET's error messages:
            // JsonConvert.DeserializeObject<Dictionary<string, JObject>>("[");
            // Cannot deserialize the current JSON array (e.g. [1,2,3]) into type
            // 'System.Collections.Generic.Dictionary`2[System.String,Newtonsoft.Json.Linq.JObject]'
            // because the type requires a JSON object (e.g. {"name":"value"}) to deserialize correctly.
            var e = Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<TestUnion>("["));
            Assert.AreEqual(
                $"Unexpected token when deserializing object: {JsonToken.StartArray}. Path '', line 1, position 1.",
                e.Message);
        }

        private void CompareErrors<T>(string json) where T : Exception
        {
            var expected = Assert.ThrowsException<T>(
                () => JsonConvert.DeserializeObject<Dictionary<string, JObject>>(json));
            var actual = Assert.ThrowsException<T>(
                () => JsonConvert.DeserializeObject<TestUnion>(json));
            Console.WriteLine("Expected: {0}", expected.Message);
            Console.WriteLine("Actual: {0}", actual.Message);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void Deserialize_IncompleteObjectAfterStart_Throws()
        {
            CompareErrors<JsonSerializationException>("{");
        }

        [TestMethod]
        public void Deserialize_IncompleteObjectAfterProp_Throws()
        {
            CompareErrors<JsonReaderException>("{'Foo'");
        }

        [TestMethod]
        public void Deserialize_InvalidDiscriminant_Throws()
        {
            var json = "{'Baz':";
            var e = Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<TestUnion>(json));
            Assert.AreEqual(
                $"Invalid discriminant 'Baz' for {nameof(TestUnion)}. Path 'Baz', line 1, position {json.Length}.",
                e.Message);

        }

        [TestMethod]
        public void Deserialize_IncompleteObjectAfterColon_Throws()
        {
            CompareErrors<JsonSerializationException>("{'Foo':");
        }

        [TestMethod]
        public void Deserialize_IncompleteObjectAfterComma_Throws()
        {
            // sometimes, there is no rhyme or reason to Json.NET's error messages (changed in from 4.5 -> 7.0)
            // JsonConvert.DeserializeObject<Dictionary<string, JObject>>("{'Foo':,")
            // System.ArgumentException: The value "" is not of type "Newtonsoft.Json.Linq.JObject"
            // and cannot be used in this generic collection.
            var json = "{'Foo':,";
            var e = Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<TestUnion>(json));
            Assert.AreEqual(
                $"Unexpected end when deserializing object. Path 'Foo', line 1, position {json.Length}.",
                e.Message);
        }

        [TestMethod]
        public void Deserialize_IncompleteObjectAfterObject_Throws()
        {
            CompareErrors<JsonSerializationException>("{'Foo':{'Value':42}");
        }

        [TestMethod]
        public void Deserialize_InvalidEnd_Throws()
        {
            CompareErrors<JsonReaderException>("{'Foo':{'Value':42}]");
        }

        [TestMethod]
        public void Deserialize_ExtraDiscriminant_Throws()
        {
            var json = "{'Foo':{'Value':42}, 'Bar':";
            var e = Assert.ThrowsException<JsonReaderException>(
                () => JsonConvert.DeserializeObject<TestUnion>(json));
            Assert.AreEqual(
                $"Too many elements for {nameof(TestUnion)}. Path 'Bar', line 1, position {json.Length}.",
                e.Message);
        }

        [TestMethod]
        public void Deserialize_InvalidType_Throws()
        {
            var json = "{'Foo':1";
            var e = Assert.ThrowsException<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<TestUnion>(json));
            Assert.AreEqual(
                $"Error converting value 1 to type '{typeof(TestUnion.Foo).FullName}'. Path 'Foo', line 1, position {json.Length}.",
                e.Message);
        }

        [JsonConverter(typeof(DiscriminatedUnionConverter<TestValue>))]
        class TestValue : DiscriminatedUnion
        {
            public sealed class Foo
            {
                [JsonProperty(Required = Required.Always)]
                public float value = 0f;
                [JsonConstructor]
                private Foo() { }
            }

            public TestValue(Foo value) { this.value = value; }
        }

        [TestMethod]
        public void Deserialize_Converters_AreCalled()
        {
            // this tests proves we are using the converters in the settings
            var settings = Settings.GetSerializerSettings(new FailConverter<float>());
            Assert.ThrowsException<FailConverter<float>.Fail>(
                () => JsonConvert.DeserializeObject<TestValue>("{'Foo': {'value': 1.0}}", settings));
        }
    }
}
