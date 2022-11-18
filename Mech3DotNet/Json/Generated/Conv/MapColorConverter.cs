using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class MapColorConverter : StructConverter<MapColor>
    {
        protected override MapColor ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var rField = new Option<byte>();
            var gField = new Option<byte>();
            var bField = new Option<byte>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "r":
                        {
                            byte __value = ReadFieldValue<byte>(ref __reader, __options);
                            rField.Set(__value);
                            break;
                        }
                    case "g":
                        {
                            byte __value = ReadFieldValue<byte>(ref __reader, __options);
                            gField.Set(__value);
                            break;
                        }
                    case "b":
                        {
                            byte __value = ReadFieldValue<byte>(ref __reader, __options);
                            bField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'MapColor'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var r = rField.Unwrap("r");
            var g = gField.Unwrap("g");
            var b = bField.Unwrap("b");
            return new MapColor(r, g, b);
        }

        public override void Write(Utf8JsonWriter writer, MapColor value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("r");
            JsonSerializer.Serialize(writer, value.r, options);
            writer.WritePropertyName("g");
            JsonSerializer.Serialize(writer, value.g, options);
            writer.WritePropertyName("b");
            JsonSerializer.Serialize(writer, value.b, options);
            writer.WriteEndObject();
        }
    }
}
