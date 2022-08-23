using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class EventConverter : StructConverter<Event>
    {
        protected override Event ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var dataField = new Option<EventData>();
            var startField = new Option<EventStart?>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "data":
                        {
                            EventData? __value = ReadFieldValue<EventData?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'data' was null for 'Event'");
                                throw new JsonException();
                            }
                            dataField.Set(__value);
                            break;
                        }
                    case "start":
                        {
                            EventStart? __value = ReadFieldValue<EventStart?>(ref __reader, __options);
                            startField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Event'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var data = dataField.Unwrap("data");
            var start = startField.Unwrap("start");
            return new Event(data, start);
        }

        public override void Write(Utf8JsonWriter writer, Event value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("data");
            JsonSerializer.Serialize(writer, value.data, options);
            writer.WritePropertyName("start");
            JsonSerializer.Serialize(writer, value.start, options);
            writer.WriteEndObject();
        }
    }
}
