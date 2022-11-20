using System.Text.Json;

namespace Mech3DotNet.Json.Nodes.Converters
{
    public class AreaPartitionConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Nodes.AreaPartition>
    {
        protected override Mech3DotNet.Json.Nodes.AreaPartition ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var xField = new Mech3DotNet.Json.Converters.Option<int>();
            var yField = new Mech3DotNet.Json.Converters.Option<int>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "x":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            xField.Set(__value);
                            break;
                        }
                    case "y":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            yField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'AreaPartition'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var x = xField.Unwrap("x");
            var y = yField.Unwrap("y");
            return new Mech3DotNet.Json.Nodes.AreaPartition(x, y);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Nodes.AreaPartition value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("x");
            JsonSerializer.Serialize(writer, value.x, options);
            writer.WritePropertyName("y");
            JsonSerializer.Serialize(writer, value.y, options);
            writer.WriteEndObject();
        }
    }
}
