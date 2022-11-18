using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class ElseIfConverter : Mech3DotNet.Json.Converters.UnionConverter<Mech3DotNet.Json.Anim.Events.ElseIf>
    {
        public override Mech3DotNet.Json.Anim.Events.ElseIf ReadUnitVariant(string? name)
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

        public override Mech3DotNet.Json.Anim.Events.ElseIf ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "RandomWeight":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.RandomWeightCond>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Events.ElseIf(inner);
                    }
                case "PlayerRange":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.PlayerRangeCond>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Events.ElseIf(inner);
                    }
                case "AnimationLod":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.AnimationLodCond>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Events.ElseIf(inner);
                    }
                case "HwRender":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.HwRenderCond>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Events.ElseIf(inner);
                    }
                case "PlayerFirstPerson":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.PlayerFirstPersonCond>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Events.ElseIf(inner);
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

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.ElseIf value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case Mech3DotNet.Json.Anim.Events.ElseIfVariant.RandomWeight:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.RandomWeightCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("RandomWeight");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.ElseIfVariant.PlayerRange:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.PlayerRangeCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("PlayerRange");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.ElseIfVariant.AnimationLod:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.AnimationLodCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("AnimationLod");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.ElseIfVariant.HwRender:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.HwRenderCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("HwRender");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.ElseIfVariant.PlayerFirstPerson:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.PlayerFirstPersonCond>();
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
