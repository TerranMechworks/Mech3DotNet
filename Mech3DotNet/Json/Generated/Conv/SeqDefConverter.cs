using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class SeqDefConverter : StructConverter<SeqDef>
    {
        protected override SeqDef ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var activationField = new Option<SeqActivation>();
            var eventsField = new Option<List<Event>>();
            var pointerField = new Option<uint>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "name":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'SeqDef'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "activation":
                        {
                            SeqActivation __value = ReadFieldValue<SeqActivation>(ref __reader, __options);
                            activationField.Set(__value);
                            break;
                        }
                    case "events":
                        {
                            List<Event>? __value = ReadFieldValue<List<Event>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'events' was null for 'SeqDef'");
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
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'SeqDef'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var activation = activationField.Unwrap("activation");
            var events = eventsField.Unwrap("events");
            var pointer = pointerField.Unwrap("pointer");
            return new SeqDef(name, activation, events, pointer);
        }

        public override void Write(Utf8JsonWriter writer, SeqDef value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("activation");
            JsonSerializer.Serialize(writer, value.activation, options);
            writer.WritePropertyName("events");
            JsonSerializer.Serialize(writer, value.events, options);
            writer.WritePropertyName("pointer");
            JsonSerializer.Serialize(writer, value.pointer, options);
            writer.WriteEndObject();
        }
    }
}
