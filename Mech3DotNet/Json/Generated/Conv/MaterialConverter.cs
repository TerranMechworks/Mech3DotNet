using System.Text.Json;

namespace Mech3DotNet.Json.Gamez.Materials.Converters
{
    public class MaterialConverter : Mech3DotNet.Json.Converters.UnionConverter<Mech3DotNet.Json.Gamez.Materials.Material>
    {
        public override Mech3DotNet.Json.Gamez.Materials.Material ReadUnitVariant(string? name)
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

        public override Mech3DotNet.Json.Gamez.Materials.Material ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Textured":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Gamez.Materials.TexturedMaterial>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Textured' was null for 'Material'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Gamez.Materials.Material(inner);
                    }
                case "Colored":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Gamez.Materials.ColoredMaterial>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Colored' was null for 'Material'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Gamez.Materials.Material(inner);
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

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Gamez.Materials.Material value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case Mech3DotNet.Json.Gamez.Materials.MaterialVariant.Textured:
                    {
                        var inner = value.As<Mech3DotNet.Json.Gamez.Materials.TexturedMaterial>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Textured");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Gamez.Materials.MaterialVariant.Colored:
                    {
                        var inner = value.As<Mech3DotNet.Json.Gamez.Materials.ColoredMaterial>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Colored");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new System.ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'Material'");
            }
        }
    }
}
