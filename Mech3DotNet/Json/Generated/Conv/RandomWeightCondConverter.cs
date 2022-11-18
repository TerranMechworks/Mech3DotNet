using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class RandomWeightCondConverter : Mech3DotNet.Json.Converters.StructConverter<RandomWeightCond>
    {
        protected override RandomWeightCond ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var valueField = new Mech3DotNet.Json.Converters.Option<float>();
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
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'RandomWeightCond'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var value = valueField.Unwrap("value");
            return new RandomWeightCond(value);
        }

        public override void Write(Utf8JsonWriter writer, RandomWeightCond value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value");
            JsonSerializer.Serialize(writer, value.value, options);
            writer.WriteEndObject();
        }
    }
}
