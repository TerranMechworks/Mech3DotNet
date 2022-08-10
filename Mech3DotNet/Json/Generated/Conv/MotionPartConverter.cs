using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class MotionPartConverter<TQuaternion, TVec3> : StructConverter<MotionPart<TQuaternion, TVec3>>
    {
        private readonly Type __framesType;
        private readonly JsonConverter<List<MotionFrame<TQuaternion, TVec3>>?>? __framesConverter;

        public MotionPartConverter(JsonSerializerOptions options)
        {
            __framesType = typeof(List<MotionFrame<TQuaternion, TVec3>>);
            __framesConverter = (JsonConverter<List<MotionFrame<TQuaternion, TVec3>>?>?)options.GetConverter(__framesType);
        }

        protected override MotionPart<TQuaternion, TVec3> ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var framesField = new Option<List<MotionFrame<TQuaternion, TVec3>>>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "name":
                        {
                            string? __value = ReadFieldValue<string?>(
                                ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'MotionPart'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "frames":
                        {
                            List<MotionFrame<TQuaternion, TVec3>>? __value = ReadFieldGeneric<List<MotionFrame<TQuaternion, TVec3>>?>(
                                ref __reader,
                                __options,
                                __framesConverter,
                                __framesType);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'frames' was null for 'MotionPart'");
                                throw new JsonException();
                            }
                            framesField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'MotionPart'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var frames = framesField.Unwrap("frames");
            return new MotionPart<TQuaternion, TVec3>(name, frames);
        }

        public override void Write(Utf8JsonWriter writer, MotionPart<TQuaternion, TVec3> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("frames");
            if (__framesConverter != null)
                __framesConverter.Write(writer, value.frames, options);
            else
                JsonSerializer.Serialize(writer, value.frames, options);
            writer.WriteEndObject();
        }
    }
}
