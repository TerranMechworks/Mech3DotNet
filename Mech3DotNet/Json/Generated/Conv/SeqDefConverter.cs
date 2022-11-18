using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Converters
{
    public class SeqDefConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.SeqDef>
    {
        protected override Mech3DotNet.Json.Anim.SeqDef ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var activationField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.SeqActivation>();
            var eventsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Mech3DotNet.Json.Anim.Events.Event>>();
            var pointerField = new Mech3DotNet.Json.Converters.Option<uint>();
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
                            Mech3DotNet.Json.Anim.SeqActivation __value = ReadFieldValue<Mech3DotNet.Json.Anim.SeqActivation>(ref __reader, __options);
                            activationField.Set(__value);
                            break;
                        }
                    case "events":
                        {
                            System.Collections.Generic.List<Mech3DotNet.Json.Anim.Events.Event>? __value = ReadFieldValue<System.Collections.Generic.List<Mech3DotNet.Json.Anim.Events.Event>?>(ref __reader, __options);
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
            return new Mech3DotNet.Json.Anim.SeqDef(name, activation, events, pointer);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.SeqDef value, JsonSerializerOptions options)
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
