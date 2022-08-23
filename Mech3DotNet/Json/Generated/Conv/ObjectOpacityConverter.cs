using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectOpacityConverter : StructConverter<ObjectOpacity>
    {
        protected override ObjectOpacity ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var valueField = new Option<float>();
            var stateField = new Option<short>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "value":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            valueField.Set(__value);
                            break;
                        }
                    case "state":
                        {
                            short __value = ReadFieldValue<short>(ref __reader, __options);
                            stateField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectOpacity'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var value = valueField.Unwrap("value");
            var state = stateField.Unwrap("state");
            return new ObjectOpacity(value, state);
        }

        public override void Write(Utf8JsonWriter writer, ObjectOpacity value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value");
            JsonSerializer.Serialize(writer, value.value, options);
            writer.WritePropertyName("state");
            JsonSerializer.Serialize(writer, value.state, options);
            writer.WriteEndObject();
        }
    }
}
