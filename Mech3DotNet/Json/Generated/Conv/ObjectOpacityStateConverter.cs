using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectOpacityStateConverter : StructConverter<ObjectOpacityState>
    {
        protected override ObjectOpacityState ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Option<string>();
            var isSetField = new Option<bool>();
            var stateField = new Option<bool>();
            var opacityField = new Option<float>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'ObjectOpacityState'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "is_set":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            isSetField.Set(__value);
                            break;
                        }
                    case "state":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            stateField.Set(__value);
                            break;
                        }
                    case "opacity":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            opacityField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectOpacityState'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var isSet = isSetField.Unwrap("is_set");
            var state = stateField.Unwrap("state");
            var opacity = opacityField.Unwrap("opacity");
            return new ObjectOpacityState(node, isSet, state, opacity);
        }

        public override void Write(Utf8JsonWriter writer, ObjectOpacityState value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("is_set");
            JsonSerializer.Serialize(writer, value.isSet, options);
            writer.WritePropertyName("state");
            JsonSerializer.Serialize(writer, value.state, options);
            writer.WritePropertyName("opacity");
            JsonSerializer.Serialize(writer, value.opacity, options);
            writer.WriteEndObject();
        }
    }
}