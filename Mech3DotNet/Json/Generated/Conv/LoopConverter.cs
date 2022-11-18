using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class LoopConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.Loop>
    {
        protected override Mech3DotNet.Json.Anim.Events.Loop ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var startField = new Mech3DotNet.Json.Converters.Option<int>();
            var loopCountField = new Mech3DotNet.Json.Converters.Option<int>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "start":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            startField.Set(__value);
                            break;
                        }
                    case "loop_count":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            loopCountField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Loop'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var start = startField.Unwrap("start");
            var loopCount = loopCountField.Unwrap("loop_count");
            return new Mech3DotNet.Json.Anim.Events.Loop(start, loopCount);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.Loop value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("start");
            JsonSerializer.Serialize(writer, value.start, options);
            writer.WritePropertyName("loop_count");
            JsonSerializer.Serialize(writer, value.loopCount, options);
            writer.WriteEndObject();
        }
    }
}
