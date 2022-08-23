using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class CallAnimationParametersConverter : UnionConverter<CallAnimationParameters>
    {
        public override CallAnimationParameters ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "None":
                    {
                        var inner = new CallAnimationParameters.None();
                        return new CallAnimationParameters(inner);
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

        public override CallAnimationParameters ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "AtNode":
                    {
                        var inner = JsonSerializer.Deserialize<CallAnimationAtNode>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'AtNode' was null for 'CallAnimationParameters'");
                            throw new JsonException();
                        }
                        return new CallAnimationParameters(inner);
                    }
                case "WithNode":
                    {
                        var inner = JsonSerializer.Deserialize<CallAnimationWithNode>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'WithNode' was null for 'CallAnimationParameters'");
                            throw new JsonException();
                        }
                        return new CallAnimationParameters(inner);
                    }
                case "TargetNode":
                    {
                        var inner = JsonSerializer.Deserialize<CallAnimationTargetNode>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'TargetNode' was null for 'CallAnimationParameters'");
                            throw new JsonException();
                        }
                        return new CallAnimationParameters(inner);
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

        public override void Write(Utf8JsonWriter writer, CallAnimationParameters value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case CallAnimationParametersVariant.AtNode:
                    {
                        var inner = value.As<CallAnimationAtNode>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("AtNode");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case CallAnimationParametersVariant.WithNode:
                    {
                        var inner = value.As<CallAnimationWithNode>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("WithNode");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case CallAnimationParametersVariant.TargetNode:
                    {
                        var inner = value.As<CallAnimationTargetNode>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("TargetNode");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case CallAnimationParametersVariant.None:
                    {
                        writer.WriteStringValue("None");
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'CallAnimationParameters'");
            }
        }
    }
}
