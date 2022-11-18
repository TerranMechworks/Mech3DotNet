using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class QuaternionConverter : Mech3DotNet.Json.Converters.StructConverter<Quaternion>
    {
        protected override Quaternion ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var xField = new Mech3DotNet.Json.Converters.Option<float>();
            var yField = new Mech3DotNet.Json.Converters.Option<float>();
            var zField = new Mech3DotNet.Json.Converters.Option<float>();
            var wField = new Mech3DotNet.Json.Converters.Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "x":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            xField.Set(__value);
                            break;
                        }
                    case "y":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            yField.Set(__value);
                            break;
                        }
                    case "z":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            zField.Set(__value);
                            break;
                        }
                    case "w":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            wField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Quaternion'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var x = xField.Unwrap("x");
            var y = yField.Unwrap("y");
            var z = zField.Unwrap("z");
            var w = wField.Unwrap("w");
            return new Quaternion(x, y, z, w);
        }

        public override void Write(Utf8JsonWriter writer, Quaternion value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("x");
            JsonSerializer.Serialize(writer, value.x, options);
            writer.WritePropertyName("y");
            JsonSerializer.Serialize(writer, value.y, options);
            writer.WritePropertyName("z");
            JsonSerializer.Serialize(writer, value.z, options);
            writer.WritePropertyName("w");
            JsonSerializer.Serialize(writer, value.w, options);
            writer.WriteEndObject();
        }
    }
}
