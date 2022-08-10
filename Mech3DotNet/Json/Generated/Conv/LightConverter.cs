using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class LightConverter : StructConverter<Light>
    {
        protected override Light ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var directionField = new Option<Vec3>();
            var diffuseField = new Option<float>();
            var ambientField = new Option<float>();
            var colorField = new Option<Color>();
            var rangeField = new Option<Range>();
            var parentPtrField = new Option<uint>();
            var dataPtrField = new Option<uint>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'Light'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "direction":
                        {
                            Vec3 __value = ReadFieldValue<Vec3>(ref __reader, __options);
                            directionField.Set(__value);
                            break;
                        }
                    case "diffuse":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            diffuseField.Set(__value);
                            break;
                        }
                    case "ambient":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            ambientField.Set(__value);
                            break;
                        }
                    case "color":
                        {
                            Color __value = ReadFieldValue<Color>(ref __reader, __options);
                            colorField.Set(__value);
                            break;
                        }
                    case "range":
                        {
                            Range __value = ReadFieldValue<Range>(ref __reader, __options);
                            rangeField.Set(__value);
                            break;
                        }
                    case "parent_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            parentPtrField.Set(__value);
                            break;
                        }
                    case "data_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            dataPtrField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Light'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var direction = directionField.Unwrap("direction");
            var diffuse = diffuseField.Unwrap("diffuse");
            var ambient = ambientField.Unwrap("ambient");
            var color = colorField.Unwrap("color");
            var range = rangeField.Unwrap("range");
            var parentPtr = parentPtrField.Unwrap("parent_ptr");
            var dataPtr = dataPtrField.Unwrap("data_ptr");
            return new Light(name, direction, diffuse, ambient, color, range, parentPtr, dataPtr);
        }

        public override void Write(Utf8JsonWriter writer, Light value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("direction");
            JsonSerializer.Serialize(writer, value.direction, options);
            writer.WritePropertyName("diffuse");
            JsonSerializer.Serialize(writer, value.diffuse, options);
            writer.WritePropertyName("ambient");
            JsonSerializer.Serialize(writer, value.ambient, options);
            writer.WritePropertyName("color");
            JsonSerializer.Serialize(writer, value.color, options);
            writer.WritePropertyName("range");
            JsonSerializer.Serialize(writer, value.range, options);
            writer.WritePropertyName("parent_ptr");
            JsonSerializer.Serialize(writer, value.parentPtr, options);
            writer.WritePropertyName("data_ptr");
            JsonSerializer.Serialize(writer, value.dataPtr, options);
            writer.WriteEndObject();
        }
    }
}
