using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class PrereqParentConverter : StructConverter<PrereqParent>
    {
        protected override PrereqParent ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var requiredField = new Option<bool>();
            var activeField = new Option<bool>();
            var pointerField = new Option<uint>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'PrereqParent'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "required":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            requiredField.Set(__value);
                            break;
                        }
                    case "active":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            activeField.Set(__value);
                            break;
                        }
                    case "pointer":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            pointerField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'PrereqParent'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var required = requiredField.Unwrap("required");
            var active = activeField.Unwrap("active");
            var pointer = pointerField.Unwrap("pointer");
            return new PrereqParent(name, required, active, pointer);
        }

        public override void Write(Utf8JsonWriter writer, PrereqParent value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("required");
            JsonSerializer.Serialize(writer, value.required, options);
            writer.WritePropertyName("active");
            JsonSerializer.Serialize(writer, value.active, options);
            writer.WritePropertyName("pointer");
            JsonSerializer.Serialize(writer, value.pointer, options);
            writer.WriteEndObject();
        }
    }
}
