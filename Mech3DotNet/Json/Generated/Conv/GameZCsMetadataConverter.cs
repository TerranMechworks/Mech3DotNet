using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class GameZCsMetadataConverter : Mech3DotNet.Json.Converters.StructConverter<GameZCsMetadata>
    {
        protected override GameZCsMetadata ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var gamezHeaderUnk08Field = new Mech3DotNet.Json.Converters.Option<uint>();
            var materialArraySizeField = new Mech3DotNet.Json.Converters.Option<short>();
            var nodeArraySizeField = new Mech3DotNet.Json.Converters.Option<uint>();
            var nodeDataCountField = new Mech3DotNet.Json.Converters.Option<uint>();
            var texturePtrsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<uint?>>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "gamez_header_unk08":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            gamezHeaderUnk08Field.Set(__value);
                            break;
                        }
                    case "material_array_size":
                        {
                            short __value = ReadFieldValue<short>(ref __reader, __options);
                            materialArraySizeField.Set(__value);
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
                    case "texture_ptrs":
                        {
                            System.Collections.Generic.List<uint?>? __value = ReadFieldValue<System.Collections.Generic.List<uint?>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'texture_ptrs' was null for 'GameZCsMetadata'");
                                throw new JsonException();
                            }
                            texturePtrsField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'GameZCsMetadata'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var gamezHeaderUnk08 = gamezHeaderUnk08Field.Unwrap("gamez_header_unk08");
            var materialArraySize = materialArraySizeField.Unwrap("material_array_size");
            var nodeArraySize = nodeArraySizeField.Unwrap("node_array_size");
            var nodeDataCount = nodeDataCountField.Unwrap("node_data_count");
            var texturePtrs = texturePtrsField.Unwrap("texture_ptrs");
            return new GameZCsMetadata(gamezHeaderUnk08, materialArraySize, nodeArraySize, nodeDataCount, texturePtrs);
        }

        public override void Write(Utf8JsonWriter writer, GameZCsMetadata value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("gamez_header_unk08");
            JsonSerializer.Serialize(writer, value.gamezHeaderUnk08, options);
            writer.WritePropertyName("material_array_size");
            JsonSerializer.Serialize(writer, value.materialArraySize, options);
            writer.WritePropertyName("node_array_size");
            JsonSerializer.Serialize(writer, value.nodeArraySize, options);
            writer.WritePropertyName("node_data_count");
            JsonSerializer.Serialize(writer, value.nodeDataCount, options);
            writer.WritePropertyName("texture_ptrs");
            JsonSerializer.Serialize(writer, value.texturePtrs, options);
            writer.WriteEndObject();
        }
    }
}
