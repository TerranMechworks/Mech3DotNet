using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class RangeConverter : Mech3DotNet.Json.Converters.StructConverter<Range>
    {
        protected override Range ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var minField = new Mech3DotNet.Json.Converters.Option<float>();
            var maxField = new Mech3DotNet.Json.Converters.Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "min":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            minField.Set(__value);
                            break;
                        }
                    case "max":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            maxField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Range'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var min = minField.Unwrap("min");
            var max = maxField.Unwrap("max");
            return new Range(min, max);
        }

        public override void Write(Utf8JsonWriter writer, Range value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("min");
            JsonSerializer.Serialize(writer, value.min, options);
            writer.WritePropertyName("max");
            JsonSerializer.Serialize(writer, value.max, options);
            writer.WriteEndObject();
        }
    }
}
