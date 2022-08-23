using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class BounceSoundConverter : StructConverter<BounceSound>
    {
        protected override BounceSound ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var volumeField = new Option<float>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'BounceSound'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "volume":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            volumeField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'BounceSound'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var volume = volumeField.Unwrap("volume");
            return new BounceSound(name, volume);
        }

        public override void Write(Utf8JsonWriter writer, BounceSound value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("volume");
            JsonSerializer.Serialize(writer, value.volume, options);
            writer.WriteEndObject();
        }
    }
}
