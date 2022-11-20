using System.Text.Json;

namespace Mech3DotNet.Json.Gamez.Converters
{
    public class GameZMwDataConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Gamez.GameZMwData>
    {
        protected override Mech3DotNet.Json.Gamez.GameZMwData ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var texturesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<string>>();
            var materialsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Materials.Material>>();
            var meshesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Mw.MeshMw>>();
            var nodesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Mech3DotNet.Json.Nodes.Mw.NodeMw>>();
            var metadataField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Gamez.GameZMwMetadata>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "textures":
                        {
                            System.Collections.Generic.List<string>? __value = ReadFieldValue<System.Collections.Generic.List<string>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'textures' was null for 'GameZMwData'");
                                throw new JsonException();
                            }
                            texturesField.Set(__value);
                            break;
                        }
                    case "materials":
                        {
                            System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Materials.Material>? __value = ReadFieldValue<System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Materials.Material>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'materials' was null for 'GameZMwData'");
                                throw new JsonException();
                            }
                            materialsField.Set(__value);
                            break;
                        }
                    case "meshes":
                        {
                            System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Mw.MeshMw>? __value = ReadFieldValue<System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Mw.MeshMw>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'meshes' was null for 'GameZMwData'");
                                throw new JsonException();
                            }
                            meshesField.Set(__value);
                            break;
                        }
                    case "nodes":
                        {
                            System.Collections.Generic.List<Mech3DotNet.Json.Nodes.Mw.NodeMw>? __value = ReadFieldValue<System.Collections.Generic.List<Mech3DotNet.Json.Nodes.Mw.NodeMw>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'nodes' was null for 'GameZMwData'");
                                throw new JsonException();
                            }
                            nodesField.Set(__value);
                            break;
                        }
                    case "metadata":
                        {
                            Mech3DotNet.Json.Gamez.GameZMwMetadata? __value = ReadFieldValue<Mech3DotNet.Json.Gamez.GameZMwMetadata?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'metadata' was null for 'GameZMwData'");
                                throw new JsonException();
                            }
                            metadataField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'GameZMwData'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var textures = texturesField.Unwrap("textures");
            var materials = materialsField.Unwrap("materials");
            var meshes = meshesField.Unwrap("meshes");
            var nodes = nodesField.Unwrap("nodes");
            var metadata = metadataField.Unwrap("metadata");
            return new Mech3DotNet.Json.Gamez.GameZMwData(textures, materials, meshes, nodes, metadata);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Gamez.GameZMwData value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("textures");
            JsonSerializer.Serialize(writer, value.textures, options);
            writer.WritePropertyName("materials");
            JsonSerializer.Serialize(writer, value.materials, options);
            writer.WritePropertyName("meshes");
            JsonSerializer.Serialize(writer, value.meshes, options);
            writer.WritePropertyName("nodes");
            JsonSerializer.Serialize(writer, value.nodes, options);
            writer.WritePropertyName("metadata");
            JsonSerializer.Serialize(writer, value.metadata, options);
            writer.WriteEndObject();
        }
    }
}
