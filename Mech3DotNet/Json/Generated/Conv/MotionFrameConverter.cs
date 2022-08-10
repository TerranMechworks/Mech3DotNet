using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class MotionFrameConverter<TQuaternion, TVec3> : StructConverter<MotionFrame<TQuaternion, TVec3>>
    {
        private readonly Type __translationType;
        private readonly JsonConverter<TVec3>? __translationConverter;
        private readonly Type __rotationType;
        private readonly JsonConverter<TQuaternion>? __rotationConverter;

        public MotionFrameConverter(JsonSerializerOptions options)
        {
            __translationType = typeof(TVec3);
            __translationConverter = (JsonConverter<TVec3>?)options.GetConverter(__translationType);
            __rotationType = typeof(TQuaternion);
            __rotationConverter = (JsonConverter<TQuaternion>?)options.GetConverter(__rotationType);
        }

        protected override MotionFrame<TQuaternion, TVec3> ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var translationField = new Option<TVec3>();
            var rotationField = new Option<TQuaternion>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "translation":
                        {
                            TVec3 __value = ReadFieldGeneric<TVec3>(
                                ref __reader,
                                __options,
                                __translationConverter,
                                __translationType);
                            translationField.Set(__value);
                            break;
                        }
                    case "rotation":
                        {
                            TQuaternion __value = ReadFieldGeneric<TQuaternion>(
                                ref __reader,
                                __options,
                                __rotationConverter,
                                __rotationType);
                            rotationField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'MotionFrame'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var translation = translationField.Unwrap("translation");
            var rotation = rotationField.Unwrap("rotation");
            return new MotionFrame<TQuaternion, TVec3>(translation, rotation);
        }

        public override void Write(Utf8JsonWriter writer, MotionFrame<TQuaternion, TVec3> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("translation");
            if (__translationConverter != null)
                __translationConverter.Write(writer, value.translation, options);
            else
                JsonSerializer.Serialize(writer, value.translation, options);
            writer.WritePropertyName("rotation");
            if (__rotationConverter != null)
                __rotationConverter.Write(writer, value.rotation, options);
            else
                JsonSerializer.Serialize(writer, value.rotation, options);
            writer.WriteEndObject();
        }
    }
}
