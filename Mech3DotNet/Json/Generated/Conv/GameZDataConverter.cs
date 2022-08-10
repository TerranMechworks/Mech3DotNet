using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class GameZDataConverter : StructConverter<GameZData>
    {
        protected override GameZData ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var metadataField = new Option<GameZMetadata>();
            var texturesField = new Option<List<string>>();
            var materialsField = new Option<List<Material>>();
            var meshesField = new Option<List<Mesh>>();
            var nodesField = new Option<List<Node>>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "metadata":
                        {
                            GameZMetadata? __value = ReadFieldValue<GameZMetadata?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'metadata' was null for 'GameZData'");
                                throw new JsonException();
                            }
                            metadataField.Set(__value);
                            break;
                        }
                    case "textures":
                        {
                            List<string>? __value = ReadFieldValue<List<string>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'textures' was null for 'GameZData'");
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
                                System.Diagnostics.Debug.WriteLine("Value of 'materials' was null for 'GameZData'");
                                throw new JsonException();
                            }
                            materialsField.Set(__value);
                            break;
                        }
                    case "meshes":
                        {
                            List<Mesh>? __value = ReadFieldValue<List<Mesh>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'meshes' was null for 'GameZData'");
                                throw new JsonException();
                            }
                            meshesField.Set(__value);
                            break;
                        }
                    case "nodes":
                        {
                            List<Node>? __value = ReadFieldValue<List<Node>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'nodes' was null for 'GameZData'");
                                throw new JsonException();
                            }
                            nodesField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'GameZData'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var metadata = metadataField.Unwrap("metadata");
            var textures = texturesField.Unwrap("textures");
            var materials = materialsField.Unwrap("materials");
            var meshes = meshesField.Unwrap("meshes");
            var nodes = nodesField.Unwrap("nodes");
            return new GameZData(metadata, textures, materials, meshes, nodes);
        }

        public override void Write(Utf8JsonWriter writer, GameZData value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("metadata");
            JsonSerializer.Serialize(writer, value.metadata, options);
            writer.WritePropertyName("textures");
            JsonSerializer.Serialize(writer, value.textures, options);
            writer.WritePropertyName("materials");
            JsonSerializer.Serialize(writer, value.materials, options);
            writer.WritePropertyName("meshes");
            JsonSerializer.Serialize(writer, value.meshes, options);
            writer.WritePropertyName("nodes");
            JsonSerializer.Serialize(writer, value.nodes, options);
            writer.WriteEndObject();
        }
    }
}
