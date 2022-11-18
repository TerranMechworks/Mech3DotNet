using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ElseIfConverter : Mech3DotNet.Json.Converters.UnionConverter<ElseIf>
    {
        public override ElseIf ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "RandomWeight":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'RandomWeight' for 'ElseIf'");
                        throw new JsonException();
                    }
                case "PlayerRange":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'PlayerRange' for 'ElseIf'");
                        throw new JsonException();
                    }
                case "AnimationLod":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'AnimationLod' for 'ElseIf'");
                        throw new JsonException();
                    }
                case "HwRender":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'HwRender' for 'ElseIf'");
                        throw new JsonException();
                    }
                case "PlayerFirstPerson":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'PlayerFirstPerson' for 'ElseIf'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'ElseIf'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'ElseIf'");
                        throw new JsonException();
                    }
            }
        }

        public override ElseIf ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "RandomWeight":
                    {
                        var inner = JsonSerializer.Deserialize<RandomWeightCond>(ref reader, options);
                        return new ElseIf(inner);
                    }
                case "PlayerRange":
                    {
                        var inner = JsonSerializer.Deserialize<PlayerRangeCond>(ref reader, options);
                        return new ElseIf(inner);
                    }
                case "AnimationLod":
                    {
                        var inner = JsonSerializer.Deserialize<AnimationLodCond>(ref reader, options);
                        return new ElseIf(inner);
                    }
                case "HwRender":
                    {
                        var inner = JsonSerializer.Deserialize<HwRenderCond>(ref reader, options);
                        return new ElseIf(inner);
                    }
                case "PlayerFirstPerson":
                    {
                        var inner = JsonSerializer.Deserialize<PlayerFirstPersonCond>(ref reader, options);
                        return new ElseIf(inner);
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'ElseIf'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'ElseIf'");
                        throw new JsonException();
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, ElseIf value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case ElseIfVariant.RandomWeight:
                    {
                        var inner = value.As<RandomWeightCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("RandomWeight");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case ElseIfVariant.PlayerRange:
                    {
                        var inner = value.As<PlayerRangeCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("PlayerRange");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case ElseIfVariant.AnimationLod:
                    {
                        var inner = value.As<AnimationLodCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("AnimationLod");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case ElseIfVariant.HwRender:
                    {
                        var inner = value.As<HwRenderCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("HwRender");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case ElseIfVariant.PlayerFirstPerson:
                    {
                        var inner = value.As<PlayerFirstPersonCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("PlayerFirstPerson");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new System.ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'ElseIf'");
            }
        }
    }
}
