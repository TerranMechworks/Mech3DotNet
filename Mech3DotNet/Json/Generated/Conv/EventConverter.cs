using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class EventConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.Event>
    {
        protected override Mech3DotNet.Json.Anim.Events.Event ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var dataField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.EventData>();
            var startField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.EventStart?>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "data":
                        {
                            Mech3DotNet.Json.Anim.Events.EventData? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.EventData?>(ref __reader, __options);
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
                            Mech3DotNet.Json.Anim.Events.EventStart? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.EventStart?>(ref __reader, __options);
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
            return new Mech3DotNet.Json.Anim.Events.Event(data, start);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.Event value, JsonSerializerOptions options)
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
