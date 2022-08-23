using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectMotionConverter : StructConverter<ObjectMotion>
    {
        protected override ObjectMotion ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Option<string>();
            var impactForceField = new Option<bool>();
            var gravityField = new Option<Gravity?>(null);
            var translationRangeMinField = new Option<Quaternion?>(null);
            var translationRangeMaxField = new Option<Quaternion?>(null);
            var translationField = new Option<ObjectMotionTranslation?>(null);
            var forwardRotationField = new Option<ForwardRotation?>(null);
            var xyzRotationField = new Option<XyzRotation?>(null);
            var scaleField = new Option<ObjectMotionScale?>(null);
            var bounceSequenceField = new Option<BounceSequence?>(null);
            var bounceSoundField = new Option<BounceSound?>(null);
            var runtimeField = new Option<float?>(null);
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
                            Gravity? __value = ReadFieldValue<Gravity?>(ref __reader, __options);
                            gravityField.Set(__value);
                            break;
                        }
                    case "translation_range_min":
                        {
                            Quaternion? __value = ReadFieldValue<Quaternion?>(ref __reader, __options);
                            translationRangeMinField.Set(__value);
                            break;
                        }
                    case "translation_range_max":
                        {
                            Quaternion? __value = ReadFieldValue<Quaternion?>(ref __reader, __options);
                            translationRangeMaxField.Set(__value);
                            break;
                        }
                    case "translation":
                        {
                            ObjectMotionTranslation? __value = ReadFieldValue<ObjectMotionTranslation?>(ref __reader, __options);
                            translationField.Set(__value);
                            break;
                        }
                    case "forward_rotation":
                        {
                            ForwardRotation? __value = ReadFieldValue<ForwardRotation?>(ref __reader, __options);
                            forwardRotationField.Set(__value);
                            break;
                        }
                    case "xyz_rotation":
                        {
                            XyzRotation? __value = ReadFieldValue<XyzRotation?>(ref __reader, __options);
                            xyzRotationField.Set(__value);
                            break;
                        }
                    case "scale":
                        {
                            ObjectMotionScale? __value = ReadFieldValue<ObjectMotionScale?>(ref __reader, __options);
                            scaleField.Set(__value);
                            break;
                        }
                    case "bounce_sequence":
                        {
                            BounceSequence? __value = ReadFieldValue<BounceSequence?>(ref __reader, __options);
                            bounceSequenceField.Set(__value);
                            break;
                        }
                    case "bounce_sound":
                        {
                            BounceSound? __value = ReadFieldValue<BounceSound?>(ref __reader, __options);
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
            return new ObjectMotion(node, impactForce, gravity, translationRangeMin, translationRangeMax, translation, forwardRotation, xyzRotation, scale, bounceSequence, bounceSound, runtime);
        }

        public override void Write(Utf8JsonWriter writer, ObjectMotion value, JsonSerializerOptions options)
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
