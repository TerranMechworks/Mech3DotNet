using System.Text.Json;

namespace Mech3DotNet.Json.Nodes.Mw.Converters
{
    public class NodeMwConverter : Mech3DotNet.Json.Converters.UnionConverter<Mech3DotNet.Json.Nodes.Mw.NodeMw>
    {
        public override Mech3DotNet.Json.Nodes.Mw.NodeMw ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "Camera":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Camera' for 'NodeMw'");
                        throw new JsonException();
                    }
                case "Display":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Display' for 'NodeMw'");
                        throw new JsonException();
                    }
                case "Empty":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Empty' for 'NodeMw'");
                        throw new JsonException();
                    }
                case "Light":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Light' for 'NodeMw'");
                        throw new JsonException();
                    }
                case "Lod":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Lod' for 'NodeMw'");
                        throw new JsonException();
                    }
                case "Object3d":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Object3d' for 'NodeMw'");
                        throw new JsonException();
                    }
                case "Window":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Window' for 'NodeMw'");
                        throw new JsonException();
                    }
                case "World":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'World' for 'NodeMw'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'NodeMw'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'NodeMw'");
                        throw new JsonException();
                    }
            }
        }

        public override Mech3DotNet.Json.Nodes.Mw.NodeMw ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Camera":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Nodes.Mw.Camera>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Camera' was null for 'NodeMw'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Nodes.Mw.NodeMw(inner);
                    }
                case "Display":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Nodes.Mw.Display>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Display' was null for 'NodeMw'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Nodes.Mw.NodeMw(inner);
                    }
                case "Empty":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Nodes.Mw.Empty>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Empty' was null for 'NodeMw'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Nodes.Mw.NodeMw(inner);
                    }
                case "Light":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Nodes.Mw.Light>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Light' was null for 'NodeMw'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Nodes.Mw.NodeMw(inner);
                    }
                case "Lod":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Nodes.Mw.Lod>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Lod' was null for 'NodeMw'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Nodes.Mw.NodeMw(inner);
                    }
                case "Object3d":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Nodes.Mw.Object3d>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Object3d' was null for 'NodeMw'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Nodes.Mw.NodeMw(inner);
                    }
                case "Window":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Nodes.Mw.Window>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Window' was null for 'NodeMw'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Nodes.Mw.NodeMw(inner);
                    }
                case "World":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Nodes.Mw.World>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'World' was null for 'NodeMw'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Nodes.Mw.NodeMw(inner);
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'NodeMw'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'NodeMw'");
                        throw new JsonException();
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Nodes.Mw.NodeMw value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case Mech3DotNet.Json.Nodes.Mw.NodeMwVariant.Camera:
                    {
                        var inner = value.As<Mech3DotNet.Json.Nodes.Mw.Camera>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Camera");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Nodes.Mw.NodeMwVariant.Display:
                    {
                        var inner = value.As<Mech3DotNet.Json.Nodes.Mw.Display>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Display");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Nodes.Mw.NodeMwVariant.Empty:
                    {
                        var inner = value.As<Mech3DotNet.Json.Nodes.Mw.Empty>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Empty");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Nodes.Mw.NodeMwVariant.Light:
                    {
                        var inner = value.As<Mech3DotNet.Json.Nodes.Mw.Light>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Light");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Nodes.Mw.NodeMwVariant.Lod:
                    {
                        var inner = value.As<Mech3DotNet.Json.Nodes.Mw.Lod>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Lod");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Nodes.Mw.NodeMwVariant.Object3d:
                    {
                        var inner = value.As<Mech3DotNet.Json.Nodes.Mw.Object3d>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Object3d");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Nodes.Mw.NodeMwVariant.Window:
                    {
                        var inner = value.As<Mech3DotNet.Json.Nodes.Mw.Window>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Window");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Nodes.Mw.NodeMwVariant.World:
                    {
                        var inner = value.As<Mech3DotNet.Json.Nodes.Mw.World>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("World");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new System.ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'NodeMw'");
            }
        }
    }
}
