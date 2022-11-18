using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Converters
{
    public class PrereqObjectConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.PrereqObject>
    {
        protected override Mech3DotNet.Json.Anim.PrereqObject ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var requiredField = new Mech3DotNet.Json.Converters.Option<bool>();
            var activeField = new Mech3DotNet.Json.Converters.Option<bool>();
            var pointerField = new Mech3DotNet.Json.Converters.Option<uint>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'PrereqObject'");
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
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'PrereqObject'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var required = requiredField.Unwrap("required");
            var active = activeField.Unwrap("active");
            var pointer = pointerField.Unwrap("pointer");
            return new Mech3DotNet.Json.Anim.PrereqObject(name, required, active, pointer);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.PrereqObject value, JsonSerializerOptions options)
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
