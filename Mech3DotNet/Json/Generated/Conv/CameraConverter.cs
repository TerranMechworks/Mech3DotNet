using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class CameraConverter : StructConverter<Camera>
    {
        protected override Camera ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var clipField = new Option<Range>();
            var fovField = new Option<Range>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'Camera'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "clip":
                        {
                            Range __value = ReadFieldValue<Range>(ref __reader, __options);
                            clipField.Set(__value);
                            break;
                        }
                    case "fov":
                        {
                            Range __value = ReadFieldValue<Range>(ref __reader, __options);
                            fovField.Set(__value);
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
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Camera'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var clip = clipField.Unwrap("clip");
            var fov = fovField.Unwrap("fov");
            var dataPtr = dataPtrField.Unwrap("data_ptr");
            return new Camera(name, clip, fov, dataPtr);
        }

        public override void Write(Utf8JsonWriter writer, Camera value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("clip");
            JsonSerializer.Serialize(writer, value.clip, options);
            writer.WritePropertyName("fov");
            JsonSerializer.Serialize(writer, value.fov, options);
            writer.WritePropertyName("data_ptr");
            JsonSerializer.Serialize(writer, value.dataPtr, options);
            writer.WriteEndObject();
        }
    }
}
