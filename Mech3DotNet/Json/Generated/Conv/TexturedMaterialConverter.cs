using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class TexturedMaterialConverter : StructConverter<TexturedMaterial>
    {
        protected override TexturedMaterial ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var textureField = new Option<string>();
            var pointerField = new Option<uint>(0);
            var cycleField = new Option<CycleData?>(null);
            var unk32Field = new Option<uint>();
            var flagField = new Option<bool>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "texture":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'texture' was null for 'TexturedMaterial'");
                                throw new JsonException();
                            }
                            textureField.Set(__value);
                            break;
                        }
                    case "pointer":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            pointerField.Set(__value);
                            break;
                        }
                    case "cycle":
                        {
                            CycleData? __value = ReadFieldValue<CycleData?>(ref __reader, __options);
                            cycleField.Set(__value);
                            break;
                        }
                    case "unk32":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk32Field.Set(__value);
                            break;
                        }
                    case "flag":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            flagField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'TexturedMaterial'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var texture = textureField.Unwrap("texture");
            var pointer = pointerField.Unwrap("pointer");
            var cycle = cycleField.Unwrap("cycle");
            var unk32 = unk32Field.Unwrap("unk32");
            var flag = flagField.Unwrap("flag");
            return new TexturedMaterial(texture, pointer, cycle, unk32, flag);
        }

        public override void Write(Utf8JsonWriter writer, TexturedMaterial value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("texture");
            JsonSerializer.Serialize(writer, value.texture, options);
            if (value.pointer != 0)
            {
                writer.WritePropertyName("pointer");
                JsonSerializer.Serialize(writer, value.pointer, options);
            }
            if (value.cycle != null)
            {
                writer.WritePropertyName("cycle");
                JsonSerializer.Serialize(writer, value.cycle, options);
            }
            writer.WritePropertyName("unk32");
            JsonSerializer.Serialize(writer, value.unk32, options);
            writer.WritePropertyName("flag");
            JsonSerializer.Serialize(writer, value.flag, options);
            writer.WriteEndObject();
        }
    }
}
