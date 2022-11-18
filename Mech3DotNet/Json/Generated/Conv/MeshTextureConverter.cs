using System.Text.Json;

namespace Mech3DotNet.Json.Gamez.Mesh.Ng.Converters
{
    public class MeshTextureConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Gamez.Mesh.Ng.MeshTexture>
    {
        protected override Mech3DotNet.Json.Gamez.Mesh.Ng.MeshTexture ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var textureIndexField = new Mech3DotNet.Json.Converters.Option<uint>();
            var polygonUsageCountField = new Mech3DotNet.Json.Converters.Option<uint>();
            var unkPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
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
            return new Mech3DotNet.Json.Gamez.Mesh.Ng.MeshTexture(textureIndex, polygonUsageCount, unkPtr);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Gamez.Mesh.Ng.MeshTexture value, JsonSerializerOptions options)
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
