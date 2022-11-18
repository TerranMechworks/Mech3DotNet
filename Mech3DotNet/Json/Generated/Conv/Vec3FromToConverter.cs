using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class Vec3FromToConverter : Mech3DotNet.Json.Converters.StructConverter<Vec3FromTo>
    {
        protected override Vec3FromTo ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var fromField = new Mech3DotNet.Json.Converters.Option<Vec3>();
            var toField = new Mech3DotNet.Json.Converters.Option<Vec3>();
            var deltaField = new Mech3DotNet.Json.Converters.Option<Vec3>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "from":
                        {
                            Vec3 __value = ReadFieldValue<Vec3>(ref __reader, __options);
                            fromField.Set(__value);
                            break;
                        }
                    case "to":
                        {
                            Vec3 __value = ReadFieldValue<Vec3>(ref __reader, __options);
                            toField.Set(__value);
                            break;
                        }
                    case "delta":
                        {
                            Vec3 __value = ReadFieldValue<Vec3>(ref __reader, __options);
                            deltaField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Vec3FromTo'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var from = fromField.Unwrap("from");
            var to = toField.Unwrap("to");
            var delta = deltaField.Unwrap("delta");
            return new Vec3FromTo(from, to, delta);
        }

        public override void Write(Utf8JsonWriter writer, Vec3FromTo value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("from");
            JsonSerializer.Serialize(writer, value.from, options);
            writer.WritePropertyName("to");
            JsonSerializer.Serialize(writer, value.to, options);
            writer.WritePropertyName("delta");
            JsonSerializer.Serialize(writer, value.delta, options);
            writer.WriteEndObject();
        }
    }
}
