using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class FrameBufferEffectColorConverter : StructConverter<FrameBufferEffectColor>
    {
        protected override FrameBufferEffectColor ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var fromField = new Option<Rgba>();
            var toField = new Option<Rgba>();
            var runtimeField = new Option<float>();
            var fudgeAlphaField = new Option<bool>(false);
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "from":
                        {
                            Rgba __value = ReadFieldValue<Rgba>(ref __reader, __options);
                            fromField.Set(__value);
                            break;
                        }
                    case "to":
                        {
                            Rgba __value = ReadFieldValue<Rgba>(ref __reader, __options);
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
            return new FrameBufferEffectColor(from, to, runtime, fudgeAlpha);
        }

        public override void Write(Utf8JsonWriter writer, FrameBufferEffectColor value, JsonSerializerOptions options)
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
