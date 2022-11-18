using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class UvCoordConverter : Mech3DotNet.Json.Converters.StructConverter<UvCoord>
    {
        protected override UvCoord ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var uField = new Mech3DotNet.Json.Converters.Option<float>();
            var vField = new Mech3DotNet.Json.Converters.Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "u":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            uField.Set(__value);
                            break;
                        }
                    case "v":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            vField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'UvCoord'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var u = uField.Unwrap("u");
            var v = vField.Unwrap("v");
            return new UvCoord(u, v);
        }

        public override void Write(Utf8JsonWriter writer, UvCoord value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("u");
            JsonSerializer.Serialize(writer, value.u, options);
            writer.WritePropertyName("v");
            JsonSerializer.Serialize(writer, value.v, options);
            writer.WriteEndObject();
        }
    }
}
