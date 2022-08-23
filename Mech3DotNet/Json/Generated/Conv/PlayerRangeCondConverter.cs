using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class PlayerRangeCondConverter : StructConverter<PlayerRangeCond>
    {
        protected override PlayerRangeCond ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var valueField = new Option<float>();
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
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'PlayerRangeCond'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var value = valueField.Unwrap("value");
            return new PlayerRangeCond(value);
        }

        public override void Write(Utf8JsonWriter writer, PlayerRangeCond value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value");
            JsonSerializer.Serialize(writer, value.value, options);
            writer.WriteEndObject();
        }
    }
}
