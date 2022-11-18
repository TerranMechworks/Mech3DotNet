using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectOpacityConverter : Mech3DotNet.Json.Converters.StructConverter<ObjectOpacity>
    {
        protected override ObjectOpacity ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var valueField = new Mech3DotNet.Json.Converters.Option<float>();
            var stateField = new Mech3DotNet.Json.Converters.Option<short>();
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
                    case "state":
                        {
                            short __value = ReadFieldValue<short>(ref __reader, __options);
                            stateField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectOpacity'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var value = valueField.Unwrap("value");
            var state = stateField.Unwrap("state");
            return new ObjectOpacity(value, state);
        }

        public override void Write(Utf8JsonWriter writer, ObjectOpacity value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value");
            JsonSerializer.Serialize(writer, value.value, options);
            writer.WritePropertyName("state");
            JsonSerializer.Serialize(writer, value.state, options);
            writer.WriteEndObject();
        }
    }
}
