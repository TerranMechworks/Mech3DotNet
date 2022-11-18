using System.Text.Json;

namespace Mech3DotNet.Json.Motion.Converters
{
    public class MotionPartConverter<TQuaternion, TVec3> : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Motion.MotionPart<TQuaternion, TVec3>>
    {
        private readonly System.Type __framesType;
        private readonly System.Text.Json.Serialization.JsonConverter<System.Collections.Generic.List<Mech3DotNet.Json.Motion.MotionFrame<TQuaternion, TVec3>>?>? __framesConverter;

        public MotionPartConverter(JsonSerializerOptions options)
        {
            __framesType = typeof(System.Collections.Generic.List<Mech3DotNet.Json.Motion.MotionFrame<TQuaternion, TVec3>>);
            __framesConverter = (System.Text.Json.Serialization.JsonConverter<System.Collections.Generic.List<Mech3DotNet.Json.Motion.MotionFrame<TQuaternion, TVec3>>?>?)options.GetConverter(__framesType);
        }

        protected override Mech3DotNet.Json.Motion.MotionPart<TQuaternion, TVec3> ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var framesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Mech3DotNet.Json.Motion.MotionFrame<TQuaternion, TVec3>>>();
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
                            System.Collections.Generic.List<Mech3DotNet.Json.Motion.MotionFrame<TQuaternion, TVec3>>? __value = ReadFieldGeneric<System.Collections.Generic.List<Mech3DotNet.Json.Motion.MotionFrame<TQuaternion, TVec3>>?>(
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
            return new Mech3DotNet.Json.Motion.MotionPart<TQuaternion, TVec3>(name, frames);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Motion.MotionPart<TQuaternion, TVec3> value, JsonSerializerOptions options)
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
