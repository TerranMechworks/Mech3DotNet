using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class LightStateConverter : StructConverter<LightState>
    {
        protected override LightState ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var activeStateField = new Option<bool>();
            var directionalField = new Option<bool?>(null);
            var saturatedField = new Option<bool?>(null);
            var subdivideField = new Option<bool?>(null);
            var static_Field = new Option<bool?>(null);
            var atNodeField = new Option<AtNode?>(null);
            var rangeField = new Option<Range?>(null);
            var colorField = new Option<Color?>(null);
            var ambientField = new Option<float?>(null);
            var diffuseField = new Option<float?>(null);
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "name":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'LightState'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "active_state":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            activeStateField.Set(__value);
                            break;
                        }
                    case "directional":
                        {
                            bool? __value = ReadFieldValue<bool?>(ref __reader, __options);
                            directionalField.Set(__value);
                            break;
                        }
                    case "saturated":
                        {
                            bool? __value = ReadFieldValue<bool?>(ref __reader, __options);
                            saturatedField.Set(__value);
                            break;
                        }
                    case "subdivide":
                        {
                            bool? __value = ReadFieldValue<bool?>(ref __reader, __options);
                            subdivideField.Set(__value);
                            break;
                        }
                    case "static_":
                        {
                            bool? __value = ReadFieldValue<bool?>(ref __reader, __options);
                            static_Field.Set(__value);
                            break;
                        }
                    case "at_node":
                        {
                            AtNode? __value = ReadFieldValue<AtNode?>(ref __reader, __options);
                            atNodeField.Set(__value);
                            break;
                        }
                    case "range":
                        {
                            Range? __value = ReadFieldValue<Range?>(ref __reader, __options);
                            rangeField.Set(__value);
                            break;
                        }
                    case "color":
                        {
                            Color? __value = ReadFieldValue<Color?>(ref __reader, __options);
                            colorField.Set(__value);
                            break;
                        }
                    case "ambient":
                        {
                            float? __value = ReadFieldValue<float?>(ref __reader, __options);
                            ambientField.Set(__value);
                            break;
                        }
                    case "diffuse":
                        {
                            float? __value = ReadFieldValue<float?>(ref __reader, __options);
                            diffuseField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'LightState'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var activeState = activeStateField.Unwrap("active_state");
            var directional = directionalField.Unwrap("directional");
            var saturated = saturatedField.Unwrap("saturated");
            var subdivide = subdivideField.Unwrap("subdivide");
            var static_ = static_Field.Unwrap("static_");
            var atNode = atNodeField.Unwrap("at_node");
            var range = rangeField.Unwrap("range");
            var color = colorField.Unwrap("color");
            var ambient = ambientField.Unwrap("ambient");
            var diffuse = diffuseField.Unwrap("diffuse");
            return new LightState(name, activeState, directional, saturated, subdivide, static_, atNode, range, color, ambient, diffuse);
        }

        public override void Write(Utf8JsonWriter writer, LightState value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("active_state");
            JsonSerializer.Serialize(writer, value.activeState, options);
            if (value.directional != null)
            {
                writer.WritePropertyName("directional");
                JsonSerializer.Serialize(writer, value.directional, options);
            }
            if (value.saturated != null)
            {
                writer.WritePropertyName("saturated");
                JsonSerializer.Serialize(writer, value.saturated, options);
            }
            if (value.subdivide != null)
            {
                writer.WritePropertyName("subdivide");
                JsonSerializer.Serialize(writer, value.subdivide, options);
            }
            if (value.static_ != null)
            {
                writer.WritePropertyName("static_");
                JsonSerializer.Serialize(writer, value.static_, options);
            }
            if (value.atNode != null)
            {
                writer.WritePropertyName("at_node");
                JsonSerializer.Serialize(writer, value.atNode, options);
            }
            if (value.range != null)
            {
                writer.WritePropertyName("range");
                JsonSerializer.Serialize(writer, value.range, options);
            }
            if (value.color != null)
            {
                writer.WritePropertyName("color");
                JsonSerializer.Serialize(writer, value.color, options);
            }
            if (value.ambient != null)
            {
                writer.WritePropertyName("ambient");
                JsonSerializer.Serialize(writer, value.ambient, options);
            }
            if (value.diffuse != null)
            {
                writer.WritePropertyName("diffuse");
                JsonSerializer.Serialize(writer, value.diffuse, options);
            }
            writer.WriteEndObject();
        }
    }
}
