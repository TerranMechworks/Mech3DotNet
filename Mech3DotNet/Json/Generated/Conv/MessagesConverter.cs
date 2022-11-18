using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class MessagesConverter : Mech3DotNet.Json.Converters.StructConverter<Messages>
    {
        protected override Messages ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var languageIdField = new Mech3DotNet.Json.Converters.Option<uint>();
            var entriesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<MessageEntry>>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "language_id":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            languageIdField.Set(__value);
                            break;
                        }
                    case "entries":
                        {
                            System.Collections.Generic.List<MessageEntry>? __value = ReadFieldValue<System.Collections.Generic.List<MessageEntry>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'entries' was null for 'Messages'");
                                throw new JsonException();
                            }
                            entriesField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Messages'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var languageId = languageIdField.Unwrap("language_id");
            var entries = entriesField.Unwrap("entries");
            return new Messages(languageId, entries);
        }

        public override void Write(Utf8JsonWriter writer, Messages value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("language_id");
            JsonSerializer.Serialize(writer, value.languageId, options);
            writer.WritePropertyName("entries");
            JsonSerializer.Serialize(writer, value.entries, options);
            writer.WriteEndObject();
        }
    }
}
