using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class MessageEntryConverter : Mech3DotNet.Json.Converters.StructConverter<MessageEntry>
    {
        protected override MessageEntry ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var keyField = new Mech3DotNet.Json.Converters.Option<string>();
            var idField = new Mech3DotNet.Json.Converters.Option<uint>();
            var valueField = new Mech3DotNet.Json.Converters.Option<string>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "key":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'key' was null for 'MessageEntry'");
                                throw new JsonException();
                            }
                            keyField.Set(__value);
                            break;
                        }
                    case "id":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            idField.Set(__value);
                            break;
                        }
                    case "value":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'value' was null for 'MessageEntry'");
                                throw new JsonException();
                            }
                            valueField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'MessageEntry'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var key = keyField.Unwrap("key");
            var id = idField.Unwrap("id");
            var value = valueField.Unwrap("value");
            return new MessageEntry(key, id, value);
        }

        public override void Write(Utf8JsonWriter writer, MessageEntry value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("key");
            JsonSerializer.Serialize(writer, value.key, options);
            writer.WritePropertyName("id");
            JsonSerializer.Serialize(writer, value.id, options);
            writer.WritePropertyName("value");
            JsonSerializer.Serialize(writer, value.value, options);
            writer.WriteEndObject();
        }
    }
}
