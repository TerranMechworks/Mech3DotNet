using System.Text.Json;

namespace Mech3DotNet.Json.Gamez.Nodes.Converters
{
    public class NodePmConverter : Mech3DotNet.Json.Converters.UnionConverter<Mech3DotNet.Json.Gamez.Nodes.NodePm>
    {
        public override Mech3DotNet.Json.Gamez.Nodes.NodePm ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "Lod":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Lod' for 'NodePm'");
                        throw new JsonException();
                    }
                case "Object3d":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Object3d' for 'NodePm'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'NodePm'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'NodePm'");
                        throw new JsonException();
                    }
            }
        }

        public override Mech3DotNet.Json.Gamez.Nodes.NodePm ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Lod":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Gamez.Nodes.LodPm>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Lod' was null for 'NodePm'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Gamez.Nodes.NodePm(inner);
                    }
                case "Object3d":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Gamez.Nodes.Object3dPm>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Object3d' was null for 'NodePm'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Gamez.Nodes.NodePm(inner);
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'NodePm'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'NodePm'");
                        throw new JsonException();
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Gamez.Nodes.NodePm value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case Mech3DotNet.Json.Gamez.Nodes.NodePmVariant.Lod:
                    {
                        var inner = value.As<Mech3DotNet.Json.Gamez.Nodes.LodPm>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Lod");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Gamez.Nodes.NodePmVariant.Object3d:
                    {
                        var inner = value.As<Mech3DotNet.Json.Gamez.Nodes.Object3dPm>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Object3d");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new System.ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'NodePm'");
            }
        }
    }
}
