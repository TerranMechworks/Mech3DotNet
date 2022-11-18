using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class BoundingBoxConverter : Mech3DotNet.Json.Converters.StructConverter<BoundingBox>
    {
        protected override BoundingBox ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var aField = new Mech3DotNet.Json.Converters.Option<Vec3>();
            var bField = new Mech3DotNet.Json.Converters.Option<Vec3>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "a":
                        {
                            Vec3 __value = ReadFieldValue<Vec3>(ref __reader, __options);
                            aField.Set(__value);
                            break;
                        }
                    case "b":
                        {
                            Vec3 __value = ReadFieldValue<Vec3>(ref __reader, __options);
                            bField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'BoundingBox'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var a = aField.Unwrap("a");
            var b = bField.Unwrap("b");
            return new BoundingBox(a, b);
        }

        public override void Write(Utf8JsonWriter writer, BoundingBox value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("a");
            JsonSerializer.Serialize(writer, value.a, options);
            writer.WritePropertyName("b");
            JsonSerializer.Serialize(writer, value.b, options);
            writer.WriteEndObject();
        }
    }
}
