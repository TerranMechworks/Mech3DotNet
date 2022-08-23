using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class CallAnimationTargetNodeConverter : StructConverter<CallAnimationTargetNode>
    {
        protected override CallAnimationTargetNode ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var operandNodeField = new Option<string>();
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
            return new CallAnimationTargetNode(operandNode);
        }

        public override void Write(Utf8JsonWriter writer, CallAnimationTargetNode value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("operand_node");
            JsonSerializer.Serialize(writer, value.operandNode, options);
            writer.WriteEndObject();
        }
    }
}
