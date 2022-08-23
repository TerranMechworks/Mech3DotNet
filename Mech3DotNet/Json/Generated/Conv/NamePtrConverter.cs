using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class NamePtrConverter : StructConverter<NamePtr>
    {
        protected override NamePtr ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'NamePtr'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
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
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'NamePtr'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var pointer = pointerField.Unwrap("pointer");
            return new NamePtr(name, pointer);
        }

        public override void Write(Utf8JsonWriter writer, NamePtr value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("pointer");
            JsonSerializer.Serialize(writer, value.pointer, options);
            writer.WriteEndObject();
        }
    }
}