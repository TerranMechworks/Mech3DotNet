using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectTranslateStateConverter : StructConverter<ObjectTranslateState>
    {
        protected override ObjectTranslateState ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Option<string>();
            var translateField = new Option<Vec3>();
            var atNodeField = new Option<string?>(null);
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
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'ObjectTranslateState'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "translate":
                        {
                            Vec3 __value = ReadFieldValue<Vec3>(ref __reader, __options);
                            translateField.Set(__value);
                            break;
                        }
                    case "at_node":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            atNodeField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectTranslateState'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var translate = translateField.Unwrap("translate");
            var atNode = atNodeField.Unwrap("at_node");
            return new ObjectTranslateState(node, translate, atNode);
        }

        public override void Write(Utf8JsonWriter writer, ObjectTranslateState value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("translate");
            JsonSerializer.Serialize(writer, value.translate, options);
            if (value.atNode != null)
            {
                writer.WritePropertyName("at_node");
                JsonSerializer.Serialize(writer, value.atNode, options);
            }
            writer.WriteEndObject();
        }
    }
}
