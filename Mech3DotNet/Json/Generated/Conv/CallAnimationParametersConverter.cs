using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class CallAnimationParametersConverter : Mech3DotNet.Json.Converters.UnionConverter<Mech3DotNet.Json.Anim.Events.CallAnimationParameters>
    {
        public override Mech3DotNet.Json.Anim.Events.CallAnimationParameters ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "None":
                    {
                        var inner = new Mech3DotNet.Json.Anim.Events.CallAnimationParameters.None();
                        return new Mech3DotNet.Json.Anim.Events.CallAnimationParameters(inner);
                    }
                case "AtNode":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'AtNode' for 'CallAnimationParameters'");
                        throw new JsonException();
                    }
                case "WithNode":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'WithNode' for 'CallAnimationParameters'");
                        throw new JsonException();
                    }
                case "TargetNode":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'TargetNode' for 'CallAnimationParameters'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'CallAnimationParameters'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'CallAnimationParameters'");
                        throw new JsonException();
                    }
            }
        }

        public override Mech3DotNet.Json.Anim.Events.CallAnimationParameters ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "AtNode":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.CallAnimationAtNode>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'AtNode' was null for 'CallAnimationParameters'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.CallAnimationParameters(inner);
                    }
                case "WithNode":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.CallAnimationWithNode>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'WithNode' was null for 'CallAnimationParameters'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.CallAnimationParameters(inner);
                    }
                case "TargetNode":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.CallAnimationTargetNode>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'TargetNode' was null for 'CallAnimationParameters'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.CallAnimationParameters(inner);
                    }
                case "None":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid struct variant 'None' for 'CallAnimationParameters'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'CallAnimationParameters'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'CallAnimationParameters'");
                        throw new JsonException();
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.CallAnimationParameters value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case Mech3DotNet.Json.Anim.Events.CallAnimationParametersVariant.AtNode:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.CallAnimationAtNode>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("AtNode");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.CallAnimationParametersVariant.WithNode:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.CallAnimationWithNode>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("WithNode");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.CallAnimationParametersVariant.TargetNode:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.CallAnimationTargetNode>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("TargetNode");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.CallAnimationParametersVariant.None:
                    {
                        writer.WriteStringValue("None");
                        break;
                    }
                default:
                    throw new System.ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'CallAnimationParameters'");
            }
        }
    }
}
