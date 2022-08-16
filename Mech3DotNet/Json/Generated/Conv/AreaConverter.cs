using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class AreaConverter : StructConverter<Area>
    {
        protected override Area ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var leftField = new Option<int>();
            var topField = new Option<int>();
            var rightField = new Option<int>();
            var bottomField = new Option<int>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "left":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            leftField.Set(__value);
                            break;
                        }
                    case "top":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            topField.Set(__value);
                            break;
                        }
                    case "right":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            rightField.Set(__value);
                            break;
                        }
                    case "bottom":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            bottomField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Area'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var left = leftField.Unwrap("left");
            var top = topField.Unwrap("top");
            var right = rightField.Unwrap("right");
            var bottom = bottomField.Unwrap("bottom");
            return new Area(left, top, right, bottom);
        }

        public override void Write(Utf8JsonWriter writer, Area value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("left");
            JsonSerializer.Serialize(writer, value.left, options);
            writer.WritePropertyName("top");
            JsonSerializer.Serialize(writer, value.top, options);
            writer.WritePropertyName("right");
            JsonSerializer.Serialize(writer, value.right, options);
            writer.WritePropertyName("bottom");
            JsonSerializer.Serialize(writer, value.bottom, options);
            writer.WriteEndObject();
        }
    }
}