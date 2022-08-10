using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ColoredMaterialConverter : StructConverter<ColoredMaterial>
    {
        protected override ColoredMaterial ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var colorField = new Option<Color>();
            var unk00Field = new Option<byte>();
            var unk32Field = new Option<uint>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "color":
                        {
                            Color __value = ReadFieldValue<Color>(ref __reader, __options);
                            colorField.Set(__value);
                            break;
                        }
                    case "unk00":
                        {
                            byte __value = ReadFieldValue<byte>(ref __reader, __options);
                            unk00Field.Set(__value);
                            break;
                        }
                    case "unk32":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk32Field.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ColoredMaterial'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var color = colorField.Unwrap("color");
            var unk00 = unk00Field.Unwrap("unk00");
            var unk32 = unk32Field.Unwrap("unk32");
            return new ColoredMaterial(color, unk00, unk32);
        }

        public override void Write(Utf8JsonWriter writer, ColoredMaterial value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("color");
            JsonSerializer.Serialize(writer, value.color, options);
            writer.WritePropertyName("unk00");
            JsonSerializer.Serialize(writer, value.unk00, options);
            writer.WritePropertyName("unk32");
            JsonSerializer.Serialize(writer, value.unk32, options);
            writer.WriteEndObject();
        }
    }
}
