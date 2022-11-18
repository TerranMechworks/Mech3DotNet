using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class EventStartConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.EventStart>
    {
        protected override Mech3DotNet.Json.Anim.Events.EventStart ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var offsetField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.StartOffset>();
            var timeField = new Mech3DotNet.Json.Converters.Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "offset":
                        {
                            Mech3DotNet.Json.Anim.Events.StartOffset __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.StartOffset>(ref __reader, __options);
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
            return new Mech3DotNet.Json.Anim.Events.EventStart(offset, time);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.EventStart value, JsonSerializerOptions options)
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
