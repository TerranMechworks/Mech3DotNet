using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ExecutionConverter : UnionConverter<Execution>
    {
        public override Execution ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "ByZone":
                    {
                        var inner = new Execution.ByZone();
                        return new Execution(inner);
                    }
                case "None":
                    {
                        var inner = new Execution.None();
                        return new Execution(inner);
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

        public override Execution ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "ByRange":
                    {
                        var inner = JsonSerializer.Deserialize<Range>(ref reader, options);
                        return new Execution(inner);
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

        public override void Write(Utf8JsonWriter writer, Execution value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case ExecutionVariant.ByRange:
                    {
                        var inner = value.As<Range>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ByRange");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case ExecutionVariant.ByZone:
                    {
                        writer.WriteStringValue("ByZone");
                        break;
                    }
                case ExecutionVariant.None:
                    {
                        writer.WriteStringValue("None");
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'Execution'");
            }
        }
    }
}
