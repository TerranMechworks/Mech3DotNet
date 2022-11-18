using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class MeshTextureConverter : StructConverter<MeshTexture>
    {
        protected override MeshTexture ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var textureIndexField = new Option<uint>();
            var polygonUsageCountField = new Option<uint>();
            var unkPtrField = new Option<uint>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "texture_index":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            textureIndexField.Set(__value);
                            break;
                        }
                    case "polygon_usage_count":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            polygonUsageCountField.Set(__value);
                            break;
                        }
                    case "unk_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unkPtrField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'MeshTexture'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var textureIndex = textureIndexField.Unwrap("texture_index");
            var polygonUsageCount = polygonUsageCountField.Unwrap("polygon_usage_count");
            var unkPtr = unkPtrField.Unwrap("unk_ptr");
            return new MeshTexture(textureIndex, polygonUsageCount, unkPtr);
        }

        public override void Write(Utf8JsonWriter writer, MeshTexture value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("texture_index");
            JsonSerializer.Serialize(writer, value.textureIndex, options);
            writer.WritePropertyName("polygon_usage_count");
            JsonSerializer.Serialize(writer, value.polygonUsageCount, options);
            writer.WritePropertyName("unk_ptr");
            JsonSerializer.Serialize(writer, value.unkPtr, options);
            writer.WriteEndObject();
        }
    }
}
