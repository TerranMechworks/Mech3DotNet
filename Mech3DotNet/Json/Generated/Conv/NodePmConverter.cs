using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class NodePmConverter : UnionConverter<NodePm>
    {
        public override NodePm ReadUnitVariant(string? name)
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

        public override NodePm ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Lod":
                    {
                        var inner = JsonSerializer.Deserialize<LodPm>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Lod' was null for 'NodePm'");
                            throw new JsonException();
                        }
                        return new NodePm(inner);
                    }
                case "Object3d":
                    {
                        var inner = JsonSerializer.Deserialize<Object3dPm>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Object3d' was null for 'NodePm'");
                            throw new JsonException();
                        }
                        return new NodePm(inner);
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

        public override void Write(Utf8JsonWriter writer, NodePm value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case NodePmVariant.Lod:
                    {
                        var inner = value.As<LodPm>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Lod");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case NodePmVariant.Object3d:
                    {
                        var inner = value.As<Object3dPm>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Object3d");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'NodePm'");
            }
        }
    }
}
