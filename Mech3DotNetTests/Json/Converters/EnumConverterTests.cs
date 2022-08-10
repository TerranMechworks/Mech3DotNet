using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mech3DotNetTests.Json.Converters
{
    [TestClass]
    public class EnumConverterTests
    {
        [JsonConverter(typeof(EnumExampleConverter))]
        public enum EnumExample
        {
            Foo,
            Bar,
        }

        public class EnumExampleConverter : EnumConverter<EnumExample>
        {
            public override EnumExample ReadVariant(string? name) => name switch
            {
                "Foo" => EnumExample.Foo,
                "Bar" => EnumExample.Bar,
                null => DebugAndThrow($"Variant cannot be null for 'EnumExample'"),
                _ => DebugAndThrow($"Invalid variant '{name}' for 'EnumExample'"),
            };

            public override string WriteVariant(EnumExample value) => value switch
            {
                EnumExample.Foo => "Foo",
                EnumExample.Bar => "Bar",
                _ => throw new ArgumentOutOfRangeException("EnumExample"),
            };
        }

        [TestMethod]
        public void VariantFoo()
        {
            var expected = @"""Foo""";
            var value = JsonSerializer.Deserialize<EnumExample>(expected);
            Assert.AreEqual(value, EnumExample.Foo);
            var actual = JsonSerializer.Serialize(value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VariantBar()
        {
            var expected = @"""Bar""";
            var value = JsonSerializer.Deserialize<EnumExample>(expected);
            Assert.AreEqual(value, EnumExample.Bar);
            var actual = JsonSerializer.Serialize(value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VariantInvalidSerialize()
        {
            var invalid = (EnumExample)100;
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => JsonSerializer.Serialize(invalid));
        }

        [DataRow(@"""Baz""")]
        [DataRow(@"null")]
        [DataRow(@"0")]
        [DataRow(@"[]")]
        [DataRow(@"{}")]
        [DataRow(@"true")]
        [DataRow(@"false")]
        [DataTestMethod]
        public void VariantInvalidDeserialize(string json)
        {
            Assert.ThrowsException<JsonException>(
                () => JsonSerializer.Deserialize<EnumExample>(json));
        }
    }
}
