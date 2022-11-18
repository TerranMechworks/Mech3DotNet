using System.Text.Json;

namespace Mech3DotNet.Json.Gamez.Nodes.Converters
{
    public class LightConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Gamez.Nodes.Light>
    {
        protected override Mech3DotNet.Json.Gamez.Nodes.Light ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var directionField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3>();
            var diffuseField = new Mech3DotNet.Json.Converters.Option<float>();
            var ambientField = new Mech3DotNet.Json.Converters.Option<float>();
            var colorField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Color>();
            var rangeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Range>();
            var parentPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'Light'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "direction":
                        {
                            Mech3DotNet.Json.Types.Vec3 __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3>(ref __reader, __options);
                            directionField.Set(__value);
                            break;
                        }
                    case "diffuse":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            diffuseField.Set(__value);
                            break;
                        }
                    case "ambient":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            ambientField.Set(__value);
                            break;
                        }
                    case "color":
                        {
                            Mech3DotNet.Json.Types.Color __value = ReadFieldValue<Mech3DotNet.Json.Types.Color>(ref __reader, __options);
                            colorField.Set(__value);
                            break;
                        }
                    case "range":
                        {
                            Mech3DotNet.Json.Types.Range __value = ReadFieldValue<Mech3DotNet.Json.Types.Range>(ref __reader, __options);
                            rangeField.Set(__value);
                            break;
                        }
                    case "parent_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            parentPtrField.Set(__value);
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
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Light'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var direction = directionField.Unwrap("direction");
            var diffuse = diffuseField.Unwrap("diffuse");
            var ambient = ambientField.Unwrap("ambient");
            var color = colorField.Unwrap("color");
            var range = rangeField.Unwrap("range");
            var parentPtr = parentPtrField.Unwrap("parent_ptr");
            var dataPtr = dataPtrField.Unwrap("data_ptr");
            return new Mech3DotNet.Json.Gamez.Nodes.Light(name, direction, diffuse, ambient, color, range, parentPtr, dataPtr);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Gamez.Nodes.Light value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("direction");
            JsonSerializer.Serialize(writer, value.direction, options);
            writer.WritePropertyName("diffuse");
            JsonSerializer.Serialize(writer, value.diffuse, options);
            writer.WritePropertyName("ambient");
            JsonSerializer.Serialize(writer, value.ambient, options);
            writer.WritePropertyName("color");
            JsonSerializer.Serialize(writer, value.color, options);
            writer.WritePropertyName("range");
            JsonSerializer.Serialize(writer, value.range, options);
            writer.WritePropertyName("parent_ptr");
            JsonSerializer.Serialize(writer, value.parentPtr, options);
            writer.WritePropertyName("data_ptr");
            JsonSerializer.Serialize(writer, value.dataPtr, options);
            writer.WriteEndObject();
        }
    }
}
