using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class RotateStateConverter : Mech3DotNet.Json.Converters.UnionConverter<Mech3DotNet.Json.Anim.Events.RotateState>
    {
        public override Mech3DotNet.Json.Anim.Events.RotateState ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "AtNodeXYZ":
                    {
                        var inner = new Mech3DotNet.Json.Anim.Events.RotateState.AtNodeXYZ();
                        return new Mech3DotNet.Json.Anim.Events.RotateState(inner);
                    }
                case "AtNodeMatrix":
                    {
                        var inner = new Mech3DotNet.Json.Anim.Events.RotateState.AtNodeMatrix();
                        return new Mech3DotNet.Json.Anim.Events.RotateState(inner);
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

        public override Mech3DotNet.Json.Anim.Events.RotateState ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Absolute":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Types.Vec3>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Events.RotateState(inner);
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

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.RotateState value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case Mech3DotNet.Json.Anim.Events.RotateStateVariant.Absolute:
                    {
                        var inner = value.As<Mech3DotNet.Json.Types.Vec3>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Absolute");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.RotateStateVariant.AtNodeXYZ:
                    {
                        writer.WriteStringValue("AtNodeXYZ");
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.RotateStateVariant.AtNodeMatrix:
                    {
                        writer.WriteStringValue("AtNodeMatrix");
                        break;
                    }
                default:
                    throw new System.ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'RotateState'");
            }
        }
    }
}
