using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ForwardRotationConverter : Mech3DotNet.Json.Converters.UnionConverter<ForwardRotation>
    {
        public override ForwardRotation ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "Time":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Time' for 'ForwardRotation'");
                        throw new JsonException();
                    }
                case "Distance":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Distance' for 'ForwardRotation'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'ForwardRotation'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'ForwardRotation'");
                        throw new JsonException();
                    }
            }
        }

        public override ForwardRotation ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Time":
                    {
                        var inner = JsonSerializer.Deserialize<ForwardRotationTime>(ref reader, options);
                        return new ForwardRotation(inner);
                    }
                case "Distance":
                    {
                        var inner = JsonSerializer.Deserialize<ForwardRotationDistance>(ref reader, options);
                        return new ForwardRotation(inner);
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'ForwardRotation'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'ForwardRotation'");
                        throw new JsonException();
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, ForwardRotation value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case ForwardRotationVariant.Time:
                    {
                        var inner = value.As<ForwardRotationTime>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Time");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case ForwardRotationVariant.Distance:
                    {
                        var inner = value.As<ForwardRotationDistance>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Distance");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new System.ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'ForwardRotation'");
            }
        }
    }
}
