using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class CallObjectConnectorConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.CallObjectConnector>
    {
        protected override Mech3DotNet.Json.Anim.Events.CallObjectConnector ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Mech3DotNet.Json.Converters.Option<string>();
            var fromNodeField = new Mech3DotNet.Json.Converters.Option<string>();
            var toNodeField = new Mech3DotNet.Json.Converters.Option<string>();
            var toPosField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'CallObjectConnector'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "from_node":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'from_node' was null for 'CallObjectConnector'");
                                throw new JsonException();
                            }
                            fromNodeField.Set(__value);
                            break;
                        }
                    case "to_node":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'to_node' was null for 'CallObjectConnector'");
                                throw new JsonException();
                            }
                            toNodeField.Set(__value);
                            break;
                        }
                    case "to_pos":
                        {
                            Mech3DotNet.Json.Types.Vec3 __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3>(ref __reader, __options);
                            toPosField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'CallObjectConnector'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var fromNode = fromNodeField.Unwrap("from_node");
            var toNode = toNodeField.Unwrap("to_node");
            var toPos = toPosField.Unwrap("to_pos");
            return new Mech3DotNet.Json.Anim.Events.CallObjectConnector(node, fromNode, toNode, toPos);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.CallObjectConnector value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("from_node");
            JsonSerializer.Serialize(writer, value.fromNode, options);
            writer.WritePropertyName("to_node");
            JsonSerializer.Serialize(writer, value.toNode, options);
            writer.WritePropertyName("to_pos");
            JsonSerializer.Serialize(writer, value.toPos, options);
            writer.WriteEndObject();
        }
    }
}
