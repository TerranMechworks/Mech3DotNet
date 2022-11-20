using System.Text.Json;

namespace Mech3DotNet.Json.Nodes.Converters
{
    public class AreaConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Nodes.Area>
    {
        protected override Mech3DotNet.Json.Nodes.Area ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var leftField = new Mech3DotNet.Json.Converters.Option<int>();
            var topField = new Mech3DotNet.Json.Converters.Option<int>();
            var rightField = new Mech3DotNet.Json.Converters.Option<int>();
            var bottomField = new Mech3DotNet.Json.Converters.Option<int>();
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
            return new Mech3DotNet.Json.Nodes.Area(left, top, right, bottom);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Nodes.Area value, JsonSerializerOptions options)
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
