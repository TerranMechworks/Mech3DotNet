using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class IfConverter : UnionConverter<If>
    {
        public override If ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "RandomWeight":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'RandomWeight' for 'If'");
                        throw new JsonException();
                    }
                case "PlayerRange":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'PlayerRange' for 'If'");
                        throw new JsonException();
                    }
                case "AnimationLod":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'AnimationLod' for 'If'");
                        throw new JsonException();
                    }
                case "HwRender":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'HwRender' for 'If'");
                        throw new JsonException();
                    }
                case "PlayerFirstPerson":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'PlayerFirstPerson' for 'If'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'If'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'If'");
                        throw new JsonException();
                    }
            }
        }

        public override If ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "RandomWeight":
                    {
                        var inner = JsonSerializer.Deserialize<RandomWeightCond>(ref reader, options);
                        return new If(inner);
                    }
                case "PlayerRange":
                    {
                        var inner = JsonSerializer.Deserialize<PlayerRangeCond>(ref reader, options);
                        return new If(inner);
                    }
                case "AnimationLod":
                    {
                        var inner = JsonSerializer.Deserialize<AnimationLodCond>(ref reader, options);
                        return new If(inner);
                    }
                case "HwRender":
                    {
                        var inner = JsonSerializer.Deserialize<HwRenderCond>(ref reader, options);
                        return new If(inner);
                    }
                case "PlayerFirstPerson":
                    {
                        var inner = JsonSerializer.Deserialize<PlayerFirstPersonCond>(ref reader, options);
                        return new If(inner);
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'If'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'If'");
                        throw new JsonException();
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, If value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case IfVariant.RandomWeight:
                    {
                        var inner = value.As<RandomWeightCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("RandomWeight");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case IfVariant.PlayerRange:
                    {
                        var inner = value.As<PlayerRangeCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("PlayerRange");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case IfVariant.AnimationLod:
                    {
                        var inner = value.As<AnimationLodCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("AnimationLod");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case IfVariant.HwRender:
                    {
                        var inner = value.As<HwRenderCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("HwRender");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case IfVariant.PlayerFirstPerson:
                    {
                        var inner = value.As<PlayerFirstPersonCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("PlayerFirstPerson");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'If'");
            }
        }
    }
}
