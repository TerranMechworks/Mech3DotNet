using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ResetStateConverter : StructConverter<ResetState>
    {
        protected override ResetState ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var eventsField = new Option<List<Event>>();
            var pointerField = new Option<uint>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "events":
                        {
                            List<Event>? __value = ReadFieldValue<List<Event>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'events' was null for 'ResetState'");
                                throw new JsonException();
                            }
                            eventsField.Set(__value);
                            break;
                        }
                    case "pointer":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            pointerField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ResetState'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var events = eventsField.Unwrap("events");
            var pointer = pointerField.Unwrap("pointer");
            return new ResetState(events, pointer);
        }

        public override void Write(Utf8JsonWriter writer, ResetState value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("events");
            JsonSerializer.Serialize(writer, value.events, options);
            writer.WritePropertyName("pointer");
            JsonSerializer.Serialize(writer, value.pointer, options);
            writer.WriteEndObject();
        }
    }
}
