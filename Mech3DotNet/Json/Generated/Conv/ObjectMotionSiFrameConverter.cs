using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectMotionSiFrameConverter : Mech3DotNet.Json.Converters.StructConverter<ObjectMotionSiFrame>
    {
        protected override ObjectMotionSiFrame ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var startTimeField = new Mech3DotNet.Json.Converters.Option<float>();
            var endTimeField = new Mech3DotNet.Json.Converters.Option<float>();
            var translationField = new Mech3DotNet.Json.Converters.Option<TranslateData?>(null);
            var rotationField = new Mech3DotNet.Json.Converters.Option<RotateData?>(null);
            var scaleField = new Mech3DotNet.Json.Converters.Option<ScaleData?>(null);
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "start_time":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            startTimeField.Set(__value);
                            break;
                        }
                    case "end_time":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            endTimeField.Set(__value);
                            break;
                        }
                    case "translation":
                        {
                            TranslateData? __value = ReadFieldValue<TranslateData?>(ref __reader, __options);
                            translationField.Set(__value);
                            break;
                        }
                    case "rotation":
                        {
                            RotateData? __value = ReadFieldValue<RotateData?>(ref __reader, __options);
                            rotationField.Set(__value);
                            break;
                        }
                    case "scale":
                        {
                            ScaleData? __value = ReadFieldValue<ScaleData?>(ref __reader, __options);
                            scaleField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectMotionSiFrame'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var startTime = startTimeField.Unwrap("start_time");
            var endTime = endTimeField.Unwrap("end_time");
            var translation = translationField.Unwrap("translation");
            var rotation = rotationField.Unwrap("rotation");
            var scale = scaleField.Unwrap("scale");
            return new ObjectMotionSiFrame(startTime, endTime, translation, rotation, scale);
        }

        public override void Write(Utf8JsonWriter writer, ObjectMotionSiFrame value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("start_time");
            JsonSerializer.Serialize(writer, value.startTime, options);
            writer.WritePropertyName("end_time");
            JsonSerializer.Serialize(writer, value.endTime, options);
            if (value.translation != null)
            {
                writer.WritePropertyName("translation");
                JsonSerializer.Serialize(writer, value.translation, options);
            }
            if (value.rotation != null)
            {
                writer.WritePropertyName("rotation");
                JsonSerializer.Serialize(writer, value.rotation, options);
            }
            if (value.scale != null)
            {
                writer.WritePropertyName("scale");
                JsonSerializer.Serialize(writer, value.scale, options);
            }
            writer.WriteEndObject();
        }
    }
}
