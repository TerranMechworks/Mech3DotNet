using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class CallAnimationTargetNodeConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.CallAnimationTargetNode>
    {
        protected override Mech3DotNet.Json.Anim.Events.CallAnimationTargetNode ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var operandNodeField = new Mech3DotNet.Json.Converters.Option<string>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "operand_node":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'operand_node' was null for 'CallAnimationTargetNode'");
                                throw new JsonException();
                            }
                            operandNodeField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'CallAnimationTargetNode'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var operandNode = operandNodeField.Unwrap("operand_node");
            return new Mech3DotNet.Json.Anim.Events.CallAnimationTargetNode(operandNode);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.CallAnimationTargetNode value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("operand_node");
            JsonSerializer.Serialize(writer, value.operandNode, options);
            writer.WriteEndObject();
        }
    }
}
