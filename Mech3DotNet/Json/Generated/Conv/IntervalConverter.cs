using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class IntervalConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.Interval>
    {
        protected override Mech3DotNet.Json.Anim.Events.Interval ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var intervalTypeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.IntervalType>();
            var intervalValueField = new Mech3DotNet.Json.Converters.Option<float>();
            var flagField = new Mech3DotNet.Json.Converters.Option<bool>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "interval_type":
                        {
                            Mech3DotNet.Json.Anim.Events.IntervalType __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.IntervalType>(ref __reader, __options);
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
            return new Mech3DotNet.Json.Anim.Events.Interval(intervalType, intervalValue, flag);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.Interval value, JsonSerializerOptions options)
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
