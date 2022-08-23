using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class EventStartConverter : StructConverter<EventStart>
    {
        protected override EventStart ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var offsetField = new Option<StartOffset>();
            var timeField = new Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "offset":
                        {
                            StartOffset __value = ReadFieldValue<StartOffset>(ref __reader, __options);
                            offsetField.Set(__value);
                            break;
                        }
                    case "time":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            timeField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'EventStart'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var offset = offsetField.Unwrap("offset");
            var time = timeField.Unwrap("time");
            return new EventStart(offset, time);
        }

        public override void Write(Utf8JsonWriter writer, EventStart value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("offset");
            JsonSerializer.Serialize(writer, value.offset, options);
            writer.WritePropertyName("time");
            JsonSerializer.Serialize(writer, value.time, options);
            writer.WriteEndObject();
        }
    }
}
