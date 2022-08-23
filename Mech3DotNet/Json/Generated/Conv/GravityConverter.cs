using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class GravityConverter : StructConverter<Gravity>
    {
        protected override Gravity ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var modeField = new Option<GravityMode>();
            var valueField = new Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "mode":
                        {
                            GravityMode __value = ReadFieldValue<GravityMode>(ref __reader, __options);
                            modeField.Set(__value);
                            break;
                        }
                    case "value":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            valueField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Gravity'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var mode = modeField.Unwrap("mode");
            var value = valueField.Unwrap("value");
            return new Gravity(mode, value);
        }

        public override void Write(Utf8JsonWriter writer, Gravity value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("mode");
            JsonSerializer.Serialize(writer, value.mode, options);
            writer.WritePropertyName("value");
            JsonSerializer.Serialize(writer, value.value, options);
            writer.WriteEndObject();
        }
    }
}
