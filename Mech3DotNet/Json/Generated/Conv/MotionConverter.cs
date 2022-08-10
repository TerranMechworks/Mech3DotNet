using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class MotionConverter<TQuaternion, TVec3> : StructConverter<Motion<TQuaternion, TVec3>>
    {
        private readonly Type __partsType;
        private readonly JsonConverter<List<MotionPart<TQuaternion, TVec3>>?>? __partsConverter;

        public MotionConverter(JsonSerializerOptions options)
        {
            __partsType = typeof(List<MotionPart<TQuaternion, TVec3>>);
            __partsConverter = (JsonConverter<List<MotionPart<TQuaternion, TVec3>>?>?)options.GetConverter(__partsType);
        }

        protected override Motion<TQuaternion, TVec3> ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var loopTimeField = new Option<float>();
            var partsField = new Option<List<MotionPart<TQuaternion, TVec3>>>();
            var frameCountField = new Option<uint>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "loop_time":
                        {
                            float __value = ReadFieldValue<float>(
                                ref __reader, __options);
                            loopTimeField.Set(__value);
                            break;
                        }
                    case "parts":
                        {
                            List<MotionPart<TQuaternion, TVec3>>? __value = ReadFieldGeneric<List<MotionPart<TQuaternion, TVec3>>?>(
                                ref __reader,
                                __options,
                                __partsConverter,
                                __partsType);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'parts' was null for 'Motion'");
                                throw new JsonException();
                            }
                            partsField.Set(__value);
                            break;
                        }
                    case "frame_count":
                        {
                            uint __value = ReadFieldValue<uint>(
                                ref __reader, __options);
                            frameCountField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Motion'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var loopTime = loopTimeField.Unwrap("loop_time");
            var parts = partsField.Unwrap("parts");
            var frameCount = frameCountField.Unwrap("frame_count");
            return new Motion<TQuaternion, TVec3>(loopTime, parts, frameCount);
        }

        public override void Write(Utf8JsonWriter writer, Motion<TQuaternion, TVec3> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("loop_time");
            JsonSerializer.Serialize(writer, value.loopTime, options);
            writer.WritePropertyName("parts");
            if (__partsConverter != null)
                __partsConverter.Write(writer, value.parts, options);
            else
                JsonSerializer.Serialize(writer, value.parts, options);
            writer.WritePropertyName("frame_count");
            JsonSerializer.Serialize(writer, value.frameCount, options);
            writer.WriteEndObject();
        }
    }
}
