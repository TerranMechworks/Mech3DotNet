using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class ObjectMotionConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.ObjectMotion>
    {
        protected override Mech3DotNet.Json.Anim.Events.ObjectMotion ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Mech3DotNet.Json.Converters.Option<string>();
            var impactForceField = new Mech3DotNet.Json.Converters.Option<bool>();
            var gravityField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.Gravity?>(null);
            var translationRangeMinField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Quaternion?>(null);
            var translationRangeMaxField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Quaternion?>(null);
            var translationField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.ObjectMotionTranslation?>(null);
            var forwardRotationField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.ForwardRotation?>(null);
            var xyzRotationField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.XyzRotation?>(null);
            var scaleField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.ObjectMotionScale?>(null);
            var bounceSequenceField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.BounceSequence?>(null);
            var bounceSoundField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.BounceSound?>(null);
            var runtimeField = new Mech3DotNet.Json.Converters.Option<float?>(null);
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
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'ObjectMotion'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "impact_force":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            impactForceField.Set(__value);
                            break;
                        }
                    case "gravity":
                        {
                            Mech3DotNet.Json.Anim.Events.Gravity? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.Gravity?>(ref __reader, __options);
                            gravityField.Set(__value);
                            break;
                        }
                    case "translation_range_min":
                        {
                            Mech3DotNet.Json.Types.Quaternion? __value = ReadFieldValue<Mech3DotNet.Json.Types.Quaternion?>(ref __reader, __options);
                            translationRangeMinField.Set(__value);
                            break;
                        }
                    case "translation_range_max":
                        {
                            Mech3DotNet.Json.Types.Quaternion? __value = ReadFieldValue<Mech3DotNet.Json.Types.Quaternion?>(ref __reader, __options);
                            translationRangeMaxField.Set(__value);
                            break;
                        }
                    case "translation":
                        {
                            Mech3DotNet.Json.Anim.Events.ObjectMotionTranslation? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.ObjectMotionTranslation?>(ref __reader, __options);
                            translationField.Set(__value);
                            break;
                        }
                    case "forward_rotation":
                        {
                            Mech3DotNet.Json.Anim.Events.ForwardRotation? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.ForwardRotation?>(ref __reader, __options);
                            forwardRotationField.Set(__value);
                            break;
                        }
                    case "xyz_rotation":
                        {
                            Mech3DotNet.Json.Anim.Events.XyzRotation? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.XyzRotation?>(ref __reader, __options);
                            xyzRotationField.Set(__value);
                            break;
                        }
                    case "scale":
                        {
                            Mech3DotNet.Json.Anim.Events.ObjectMotionScale? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.ObjectMotionScale?>(ref __reader, __options);
                            scaleField.Set(__value);
                            break;
                        }
                    case "bounce_sequence":
                        {
                            Mech3DotNet.Json.Anim.Events.BounceSequence? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.BounceSequence?>(ref __reader, __options);
                            bounceSequenceField.Set(__value);
                            break;
                        }
                    case "bounce_sound":
                        {
                            Mech3DotNet.Json.Anim.Events.BounceSound? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.BounceSound?>(ref __reader, __options);
                            bounceSoundField.Set(__value);
                            break;
                        }
                    case "runtime":
                        {
                            float? __value = ReadFieldValue<float?>(ref __reader, __options);
                            runtimeField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectMotion'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var impactForce = impactForceField.Unwrap("impact_force");
            var gravity = gravityField.Unwrap("gravity");
            var translationRangeMin = translationRangeMinField.Unwrap("translation_range_min");
            var translationRangeMax = translationRangeMaxField.Unwrap("translation_range_max");
            var translation = translationField.Unwrap("translation");
            var forwardRotation = forwardRotationField.Unwrap("forward_rotation");
            var xyzRotation = xyzRotationField.Unwrap("xyz_rotation");
            var scale = scaleField.Unwrap("scale");
            var bounceSequence = bounceSequenceField.Unwrap("bounce_sequence");
            var bounceSound = bounceSoundField.Unwrap("bounce_sound");
            var runtime = runtimeField.Unwrap("runtime");
            return new Mech3DotNet.Json.Anim.Events.ObjectMotion(node, impactForce, gravity, translationRangeMin, translationRangeMax, translation, forwardRotation, xyzRotation, scale, bounceSequence, bounceSound, runtime);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.ObjectMotion value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("impact_force");
            JsonSerializer.Serialize(writer, value.impactForce, options);
            if (value.gravity != null)
            {
                writer.WritePropertyName("gravity");
                JsonSerializer.Serialize(writer, value.gravity, options);
            }
            if (value.translationRangeMin != null)
            {
                writer.WritePropertyName("translation_range_min");
                JsonSerializer.Serialize(writer, value.translationRangeMin, options);
            }
            if (value.translationRangeMax != null)
            {
                writer.WritePropertyName("translation_range_max");
                JsonSerializer.Serialize(writer, value.translationRangeMax, options);
            }
            if (value.translation != null)
            {
                writer.WritePropertyName("translation");
                JsonSerializer.Serialize(writer, value.translation, options);
            }
            if (value.forwardRotation != null)
            {
                writer.WritePropertyName("forward_rotation");
                JsonSerializer.Serialize(writer, value.forwardRotation, options);
            }
            if (value.xyzRotation != null)
            {
                writer.WritePropertyName("xyz_rotation");
                JsonSerializer.Serialize(writer, value.xyzRotation, options);
            }
            if (value.scale != null)
            {
                writer.WritePropertyName("scale");
                JsonSerializer.Serialize(writer, value.scale, options);
            }
            if (value.bounceSequence != null)
            {
                writer.WritePropertyName("bounce_sequence");
                JsonSerializer.Serialize(writer, value.bounceSequence, options);
            }
            if (value.bounceSound != null)
            {
                writer.WritePropertyName("bounce_sound");
                JsonSerializer.Serialize(writer, value.bounceSound, options);
            }
            if (value.runtime != null)
            {
                writer.WritePropertyName("runtime");
                JsonSerializer.Serialize(writer, value.runtime, options);
            }
            writer.WriteEndObject();
        }
    }
}
