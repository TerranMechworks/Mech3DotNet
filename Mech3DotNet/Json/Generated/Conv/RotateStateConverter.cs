using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class RotateStateConverter : UnionConverter<RotateState>
    {
        public override RotateState ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "AtNodeXYZ":
                    {
                        var inner = new RotateState.AtNodeXYZ();
                        return new RotateState(inner);
                    }
                case "AtNodeMatrix":
                    {
                        var inner = new RotateState.AtNodeMatrix();
                        return new RotateState(inner);
                    }
                case "Absolute":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Absolute' for 'RotateState'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'RotateState'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'RotateState'");
                        throw new JsonException();
                    }
            }
        }

        public override RotateState ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Absolute":
                    {
                        var inner = JsonSerializer.Deserialize<Vec3>(ref reader, options);
                        return new RotateState(inner);
                    }
                case "AtNodeXYZ":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid struct variant 'AtNodeXYZ' for 'RotateState'");
                        throw new JsonException();
                    }
                case "AtNodeMatrix":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid struct variant 'AtNodeMatrix' for 'RotateState'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'RotateState'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'RotateState'");
                        throw new JsonException();
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, RotateState value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case RotateStateVariant.Absolute:
                    {
                        var inner = value.As<Vec3>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Absolute");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case RotateStateVariant.AtNodeXYZ:
                    {
                        writer.WriteStringValue("AtNodeXYZ");
                        break;
                    }
                case RotateStateVariant.AtNodeMatrix:
                    {
                        writer.WriteStringValue("AtNodeMatrix");
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'RotateState'");
            }
        }
    }
}
