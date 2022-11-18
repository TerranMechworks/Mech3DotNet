using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Converters
{
    public class AnimNameConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.AnimName>
    {
        protected override Mech3DotNet.Json.Anim.AnimName ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var padField = new Mech3DotNet.Json.Converters.Option<byte[]>();
            var unknownField = new Mech3DotNet.Json.Converters.Option<uint>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'AnimName'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "pad":
                        {
                            byte[] __value = ReadFieldValue<byte[]>(ref __reader, __options);
                            padField.Set(__value);
                            break;
                        }
                    case "unknown":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unknownField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'AnimName'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var pad = padField.Unwrap("pad");
            var unknown = unknownField.Unwrap("unknown");
            return new Mech3DotNet.Json.Anim.AnimName(name, pad, unknown);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.AnimName value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("pad");
            JsonSerializer.Serialize(writer, value.pad, options);
            writer.WritePropertyName("unknown");
            JsonSerializer.Serialize(writer, value.unknown, options);
            writer.WriteEndObject();
        }
    }
}
