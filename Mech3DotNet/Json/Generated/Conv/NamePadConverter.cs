using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class NamePadConverter : StructConverter<NamePad>
    {
        protected override NamePad ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var padField = new Option<byte[]>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'NamePad'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "pad":
                        {
                            byte[]? __value = ReadFieldValue<byte[]?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'pad' was null for 'NamePad'");
                                throw new JsonException();
                            }
                            padField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'NamePad'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var pad = padField.Unwrap("pad");
            return new NamePad(name, pad);
        }

        public override void Write(Utf8JsonWriter writer, NamePad value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("pad");
            JsonSerializer.Serialize(writer, value.pad, options);
            writer.WriteEndObject();
        }
    }
}
