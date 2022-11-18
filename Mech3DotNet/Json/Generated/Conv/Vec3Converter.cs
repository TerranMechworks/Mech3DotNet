using System.Text.Json;

namespace Mech3DotNet.Json.Types.Converters
{
    public class Vec3Converter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Types.Vec3>
    {
        protected override Mech3DotNet.Json.Types.Vec3 ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var xField = new Mech3DotNet.Json.Converters.Option<float>();
            var yField = new Mech3DotNet.Json.Converters.Option<float>();
            var zField = new Mech3DotNet.Json.Converters.Option<float>();
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
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Vec3'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var x = xField.Unwrap("x");
            var y = yField.Unwrap("y");
            var z = zField.Unwrap("z");
            return new Mech3DotNet.Json.Types.Vec3(x, y, z);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Types.Vec3 value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("x");
            JsonSerializer.Serialize(writer, value.x, options);
            writer.WritePropertyName("y");
            JsonSerializer.Serialize(writer, value.y, options);
            writer.WritePropertyName("z");
            JsonSerializer.Serialize(writer, value.z, options);
            writer.WriteEndObject();
        }
    }
}
