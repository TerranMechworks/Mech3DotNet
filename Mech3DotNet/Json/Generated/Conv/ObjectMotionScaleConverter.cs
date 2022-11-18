using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectMotionScaleConverter : Mech3DotNet.Json.Converters.StructConverter<ObjectMotionScale>
    {
        protected override ObjectMotionScale ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var valueField = new Mech3DotNet.Json.Converters.Option<Vec3>();
            var unkField = new Mech3DotNet.Json.Converters.Option<Vec3>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "value":
                        {
                            Vec3 __value = ReadFieldValue<Vec3>(ref __reader, __options);
                            valueField.Set(__value);
                            break;
                        }
                    case "unk":
                        {
                            Vec3 __value = ReadFieldValue<Vec3>(ref __reader, __options);
                            unkField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectMotionScale'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var value = valueField.Unwrap("value");
            var unk = unkField.Unwrap("unk");
            return new ObjectMotionScale(value, unk);
        }

        public override void Write(Utf8JsonWriter writer, ObjectMotionScale value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value");
            JsonSerializer.Serialize(writer, value.value, options);
            writer.WritePropertyName("unk");
            JsonSerializer.Serialize(writer, value.unk, options);
            writer.WriteEndObject();
        }
    }
}
