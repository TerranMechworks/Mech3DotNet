using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Converters
{
    public class ActivationPrereqConverter : Mech3DotNet.Json.Converters.UnionConverter<Mech3DotNet.Json.Anim.ActivationPrereq>
    {
        public override Mech3DotNet.Json.Anim.ActivationPrereq ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "Animation":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Animation' for 'ActivationPrereq'");
                        throw new JsonException();
                    }
                case "Parent":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Parent' for 'ActivationPrereq'");
                        throw new JsonException();
                    }
                case "Object":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Object' for 'ActivationPrereq'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'ActivationPrereq'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'ActivationPrereq'");
                        throw new JsonException();
                    }
            }
        }

        public override Mech3DotNet.Json.Anim.ActivationPrereq ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Animation":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.PrereqAnimation>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.ActivationPrereq(inner);
                    }
                case "Parent":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.PrereqParent>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.ActivationPrereq(inner);
                    }
                case "Object":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.PrereqObject>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.ActivationPrereq(inner);
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'ActivationPrereq'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'ActivationPrereq'");
                        throw new JsonException();
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.ActivationPrereq value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case Mech3DotNet.Json.Anim.ActivationPrereqVariant.Animation:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.PrereqAnimation>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Animation");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.ActivationPrereqVariant.Parent:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.PrereqParent>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Parent");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.ActivationPrereqVariant.Object:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.PrereqObject>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Object");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new System.ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'ActivationPrereq'");
            }
        }
    }
}
