using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class NodeConverter : UnionConverter<Node>
    {
        public override Node ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "Camera":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Camera' for 'Node'");
                        throw new JsonException();
                    }
                case "Display":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Display' for 'Node'");
                        throw new JsonException();
                    }
                case "Empty":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Empty' for 'Node'");
                        throw new JsonException();
                    }
                case "Light":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Light' for 'Node'");
                        throw new JsonException();
                    }
                case "Lod":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Lod' for 'Node'");
                        throw new JsonException();
                    }
                case "Object3d":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Object3d' for 'Node'");
                        throw new JsonException();
                    }
                case "Window":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Window' for 'Node'");
                        throw new JsonException();
                    }
                case "World":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'World' for 'Node'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'Node'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'Node'");
                        throw new JsonException();
                    }
            }
        }

        public override Node ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Camera":
                    {
                        var inner = JsonSerializer.Deserialize<Camera>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Camera' was null for 'Node'");
                            throw new JsonException();
                        }
                        return new Node(inner);
                    }
                case "Display":
                    {
                        var inner = JsonSerializer.Deserialize<Display>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Display' was null for 'Node'");
                            throw new JsonException();
                        }
                        return new Node(inner);
                    }
                case "Empty":
                    {
                        var inner = JsonSerializer.Deserialize<Empty>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Empty' was null for 'Node'");
                            throw new JsonException();
                        }
                        return new Node(inner);
                    }
                case "Light":
                    {
                        var inner = JsonSerializer.Deserialize<Light>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Light' was null for 'Node'");
                            throw new JsonException();
                        }
                        return new Node(inner);
                    }
                case "Lod":
                    {
                        var inner = JsonSerializer.Deserialize<Lod>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Lod' was null for 'Node'");
                            throw new JsonException();
                        }
                        return new Node(inner);
                    }
                case "Object3d":
                    {
                        var inner = JsonSerializer.Deserialize<Object3d>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Object3d' was null for 'Node'");
                            throw new JsonException();
                        }
                        return new Node(inner);
                    }
                case "Window":
                    {
                        var inner = JsonSerializer.Deserialize<Window>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Window' was null for 'Node'");
                            throw new JsonException();
                        }
                        return new Node(inner);
                    }
                case "World":
                    {
                        var inner = JsonSerializer.Deserialize<World>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'World' was null for 'Node'");
                            throw new JsonException();
                        }
                        return new Node(inner);
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'Node'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'Node'");
                        throw new JsonException();
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, Node value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case NodeVariant.Camera:
                    {
                        var inner = value.As<Camera>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Camera");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case NodeVariant.Display:
                    {
                        var inner = value.As<Display>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Display");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case NodeVariant.Empty:
                    {
                        var inner = value.As<Empty>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Empty");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case NodeVariant.Light:
                    {
                        var inner = value.As<Light>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Light");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case NodeVariant.Lod:
                    {
                        var inner = value.As<Lod>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Lod");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case NodeVariant.Object3d:
                    {
                        var inner = value.As<Object3d>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Object3d");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case NodeVariant.Window:
                    {
                        var inner = value.As<Window>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Window");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case NodeVariant.World:
                    {
                        var inner = value.As<World>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("World");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'Node'");
            }
        }
    }
}
