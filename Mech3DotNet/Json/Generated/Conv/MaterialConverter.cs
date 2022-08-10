using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class MaterialConverter : UnionConverter<Material>
    {
        public override Material ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "Textured":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Textured' for 'Material'");
                        throw new JsonException();
                    }
                case "Colored":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Colored' for 'Material'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'Material'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'Material'");
                        throw new JsonException();
                    }
            }
        }

        public override Material ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Textured":
                    {
                        var inner = JsonSerializer.Deserialize<TexturedMaterial>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Textured' was null for 'Material'");
                            throw new JsonException();
                        }
                        return new Material(inner);
                    }
                case "Colored":
                    {
                        var inner = JsonSerializer.Deserialize<ColoredMaterial>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Colored' was null for 'Material'");
                            throw new JsonException();
                        }
                        return new Material(inner);
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'Material'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'Material'");
                        throw new JsonException();
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, Material value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case MaterialVariant.Textured:
                    {
                        var inner = value.As<TexturedMaterial>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Textured");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case MaterialVariant.Colored:
                    {
                        var inner = value.As<ColoredMaterial>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Colored");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'Material'");
            }
        }
    }
}
