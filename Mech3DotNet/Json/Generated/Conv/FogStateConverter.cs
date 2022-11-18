using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class FogStateConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.FogState>
    {
        protected override Mech3DotNet.Json.Anim.Events.FogState ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var fogTypeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.FogType>();
            var colorField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Color>();
            var altitudeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Range>();
            var rangeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Range>();
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
                            Mech3DotNet.Json.Anim.Events.FogType __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.FogType>(ref __reader, __options);
                            fogTypeField.Set(__value);
                            break;
                        }
                    case "color":
                        {
                            Mech3DotNet.Json.Types.Color __value = ReadFieldValue<Mech3DotNet.Json.Types.Color>(ref __reader, __options);
                            colorField.Set(__value);
                            break;
                        }
                    case "altitude":
                        {
                            Mech3DotNet.Json.Types.Range __value = ReadFieldValue<Mech3DotNet.Json.Types.Range>(ref __reader, __options);
                            altitudeField.Set(__value);
                            break;
                        }
                    case "range":
                        {
                            Mech3DotNet.Json.Types.Range __value = ReadFieldValue<Mech3DotNet.Json.Types.Range>(ref __reader, __options);
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
            return new Mech3DotNet.Json.Anim.Events.FogState(name, fogType, color, altitude, range);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.FogState value, JsonSerializerOptions options)
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
