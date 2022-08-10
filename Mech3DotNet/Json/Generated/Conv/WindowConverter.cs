using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class WindowConverter : StructConverter<Window>
    {
        protected override Window ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var resolutionXField = new Option<uint>();
            var resolutionYField = new Option<uint>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'Window'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "resolution_x":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            resolutionXField.Set(__value);
                            break;
                        }
                    case "resolution_y":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            resolutionYField.Set(__value);
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
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Window'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var resolutionX = resolutionXField.Unwrap("resolution_x");
            var resolutionY = resolutionYField.Unwrap("resolution_y");
            var dataPtr = dataPtrField.Unwrap("data_ptr");
            return new Window(name, resolutionX, resolutionY, dataPtr);
        }

        public override void Write(Utf8JsonWriter writer, Window value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("resolution_x");
            JsonSerializer.Serialize(writer, value.resolutionX, options);
            writer.WritePropertyName("resolution_y");
            JsonSerializer.Serialize(writer, value.resolutionY, options);
            writer.WritePropertyName("data_ptr");
            JsonSerializer.Serialize(writer, value.dataPtr, options);
            writer.WriteEndObject();
        }
    }
}
