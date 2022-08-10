using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class GlobalPaletteConverter : StructConverter<GlobalPalette>
    {
        protected override GlobalPalette ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var indexField = new Option<int>();
            var countField = new Option<ushort>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "index":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            indexField.Set(__value);
                            break;
                        }
                    case "count":
                        {
                            ushort __value = ReadFieldValue<ushort>(ref __reader, __options);
                            countField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'GlobalPalette'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var index = indexField.Unwrap("index");
            var count = countField.Unwrap("count");
            return new GlobalPalette(index, count);
        }

        public override void Write(Utf8JsonWriter writer, GlobalPalette value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("index");
            JsonSerializer.Serialize(writer, value.index, options);
            writer.WritePropertyName("count");
            JsonSerializer.Serialize(writer, value.count, options);
            writer.WriteEndObject();
        }
    }
}
