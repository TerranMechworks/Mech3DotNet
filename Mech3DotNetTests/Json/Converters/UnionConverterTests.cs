using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mech3DotNetTests.Json.Converters
{
    [TestClass]
    public class UnionConverterTests
    {
        public enum ExampleUnionVariant
        {
            Foo,
            Bar,
        }

        [JsonConverter(typeof(ExampleUnionConverter))]
        public class ExampleUnion : IDiscriminatedUnion<ExampleUnionVariant>
        {
            public sealed class Bar
            {
                public Bar() { }
            }

            public sealed class Foo
            {
                public int Value { get; set; }
                public Foo() { }
            }

            public ExampleUnion(Foo value)
            {
                this.value = value;
                Variant = ExampleUnionVariant.Foo;
            }

            public ExampleUnion(Bar value)
            {
                this.value = value;
                Variant = ExampleUnionVariant.Bar;
            }

            protected object value;
            public ExampleUnionVariant Variant { get; protected set; }
            public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
            public T As<T>() { return (T)value; }
            public object GetValue() { return value; }
        }

        public class ExampleUnionConverter : UnionConverter<ExampleUnion>
        {
            public override ExampleUnion ReadUnitVariant(string? name)
            {
                switch (name)
                {
                    case "Bar":
                        {
                            var inner = new ExampleUnion.Bar();
                            return new ExampleUnion(inner);
                        }
                    case "Foo":
                        {
                            System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Foo' for 'ExampleUnion'");
                            throw new JsonException();
                        }
                    case null:
                        {
                            System.Diagnostics.Debug.WriteLine("Variant for 'ExampleUnion' cannot be null");
                            throw new JsonException();
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'ExampleUnion'");
                            throw new JsonException();
                        }
                }
            }

            public override ExampleUnion ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
            {
                switch (name)
                {
                    case "Foo":
                        {
                            var inner = JsonSerializer.Deserialize<ExampleUnion.Foo>(ref reader, options);
                            if (inner is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Data of variant 'Foo' for 'ExampleUnion' cannot be null");
                                throw new JsonException();
                            }
                            return new ExampleUnion(inner);
                        }
                    case "Bar":
                        {
                            System.Diagnostics.Debug.WriteLine("Invalid struct variant 'Bar' for 'ExampleUnion'");
                            throw new JsonException();
                        }
                    case null:
                        {
                            System.Diagnostics.Debug.WriteLine("Variant for 'ExampleUnion' cannot be null");
                            throw new JsonException();
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'ExampleUnion'");
                            throw new JsonException();
                        }
                }
            }

            public override void Write(Utf8JsonWriter writer, ExampleUnion value, JsonSerializerOptions options)
            {
                switch (value.Variant)
                {
                    case ExampleUnionVariant.Bar:
                        {
                            writer.WriteStringValue("Bar");
                            break;
                        }
                    case ExampleUnionVariant.Foo:
                        {
                            var inner = value.As<ExampleUnion.Foo>();
                            writer.WriteStartObject();
                            writer.WritePropertyName("Foo");
                            JsonSerializer.Serialize(writer, inner, options);
                            writer.WriteEndObject();
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'ExampleUnion'");
                }
            }
        }

        [TestMethod]
        public void VariantFoo()
        {
            var expected = @"{""Foo"":{""Value"":42}}";
            var test = JsonSerializer.Deserialize<ExampleUnion>(expected);
            Assert.IsNotNull(test);
            Assert.IsInstanceOfType(test.GetValue(), typeof(ExampleUnion.Foo));

            Assert.IsTrue(test.Is<ExampleUnion.Foo>());
            Assert.IsFalse(test.Is<ExampleUnion.Bar>());
            Assert.ThrowsException<InvalidCastException>(() => test.As<ExampleUnion.Bar>());
            var foo = test.As<ExampleUnion.Foo>();
            Assert.AreEqual(42, foo.Value);

            var actual = JsonSerializer.Serialize(test);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VariantBar()
        {
            var expected = @"""Bar""";
            var test = JsonSerializer.Deserialize<ExampleUnion>(expected);
            Assert.IsNotNull(test);
            Assert.IsInstanceOfType(test.GetValue(), typeof(ExampleUnion.Bar));

            Assert.IsTrue(test.Is<ExampleUnion.Bar>());
            Assert.IsFalse(test.Is<ExampleUnion.Foo>());
            var bar = test.As<ExampleUnion.Bar>();
            Assert.IsNotNull(bar);
            Assert.ThrowsException<InvalidCastException>(() => test.As<ExampleUnion.Foo>());

            var actual = JsonSerializer.Serialize(test);
            Assert.AreEqual(expected, actual);
        }

        private static void AssertJsonException(string json)
        {
            Assert.ThrowsException<JsonException>(
                () => JsonSerializer.Deserialize<ExampleUnion>(json));
        }

        [TestMethod]
        public void Deserialize_RequiresValues_Throws()
        {
            AssertJsonException(@"""Foo""");
        }

        [TestMethod]
        public void Deserialize_RequiresNoValues_Throws()
        {
            AssertJsonException(@"{""Bar"":null}");
        }

        [TestMethod]
        public void Deserialize_InvalidStart_Throws()
        {
            AssertJsonException(@"[");
        }

        [TestMethod]
        public void Deserialize_IncompleteObjectAfterStart_Throws()
        {
            AssertJsonException(@"{");
        }

        [TestMethod]
        public void Deserialize_IncompleteObjectAfterProp_Throws()
        {
            AssertJsonException(@"{""Foo""");
        }

        [TestMethod]
        public void Deserialize_InvalidDiscriminant_Throws()
        {
            AssertJsonException(@"{""Baz"":");
        }

        [TestMethod]
        public void Deserialize_IncompleteObjectAfterColon_Throws()
        {
            AssertJsonException(@"{""Foo"":");
        }

        [TestMethod]
        public void Deserialize_IncompleteObjectAfterComma_Throws()
        {
            AssertJsonException(@"{""Foo"":,");
        }

        [TestMethod]
        public void Deserialize_IncompleteObjectAfterObject_Throws()
        {
            AssertJsonException(@"{""Foo"":{""Value"":42}");
        }

        [TestMethod]
        public void Deserialize_InvalidEnd_Throws()
        {
            AssertJsonException(@"{""Foo"":{""Value"":42}]");
        }

        [TestMethod]
        public void Deserialize_ExtraDiscriminant_Throws()
        {
            AssertJsonException(@"{""Foo"":{""Value"":42}, ""Bar"":");
        }

        [TestMethod]
        public void Deserialize_InvalidType_Throws()
        {
            AssertJsonException(@"{""Foo"":1");
        }
    }
}
