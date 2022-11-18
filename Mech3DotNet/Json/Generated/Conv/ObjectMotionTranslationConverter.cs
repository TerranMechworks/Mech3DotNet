using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class ObjectMotionTranslationConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.ObjectMotionTranslation>
    {
        protected override Mech3DotNet.Json.Anim.Events.ObjectMotionTranslation ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var deltaField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3>();
            var initialField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3>();
            var unkField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "delta":
                        {
                            Mech3DotNet.Json.Types.Vec3 __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3>(ref __reader, __options);
                            deltaField.Set(__value);
                            break;
                        }
                    case "initial":
                        {
                            Mech3DotNet.Json.Types.Vec3 __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3>(ref __reader, __options);
                            initialField.Set(__value);
                            break;
                        }
                    case "unk":
                        {
                            Mech3DotNet.Json.Types.Vec3 __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3>(ref __reader, __options);
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
            return new Mech3DotNet.Json.Anim.Events.ObjectMotionTranslation(delta, initial, unk);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.ObjectMotionTranslation value, JsonSerializerOptions options)
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
