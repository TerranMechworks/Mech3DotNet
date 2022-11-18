using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class RgbaConverter : Mech3DotNet.Json.Converters.StructConverter<Rgba>
    {
        protected override Rgba ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var rField = new Mech3DotNet.Json.Converters.Option<float>();
            var gField = new Mech3DotNet.Json.Converters.Option<float>();
            var bField = new Mech3DotNet.Json.Converters.Option<float>();
            var aField = new Mech3DotNet.Json.Converters.Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "r":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            rField.Set(__value);
                            break;
                        }
                    case "g":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            gField.Set(__value);
                            break;
                        }
                    case "b":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            bField.Set(__value);
                            break;
                        }
                    case "a":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            aField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Rgba'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var r = rField.Unwrap("r");
            var g = gField.Unwrap("g");
            var b = bField.Unwrap("b");
            var a = aField.Unwrap("a");
            return new Rgba(r, g, b, a);
        }

        public override void Write(Utf8JsonWriter writer, Rgba value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("r");
            JsonSerializer.Serialize(writer, value.r, options);
            writer.WritePropertyName("g");
            JsonSerializer.Serialize(writer, value.g, options);
            writer.WritePropertyName("b");
            JsonSerializer.Serialize(writer, value.b, options);
            writer.WritePropertyName("a");
            JsonSerializer.Serialize(writer, value.a, options);
            writer.WriteEndObject();
        }
    }
}
