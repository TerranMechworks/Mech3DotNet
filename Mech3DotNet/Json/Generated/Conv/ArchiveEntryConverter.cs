using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ArchiveEntryConverter : StructConverter<ArchiveEntry>
    {
        protected override ArchiveEntry ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var garbageField = new Option<byte[]>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'ArchiveEntry'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "garbage":
                        {
                            byte[]? __value = ReadFieldValue<byte[]?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'garbage' was null for 'ArchiveEntry'");
                                throw new JsonException();
                            }
                            garbageField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ArchiveEntry'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var garbage = garbageField.Unwrap("garbage");
            return new ArchiveEntry(name, garbage);
        }

        public override void Write(Utf8JsonWriter writer, ArchiveEntry value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("garbage");
            JsonSerializer.Serialize(writer, value.garbage, options);
            writer.WriteEndObject();
        }
    }
}
