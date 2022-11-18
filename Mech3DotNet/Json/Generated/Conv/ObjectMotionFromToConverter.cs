using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectMotionFromToConverter : Mech3DotNet.Json.Converters.StructConverter<ObjectMotionFromTo>
    {
        protected override ObjectMotionFromTo ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Mech3DotNet.Json.Converters.Option<string>();
            var runTimeField = new Mech3DotNet.Json.Converters.Option<float>();
            var morphField = new Mech3DotNet.Json.Converters.Option<FloatFromTo?>(null);
            var translateField = new Mech3DotNet.Json.Converters.Option<Vec3FromTo?>(null);
            var rotateField = new Mech3DotNet.Json.Converters.Option<Vec3FromTo?>(null);
            var scaleField = new Mech3DotNet.Json.Converters.Option<Vec3FromTo?>(null);
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "node":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'ObjectMotionFromTo'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "run_time":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            runTimeField.Set(__value);
                            break;
                        }
                    case "morph":
                        {
                            FloatFromTo? __value = ReadFieldValue<FloatFromTo?>(ref __reader, __options);
                            morphField.Set(__value);
                            break;
                        }
                    case "translate":
                        {
                            Vec3FromTo? __value = ReadFieldValue<Vec3FromTo?>(ref __reader, __options);
                            translateField.Set(__value);
                            break;
                        }
                    case "rotate":
                        {
                            Vec3FromTo? __value = ReadFieldValue<Vec3FromTo?>(ref __reader, __options);
                            rotateField.Set(__value);
                            break;
                        }
                    case "scale":
                        {
                            Vec3FromTo? __value = ReadFieldValue<Vec3FromTo?>(ref __reader, __options);
                            scaleField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectMotionFromTo'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var runTime = runTimeField.Unwrap("run_time");
            var morph = morphField.Unwrap("morph");
            var translate = translateField.Unwrap("translate");
            var rotate = rotateField.Unwrap("rotate");
            var scale = scaleField.Unwrap("scale");
            return new ObjectMotionFromTo(node, runTime, morph, translate, rotate, scale);
        }

        public override void Write(Utf8JsonWriter writer, ObjectMotionFromTo value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("run_time");
            JsonSerializer.Serialize(writer, value.runTime, options);
            if (value.morph != null)
            {
                writer.WritePropertyName("morph");
                JsonSerializer.Serialize(writer, value.morph, options);
            }
            if (value.translate != null)
            {
                writer.WritePropertyName("translate");
                JsonSerializer.Serialize(writer, value.translate, options);
            }
            if (value.rotate != null)
            {
                writer.WritePropertyName("rotate");
                JsonSerializer.Serialize(writer, value.rotate, options);
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
