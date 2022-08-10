using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ColorConverter : StructConverter<Color>
    {
        protected override Color ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var rField = new Option<float>();
            var gField = new Option<float>();
            var bField = new Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "r":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            rField.Set(__value);
                            break;
                        }
                    case "g":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            gField.Set(__value);
                            break;
                        }
                    case "b":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            bField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Color'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var r = rField.Unwrap("r");
            var g = gField.Unwrap("g");
            var b = bField.Unwrap("b");
            return new Color(r, g, b);
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("r");
            JsonSerializer.Serialize(writer, value.r, options);
            writer.WritePropertyName("g");
            JsonSerializer.Serialize(writer, value.g, options);
            writer.WritePropertyName("b");
            JsonSerializer.Serialize(writer, value.b, options);
            writer.WriteEndObject();
        }
    }
}
