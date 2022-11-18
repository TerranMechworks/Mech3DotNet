using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectConnectorConverter : Mech3DotNet.Json.Converters.StructConverter<ObjectConnector>
    {
        protected override ObjectConnector ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Mech3DotNet.Json.Converters.Option<string>();
            var fromNodeField = new Mech3DotNet.Json.Converters.Option<string?>(null);
            var toNodeField = new Mech3DotNet.Json.Converters.Option<string?>(null);
            var fromPosField = new Mech3DotNet.Json.Converters.Option<Vec3?>(null);
            var toPosField = new Mech3DotNet.Json.Converters.Option<Vec3?>(null);
            var maxLengthField = new Mech3DotNet.Json.Converters.Option<float?>(null);
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "node":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'ObjectConnector'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "from_node":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            fromNodeField.Set(__value);
                            break;
                        }
                    case "to_node":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            toNodeField.Set(__value);
                            break;
                        }
                    case "from_pos":
                        {
                            Vec3? __value = ReadFieldValue<Vec3?>(ref __reader, __options);
                            fromPosField.Set(__value);
                            break;
                        }
                    case "to_pos":
                        {
                            Vec3? __value = ReadFieldValue<Vec3?>(ref __reader, __options);
                            toPosField.Set(__value);
                            break;
                        }
                    case "max_length":
                        {
                            float? __value = ReadFieldValue<float?>(ref __reader, __options);
                            maxLengthField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectConnector'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var fromNode = fromNodeField.Unwrap("from_node");
            var toNode = toNodeField.Unwrap("to_node");
            var fromPos = fromPosField.Unwrap("from_pos");
            var toPos = toPosField.Unwrap("to_pos");
            var maxLength = maxLengthField.Unwrap("max_length");
            return new ObjectConnector(node, fromNode, toNode, fromPos, toPos, maxLength);
        }

        public override void Write(Utf8JsonWriter writer, ObjectConnector value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            if (value.fromNode != null)
            {
                writer.WritePropertyName("from_node");
                JsonSerializer.Serialize(writer, value.fromNode, options);
            }
            if (value.toNode != null)
            {
                writer.WritePropertyName("to_node");
                JsonSerializer.Serialize(writer, value.toNode, options);
            }
            if (value.fromPos != null)
            {
                writer.WritePropertyName("from_pos");
                JsonSerializer.Serialize(writer, value.fromPos, options);
            }
            if (value.toPos != null)
            {
                writer.WritePropertyName("to_pos");
                JsonSerializer.Serialize(writer, value.toPos, options);
            }
            if (value.maxLength != null)
            {
                writer.WritePropertyName("max_length");
                JsonSerializer.Serialize(writer, value.maxLength, options);
            }
            writer.WriteEndObject();
        }
    }
}
