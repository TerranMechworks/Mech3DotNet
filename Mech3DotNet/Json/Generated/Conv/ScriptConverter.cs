using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ScriptConverter : StructConverter<Script>
    {
        protected override Script ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var lastModifiedField = new Option<DateTime>();
            var linesField = new Option<List<string>>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'Script'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "last_modified":
                        {
                            DateTime __value = ReadFieldValue<DateTime>(ref __reader, __options);
                            lastModifiedField.Set(__value);
                            break;
                        }
                    case "lines":
                        {
                            List<string>? __value = ReadFieldValue<List<string>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'lines' was null for 'Script'");
                                throw new JsonException();
                            }
                            linesField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Script'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var lastModified = lastModifiedField.Unwrap("last_modified");
            var lines = linesField.Unwrap("lines");
            return new Script(name, lastModified, lines);
        }

        public override void Write(Utf8JsonWriter writer, Script value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("last_modified");
            JsonSerializer.Serialize(writer, value.lastModified, options);
            writer.WritePropertyName("lines");
            JsonSerializer.Serialize(writer, value.lines, options);
            writer.WriteEndObject();
        }
    }
}
