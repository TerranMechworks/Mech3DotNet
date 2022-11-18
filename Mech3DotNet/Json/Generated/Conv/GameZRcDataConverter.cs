using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class GameZRcDataConverter : Mech3DotNet.Json.Converters.StructConverter<GameZRcData>
    {
        protected override GameZRcData ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var texturesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<string>>();
            var materialsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Material>>();
            var meshesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<MeshRc>>();
            var nodesField = new Mech3DotNet.Json.Converters.Option<byte[]>();
            var metadataField = new Mech3DotNet.Json.Converters.Option<GameZRcMetadata>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'textures' was null for 'GameZRcData'");
                                throw new JsonException();
                            }
                            texturesField.Set(__value);
                            break;
                        }
                    case "materials":
                        {
                            System.Collections.Generic.List<Material>? __value = ReadFieldValue<System.Collections.Generic.List<Material>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'materials' was null for 'GameZRcData'");
                                throw new JsonException();
                            }
                            materialsField.Set(__value);
                            break;
                        }
                    case "meshes":
                        {
                            System.Collections.Generic.List<MeshRc>? __value = ReadFieldValue<System.Collections.Generic.List<MeshRc>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'meshes' was null for 'GameZRcData'");
                                throw new JsonException();
                            }
                            meshesField.Set(__value);
                            break;
                        }
                    case "nodes":
                        {
                            byte[] __value = ReadFieldValue<byte[]>(ref __reader, __options);
                            nodesField.Set(__value);
                            break;
                        }
                    case "metadata":
                        {
                            GameZRcMetadata? __value = ReadFieldValue<GameZRcMetadata?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'metadata' was null for 'GameZRcData'");
                                throw new JsonException();
                            }
                            metadataField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'GameZRcData'");
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
            return new GameZRcData(textures, materials, meshes, nodes, metadata);
        }

        public override void Write(Utf8JsonWriter writer, GameZRcData value, JsonSerializerOptions options)
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
