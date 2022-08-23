using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class IntervalConverter : StructConverter<Interval>
    {
        protected override Interval ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var intervalTypeField = new Option<IntervalType>();
            var intervalValueField = new Option<float>();
            var flagField = new Option<bool>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "interval_type":
                        {
                            IntervalType __value = ReadFieldValue<IntervalType>(ref __reader, __options);
                            intervalTypeField.Set(__value);
                            break;
                        }
                    case "interval_value":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            intervalValueField.Set(__value);
                            break;
                        }
                    case "flag":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            flagField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Interval'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var intervalType = intervalTypeField.Unwrap("interval_type");
            var intervalValue = intervalValueField.Unwrap("interval_value");
            var flag = flagField.Unwrap("flag");
            return new Interval(intervalType, intervalValue, flag);
        }

        public override void Write(Utf8JsonWriter writer, Interval value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("interval_type");
            JsonSerializer.Serialize(writer, value.intervalType, options);
            writer.WritePropertyName("interval_value");
            JsonSerializer.Serialize(writer, value.intervalValue, options);
            writer.WritePropertyName("flag");
            JsonSerializer.Serialize(writer, value.flag, options);
            writer.WriteEndObject();
        }
    }
}
