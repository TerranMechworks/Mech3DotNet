using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class MapVertexConverter : StructConverter<MapVertex>
    {
        protected override MapVertex ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var xField = new Option<float>();
            var zField = new Option<float>();
            var yField = new Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "x":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            xField.Set(__value);
                            break;
                        }
                    case "z":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            zField.Set(__value);
                            break;
                        }
                    case "y":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            yField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'MapVertex'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var x = xField.Unwrap("x");
            var z = zField.Unwrap("z");
            var y = yField.Unwrap("y");
            return new MapVertex(x, z, y);
        }

        public override void Write(Utf8JsonWriter writer, MapVertex value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("x");
            JsonSerializer.Serialize(writer, value.x, options);
            writer.WritePropertyName("z");
            JsonSerializer.Serialize(writer, value.z, options);
            writer.WritePropertyName("y");
            JsonSerializer.Serialize(writer, value.y, options);
            writer.WriteEndObject();
        }
    }
}
