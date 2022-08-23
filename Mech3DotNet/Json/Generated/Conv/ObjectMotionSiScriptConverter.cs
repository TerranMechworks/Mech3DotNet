using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectMotionSiScriptConverter : StructConverter<ObjectMotionSiScript>
    {
        protected override ObjectMotionSiScript ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Option<string>();
            var framesField = new Option<List<ObjectMotionSiFrame>>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'ObjectMotionSiScript'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "frames":
                        {
                            List<ObjectMotionSiFrame>? __value = ReadFieldValue<List<ObjectMotionSiFrame>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'frames' was null for 'ObjectMotionSiScript'");
                                throw new JsonException();
                            }
                            framesField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectMotionSiScript'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var frames = framesField.Unwrap("frames");
            return new ObjectMotionSiScript(node, frames);
        }

        public override void Write(Utf8JsonWriter writer, ObjectMotionSiScript value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("frames");
            JsonSerializer.Serialize(writer, value.frames, options);
            writer.WriteEndObject();
        }
    }
}
