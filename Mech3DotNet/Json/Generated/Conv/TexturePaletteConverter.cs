using System.Text.Json;

namespace Mech3DotNet.Json.Image.Converters
{
    public class TexturePaletteConverter : Mech3DotNet.Json.Converters.UnionConverter<Mech3DotNet.Json.Image.TexturePalette>
    {
        public override Mech3DotNet.Json.Image.TexturePalette ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "None":
                    {
                        var inner = new Mech3DotNet.Json.Image.TexturePalette.None();
                        return new Mech3DotNet.Json.Image.TexturePalette(inner);
                    }
                case "Local":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Local' for 'TexturePalette'");
                        throw new JsonException();
                    }
                case "Global":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Global' for 'TexturePalette'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'TexturePalette'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'TexturePalette'");
                        throw new JsonException();
                    }
            }
        }

        public override Mech3DotNet.Json.Image.TexturePalette ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Local":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Image.PaletteData>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Local' was null for 'TexturePalette'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Image.TexturePalette(inner);
                    }
                case "Global":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Image.GlobalPalette>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Global' was null for 'TexturePalette'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Image.TexturePalette(inner);
                    }
                case "None":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid struct variant 'None' for 'TexturePalette'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'TexturePalette'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'TexturePalette'");
                        throw new JsonException();
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Image.TexturePalette value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case Mech3DotNet.Json.Image.TexturePaletteVariant.None:
                    {
                        writer.WriteStringValue("None");
                        break;
                    }
                case Mech3DotNet.Json.Image.TexturePaletteVariant.Local:
                    {
                        var inner = value.As<Mech3DotNet.Json.Image.PaletteData>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Local");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Image.TexturePaletteVariant.Global:
                    {
                        var inner = value.As<Mech3DotNet.Json.Image.GlobalPalette>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Global");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new System.ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'TexturePalette'");
            }
        }
    }
}
