using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class PolygonFlagsConverter : StructConverter<PolygonFlags>
    {
        protected override PolygonFlags ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var unk2Field = new Option<bool>(false);
            var unk3Field = new Option<bool>(false);
            var triangleStripField = new Option<bool>(false);
            var unk6Field = new Option<bool>(false);
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "unk2":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            unk2Field.Set(__value);
                            break;
                        }
                    case "unk3":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            unk3Field.Set(__value);
                            break;
                        }
                    case "triangle_strip":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            triangleStripField.Set(__value);
                            break;
                        }
                    case "unk6":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            unk6Field.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'PolygonFlags'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var unk2 = unk2Field.Unwrap("unk2");
            var unk3 = unk3Field.Unwrap("unk3");
            var triangleStrip = triangleStripField.Unwrap("triangle_strip");
            var unk6 = unk6Field.Unwrap("unk6");
            return new PolygonFlags(unk2, unk3, triangleStrip, unk6);
        }

        public override void Write(Utf8JsonWriter writer, PolygonFlags value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            if (value.unk2 != false)
            {
                writer.WritePropertyName("unk2");
                JsonSerializer.Serialize(writer, value.unk2, options);
            }
            if (value.unk3 != false)
            {
                writer.WritePropertyName("unk3");
                JsonSerializer.Serialize(writer, value.unk3, options);
            }
            if (value.triangleStrip != false)
            {
                writer.WritePropertyName("triangle_strip");
                JsonSerializer.Serialize(writer, value.triangleStrip, options);
            }
            if (value.unk6 != false)
            {
                writer.WritePropertyName("unk6");
                JsonSerializer.Serialize(writer, value.unk6, options);
            }
            writer.WriteEndObject();
        }
    }
}
