using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Converters
{
    public class NamePtrFlagsConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.NamePtrFlags>
    {
        protected override Mech3DotNet.Json.Anim.NamePtrFlags ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var pointerField = new Mech3DotNet.Json.Converters.Option<uint>();
            var flagsField = new Mech3DotNet.Json.Converters.Option<uint>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'NamePtrFlags'");
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
                    case "flags":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            flagsField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'NamePtrFlags'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var pointer = pointerField.Unwrap("pointer");
            var flags = flagsField.Unwrap("flags");
            return new Mech3DotNet.Json.Anim.NamePtrFlags(name, pointer, flags);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.NamePtrFlags value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("pointer");
            JsonSerializer.Serialize(writer, value.pointer, options);
            writer.WritePropertyName("flags");
            JsonSerializer.Serialize(writer, value.flags, options);
            writer.WriteEndObject();
        }
    }
}
