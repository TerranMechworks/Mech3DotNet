using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class GameZRcMetadataConverter : StructConverter<GameZRcMetadata>
    {
        protected override GameZRcMetadata ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var materialArraySizeField = new Option<short>();
            var meshesArraySizeField = new Option<int>();
            var nodeArraySizeField = new Option<uint>();
            var nodeDataCountField = new Option<uint>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "material_array_size":
                        {
                            short __value = ReadFieldValue<short>(ref __reader, __options);
                            materialArraySizeField.Set(__value);
                            break;
                        }
                    case "meshes_array_size":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            meshesArraySizeField.Set(__value);
                            break;
                        }
                    case "node_array_size":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            nodeArraySizeField.Set(__value);
                            break;
                        }
                    case "node_data_count":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            nodeDataCountField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'GameZRcMetadata'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var materialArraySize = materialArraySizeField.Unwrap("material_array_size");
            var meshesArraySize = meshesArraySizeField.Unwrap("meshes_array_size");
            var nodeArraySize = nodeArraySizeField.Unwrap("node_array_size");
            var nodeDataCount = nodeDataCountField.Unwrap("node_data_count");
            return new GameZRcMetadata(materialArraySize, meshesArraySize, nodeArraySize, nodeDataCount);
        }

        public override void Write(Utf8JsonWriter writer, GameZRcMetadata value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("material_array_size");
            JsonSerializer.Serialize(writer, value.materialArraySize, options);
            writer.WritePropertyName("meshes_array_size");
            JsonSerializer.Serialize(writer, value.meshesArraySize, options);
            writer.WritePropertyName("node_array_size");
            JsonSerializer.Serialize(writer, value.nodeArraySize, options);
            writer.WritePropertyName("node_data_count");
            JsonSerializer.Serialize(writer, value.nodeDataCount, options);
            writer.WriteEndObject();
        }
    }
}
