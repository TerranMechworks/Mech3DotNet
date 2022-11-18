using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectMotionTranslationConverter : Mech3DotNet.Json.Converters.StructConverter<ObjectMotionTranslation>
    {
        protected override ObjectMotionTranslation ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var deltaField = new Mech3DotNet.Json.Converters.Option<Vec3>();
            var initialField = new Mech3DotNet.Json.Converters.Option<Vec3>();
            var unkField = new Mech3DotNet.Json.Converters.Option<Vec3>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "delta":
                        {
                            Vec3 __value = ReadFieldValue<Vec3>(ref __reader, __options);
                            deltaField.Set(__value);
                            break;
                        }
                    case "initial":
                        {
                            Vec3 __value = ReadFieldValue<Vec3>(ref __reader, __options);
                            initialField.Set(__value);
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
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectMotionTranslation'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var delta = deltaField.Unwrap("delta");
            var initial = initialField.Unwrap("initial");
            var unk = unkField.Unwrap("unk");
            return new ObjectMotionTranslation(delta, initial, unk);
        }

        public override void Write(Utf8JsonWriter writer, ObjectMotionTranslation value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("delta");
            JsonSerializer.Serialize(writer, value.delta, options);
            writer.WritePropertyName("initial");
            JsonSerializer.Serialize(writer, value.initial, options);
            writer.WritePropertyName("unk");
            JsonSerializer.Serialize(writer, value.unk, options);
            writer.WriteEndObject();
        }
    }
}
