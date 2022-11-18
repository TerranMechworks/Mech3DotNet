using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class HwRenderCondConverter : Mech3DotNet.Json.Converters.StructConverter<HwRenderCond>
    {
        protected override HwRenderCond ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var valueField = new Mech3DotNet.Json.Converters.Option<bool>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "value":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            valueField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'HwRenderCond'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var value = valueField.Unwrap("value");
            return new HwRenderCond(value);
        }

        public override void Write(Utf8JsonWriter writer, HwRenderCond value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value");
            JsonSerializer.Serialize(writer, value.value, options);
            writer.WriteEndObject();
        }
    }
}
