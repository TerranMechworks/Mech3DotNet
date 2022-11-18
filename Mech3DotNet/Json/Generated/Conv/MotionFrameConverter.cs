using System.Text.Json;

namespace Mech3DotNet.Json.Motion.Converters
{
    public class MotionFrameConverter<TQuaternion, TVec3> : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Motion.MotionFrame<TQuaternion, TVec3>>
    {
        private readonly System.Type __translationType;
        private readonly System.Text.Json.Serialization.JsonConverter<TVec3>? __translationConverter;
        private readonly System.Type __rotationType;
        private readonly System.Text.Json.Serialization.JsonConverter<TQuaternion>? __rotationConverter;

        public MotionFrameConverter(JsonSerializerOptions options)
        {
            __translationType = typeof(TVec3);
            __translationConverter = (System.Text.Json.Serialization.JsonConverter<TVec3>?)options.GetConverter(__translationType);
            __rotationType = typeof(TQuaternion);
            __rotationConverter = (System.Text.Json.Serialization.JsonConverter<TQuaternion>?)options.GetConverter(__rotationType);
        }

        protected override Mech3DotNet.Json.Motion.MotionFrame<TQuaternion, TVec3> ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var translationField = new Mech3DotNet.Json.Converters.Option<TVec3>();
            var rotationField = new Mech3DotNet.Json.Converters.Option<TQuaternion>();
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
            return new Mech3DotNet.Json.Motion.MotionFrame<TQuaternion, TVec3>(translation, rotation);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Motion.MotionFrame<TQuaternion, TVec3> value, JsonSerializerOptions options)
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
