using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectOpacityFromToConverter : StructConverter<ObjectOpacityFromTo>
    {
        protected override ObjectOpacityFromTo ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Option<string>();
            var opacityFromField = new Option<ObjectOpacity>();
            var opacityToField = new Option<ObjectOpacity>();
            var runtimeField = new Option<float>();
            var fudgeField = new Option<bool>(false);
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
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'ObjectOpacityFromTo'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "opacity_from":
                        {
                            ObjectOpacity __value = ReadFieldValue<ObjectOpacity>(ref __reader, __options);
                            opacityFromField.Set(__value);
                            break;
                        }
                    case "opacity_to":
                        {
                            ObjectOpacity __value = ReadFieldValue<ObjectOpacity>(ref __reader, __options);
                            opacityToField.Set(__value);
                            break;
                        }
                    case "runtime":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            runtimeField.Set(__value);
                            break;
                        }
                    case "fudge":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            fudgeField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectOpacityFromTo'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var opacityFrom = opacityFromField.Unwrap("opacity_from");
            var opacityTo = opacityToField.Unwrap("opacity_to");
            var runtime = runtimeField.Unwrap("runtime");
            var fudge = fudgeField.Unwrap("fudge");
            return new ObjectOpacityFromTo(node, opacityFrom, opacityTo, runtime, fudge);
        }

        public override void Write(Utf8JsonWriter writer, ObjectOpacityFromTo value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("opacity_from");
            JsonSerializer.Serialize(writer, value.opacityFrom, options);
            writer.WritePropertyName("opacity_to");
            JsonSerializer.Serialize(writer, value.opacityTo, options);
            writer.WritePropertyName("runtime");
            JsonSerializer.Serialize(writer, value.runtime, options);
            if (value.fudge != false)
            {
                writer.WritePropertyName("fudge");
                JsonSerializer.Serialize(writer, value.fudge, options);
            }
            writer.WriteEndObject();
        }
    }
}
