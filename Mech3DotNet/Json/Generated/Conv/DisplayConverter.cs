using System.Text.Json;

namespace Mech3DotNet.Json.Nodes.Mw.Converters
{
    public class DisplayConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Nodes.Mw.Display>
    {
        protected override Mech3DotNet.Json.Nodes.Mw.Display ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var resolutionXField = new Mech3DotNet.Json.Converters.Option<uint>();
            var resolutionYField = new Mech3DotNet.Json.Converters.Option<uint>();
            var clearColorField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Color>();
            var dataPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'Display'");
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
                    case "clear_color":
                        {
                            Mech3DotNet.Json.Types.Color __value = ReadFieldValue<Mech3DotNet.Json.Types.Color>(ref __reader, __options);
                            clearColorField.Set(__value);
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
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Display'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var resolutionX = resolutionXField.Unwrap("resolution_x");
            var resolutionY = resolutionYField.Unwrap("resolution_y");
            var clearColor = clearColorField.Unwrap("clear_color");
            var dataPtr = dataPtrField.Unwrap("data_ptr");
            return new Mech3DotNet.Json.Nodes.Mw.Display(name, resolutionX, resolutionY, clearColor, dataPtr);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Nodes.Mw.Display value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("resolution_x");
            JsonSerializer.Serialize(writer, value.resolutionX, options);
            writer.WritePropertyName("resolution_y");
            JsonSerializer.Serialize(writer, value.resolutionY, options);
            writer.WritePropertyName("clear_color");
            JsonSerializer.Serialize(writer, value.clearColor, options);
            writer.WritePropertyName("data_ptr");
            JsonSerializer.Serialize(writer, value.dataPtr, options);
            writer.WriteEndObject();
        }
    }
}
