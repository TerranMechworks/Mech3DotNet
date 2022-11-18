using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class GameZCsDataConverter : StructConverter<GameZCsData>
    {
        protected override GameZCsData ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var texturesField = new Option<List<string>>();
            var materialsField = new Option<List<Material>>();
            var meshesField = new Option<List<MeshNg?>>();
            var nodesField = new Option<byte[]>();
            var metadataField = new Option<GameZCsMetadata>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "textures":
                        {
                            List<string>? __value = ReadFieldValue<List<string>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'textures' was null for 'GameZCsData'");
                                throw new JsonException();
                            }
                            texturesField.Set(__value);
                            break;
                        }
                    case "materials":
                        {
                            List<Material>? __value = ReadFieldValue<List<Material>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'materials' was null for 'GameZCsData'");
                                throw new JsonException();
                            }
                            materialsField.Set(__value);
                            break;
                        }
                    case "meshes":
                        {
                            List<MeshNg?>? __value = ReadFieldValue<List<MeshNg?>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'meshes' was null for 'GameZCsData'");
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
                            GameZCsMetadata? __value = ReadFieldValue<GameZCsMetadata?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'metadata' was null for 'GameZCsData'");
                                throw new JsonException();
                            }
                            metadataField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'GameZCsData'");
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
            return new GameZCsData(textures, materials, meshes, nodes, metadata);
        }

        public override void Write(Utf8JsonWriter writer, GameZCsData value, JsonSerializerOptions options)
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
