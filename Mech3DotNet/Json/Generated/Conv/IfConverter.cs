using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class IfConverter : Mech3DotNet.Json.Converters.UnionConverter<Mech3DotNet.Json.Anim.Events.If>
    {
        public override Mech3DotNet.Json.Anim.Events.If ReadUnitVariant(string? name)
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

        public override Mech3DotNet.Json.Anim.Events.If ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "RandomWeight":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.RandomWeightCond>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Events.If(inner);
                    }
                case "PlayerRange":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.PlayerRangeCond>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Events.If(inner);
                    }
                case "AnimationLod":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.AnimationLodCond>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Events.If(inner);
                    }
                case "HwRender":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.HwRenderCond>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Events.If(inner);
                    }
                case "PlayerFirstPerson":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.PlayerFirstPersonCond>(ref reader, options);
                        return new Mech3DotNet.Json.Anim.Events.If(inner);
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

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.If value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case Mech3DotNet.Json.Anim.Events.IfVariant.RandomWeight:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.RandomWeightCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("RandomWeight");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.IfVariant.PlayerRange:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.PlayerRangeCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("PlayerRange");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.IfVariant.AnimationLod:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.AnimationLodCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("AnimationLod");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.IfVariant.HwRender:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.HwRenderCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("HwRender");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.IfVariant.PlayerFirstPerson:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.PlayerFirstPersonCond>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("PlayerFirstPerson");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new System.ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'If'");
            }
        }
    }
}
