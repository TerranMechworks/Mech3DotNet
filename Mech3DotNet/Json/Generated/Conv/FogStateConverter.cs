using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class FogStateConverter : StructConverter<FogState>
    {
        protected override FogState ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var fogTypeField = new Option<FogType>();
            var colorField = new Option<Color>();
            var altitudeField = new Option<Range>();
            var rangeField = new Option<Range>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'FogState'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "fog_type":
                        {
                            FogType __value = ReadFieldValue<FogType>(ref __reader, __options);
                            fogTypeField.Set(__value);
                            break;
                        }
                    case "color":
                        {
                            Color __value = ReadFieldValue<Color>(ref __reader, __options);
                            colorField.Set(__value);
                            break;
                        }
                    case "altitude":
                        {
                            Range __value = ReadFieldValue<Range>(ref __reader, __options);
                            altitudeField.Set(__value);
                            break;
                        }
                    case "range":
                        {
                            Range __value = ReadFieldValue<Range>(ref __reader, __options);
                            rangeField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'FogState'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var fogType = fogTypeField.Unwrap("fog_type");
            var color = colorField.Unwrap("color");
            var altitude = altitudeField.Unwrap("altitude");
            var range = rangeField.Unwrap("range");
            return new FogState(name, fogType, color, altitude, range);
        }

        public override void Write(Utf8JsonWriter writer, FogState value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("fog_type");
            JsonSerializer.Serialize(writer, value.fogType, options);
            writer.WritePropertyName("color");
            JsonSerializer.Serialize(writer, value.color, options);
            writer.WritePropertyName("altitude");
            JsonSerializer.Serialize(writer, value.altitude, options);
            writer.WritePropertyName("range");
            JsonSerializer.Serialize(writer, value.range, options);
            writer.WriteEndObject();
        }
    }
}
