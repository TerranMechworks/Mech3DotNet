using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class PolygonTextureNgConverter : StructConverter<PolygonTextureNg>
    {
        protected override PolygonTextureNg ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var textureIndexField = new Option<uint>();
            var uvCoordsField = new Option<List<UvCoord>>();
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
                    case "uv_coords":
                        {
                            List<UvCoord>? __value = ReadFieldValue<List<UvCoord>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'uv_coords' was null for 'PolygonTextureNg'");
                                throw new JsonException();
                            }
                            uvCoordsField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'PolygonTextureNg'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var textureIndex = textureIndexField.Unwrap("texture_index");
            var uvCoords = uvCoordsField.Unwrap("uv_coords");
            return new PolygonTextureNg(textureIndex, uvCoords);
        }

        public override void Write(Utf8JsonWriter writer, PolygonTextureNg value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("texture_index");
            JsonSerializer.Serialize(writer, value.textureIndex, options);
            writer.WritePropertyName("uv_coords");
            JsonSerializer.Serialize(writer, value.uvCoords, options);
            writer.WriteEndObject();
        }
    }
}
