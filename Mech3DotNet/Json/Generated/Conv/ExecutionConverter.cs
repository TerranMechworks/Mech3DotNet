using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Converters
{
    public class ExecutionConverter : Mech3DotNet.Json.Converters.UnionConverter<Mech3DotNet.Json.Anim.Execution>
    {
        public override Mech3DotNet.Json.Anim.Execution ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "ByZone":
                    {
                        var inner = new Mech3DotNet.Json.Anim.Execution.ByZone();
                        return new Mech3DotNet.Json.Anim.Execution(inner);
                    }
                case "None":
                    {
                        var inner = new Mech3DotNet.Json.Anim.Execution.None();
                        return new Mech3DotNet.Json.Anim.Execution(inner);
                    }
                case "ByRange":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ByRange' for 'Execution'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'Execution'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'Execution'");
                        throw new JsonException();
                    }
            }
        }

        public override Mech3DotNet.Json.Anim.Execution ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "ByRange":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Types.Range>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Execution(inner);
                    }
                case "ByZone":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid struct variant 'ByZone' for 'Execution'");
                        throw new JsonException();
                    }
                case "None":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid struct variant 'None' for 'Execution'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'Execution'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'Execution'");
                        throw new JsonException();
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Execution value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case Mech3DotNet.Json.Anim.ExecutionVariant.ByRange:
                    {
                        var inner = value.As<Mech3DotNet.Json.Types.Range>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ByRange");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.ExecutionVariant.ByZone:
                    {
                        writer.WriteStringValue("ByZone");
                        break;
                    }
                case Mech3DotNet.Json.Anim.ExecutionVariant.None:
                    {
                        writer.WriteStringValue("None");
                        break;
                    }
                default:
                    throw new System.ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'Execution'");
            }
        }
    }
}
