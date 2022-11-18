using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ActivationPrereqConverter : Mech3DotNet.Json.Converters.UnionConverter<ActivationPrereq>
    {
        public override ActivationPrereq ReadUnitVariant(string? name)
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

        public override ActivationPrereq ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Animation":
                    {
                        var inner = JsonSerializer.Deserialize<PrereqAnimation>(ref reader, options);
                        return new ActivationPrereq(inner);
                    }
                case "Parent":
                    {
                        var inner = JsonSerializer.Deserialize<PrereqParent>(ref reader, options);
                        return new ActivationPrereq(inner);
                    }
                case "Object":
                    {
                        var inner = JsonSerializer.Deserialize<PrereqObject>(ref reader, options);
                        return new ActivationPrereq(inner);
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

        public override void Write(Utf8JsonWriter writer, ActivationPrereq value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case ActivationPrereqVariant.Animation:
                    {
                        var inner = value.As<PrereqAnimation>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Animation");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case ActivationPrereqVariant.Parent:
                    {
                        var inner = value.As<PrereqParent>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Parent");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case ActivationPrereqVariant.Object:
                    {
                        var inner = value.As<PrereqObject>();
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
