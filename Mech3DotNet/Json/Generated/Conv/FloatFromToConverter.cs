using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class FloatFromToConverter : StructConverter<FloatFromTo>
    {
        protected override FloatFromTo ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var fromField = new Option<float>();
            var toField = new Option<float>();
            var deltaField = new Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "from":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            fromField.Set(__value);
                            break;
                        }
                    case "to":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            toField.Set(__value);
                            break;
                        }
                    case "delta":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            deltaField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'FloatFromTo'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var from = fromField.Unwrap("from");
            var to = toField.Unwrap("to");
            var delta = deltaField.Unwrap("delta");
            return new FloatFromTo(from, to, delta);
        }

        public override void Write(Utf8JsonWriter writer, FloatFromTo value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("from");
            JsonSerializer.Serialize(writer, value.from, options);
            writer.WritePropertyName("to");
            JsonSerializer.Serialize(writer, value.to, options);
            writer.WritePropertyName("delta");
            JsonSerializer.Serialize(writer, value.delta, options);
            writer.WriteEndObject();
        }
    }
}
