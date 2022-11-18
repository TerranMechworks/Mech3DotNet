using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class FrameBufferEffectColorConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.FrameBufferEffectColor>
    {
        protected override Mech3DotNet.Json.Anim.Events.FrameBufferEffectColor ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var fromField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.Rgba>();
            var toField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.Rgba>();
            var runtimeField = new Mech3DotNet.Json.Converters.Option<float>();
            var fudgeAlphaField = new Mech3DotNet.Json.Converters.Option<bool>(false);
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "from":
                        {
                            Mech3DotNet.Json.Anim.Events.Rgba __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.Rgba>(ref __reader, __options);
                            fromField.Set(__value);
                            break;
                        }
                    case "to":
                        {
                            Mech3DotNet.Json.Anim.Events.Rgba __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.Rgba>(ref __reader, __options);
                            toField.Set(__value);
                            break;
                        }
                    case "runtime":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            runtimeField.Set(__value);
                            break;
                        }
                    case "fudge_alpha":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            fudgeAlphaField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'FrameBufferEffectColor'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var from = fromField.Unwrap("from");
            var to = toField.Unwrap("to");
            var runtime = runtimeField.Unwrap("runtime");
            var fudgeAlpha = fudgeAlphaField.Unwrap("fudge_alpha");
            return new Mech3DotNet.Json.Anim.Events.FrameBufferEffectColor(from, to, runtime, fudgeAlpha);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.FrameBufferEffectColor value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("from");
            JsonSerializer.Serialize(writer, value.from, options);
            writer.WritePropertyName("to");
            JsonSerializer.Serialize(writer, value.to, options);
            writer.WritePropertyName("runtime");
            JsonSerializer.Serialize(writer, value.runtime, options);
            if (value.fudgeAlpha != false)
            {
                writer.WritePropertyName("fudge_alpha");
                JsonSerializer.Serialize(writer, value.fudgeAlpha, options);
            }
            writer.WriteEndObject();
        }
    }
}
