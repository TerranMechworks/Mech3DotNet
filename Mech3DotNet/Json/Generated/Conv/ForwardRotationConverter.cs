using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class ForwardRotationConverter : Mech3DotNet.Json.Converters.UnionConverter<Mech3DotNet.Json.Anim.Events.ForwardRotation>
    {
        public override Mech3DotNet.Json.Anim.Events.ForwardRotation ReadUnitVariant(string? name)
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

        public override Mech3DotNet.Json.Anim.Events.ForwardRotation ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Time":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ForwardRotationTime>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Events.ForwardRotation(inner);
                    }
                case "Distance":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ForwardRotationDistance>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Events.ForwardRotation(inner);
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

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.ForwardRotation value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case Mech3DotNet.Json.Anim.Events.ForwardRotationVariant.Time:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ForwardRotationTime>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Time");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.ForwardRotationVariant.Distance:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ForwardRotationDistance>();
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
