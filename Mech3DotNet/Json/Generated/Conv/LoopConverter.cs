using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class LoopConverter : StructConverter<Loop>
    {
        protected override Loop ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var startField = new Option<int>();
            var loopCountField = new Option<int>();
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
            return new Loop(start, loopCount);
        }

        public override void Write(Utf8JsonWriter writer, Loop value, JsonSerializerOptions options)
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
