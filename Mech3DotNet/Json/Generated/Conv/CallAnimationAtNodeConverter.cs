using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class CallAnimationAtNodeConverter : StructConverter<CallAnimationAtNode>
    {
        protected override CallAnimationAtNode ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Option<string>();
            var translationField = new Option<Vec3?>();
            var rotationField = new Option<Vec3?>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'CallAnimationAtNode'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "translation":
                        {
                            Vec3? __value = ReadFieldValue<Vec3?>(ref __reader, __options);
                            translationField.Set(__value);
                            break;
                        }
                    case "rotation":
                        {
                            Vec3? __value = ReadFieldValue<Vec3?>(ref __reader, __options);
                            rotationField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'CallAnimationAtNode'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var translation = translationField.Unwrap("translation");
            var rotation = rotationField.Unwrap("rotation");
            return new CallAnimationAtNode(node, translation, rotation);
        }

        public override void Write(Utf8JsonWriter writer, CallAnimationAtNode value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("translation");
            JsonSerializer.Serialize(writer, value.translation, options);
            writer.WritePropertyName("rotation");
            JsonSerializer.Serialize(writer, value.rotation, options);
            writer.WriteEndObject();
        }
    }
}
