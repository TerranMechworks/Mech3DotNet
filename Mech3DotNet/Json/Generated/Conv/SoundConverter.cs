using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class SoundConverter : Mech3DotNet.Json.Converters.StructConverter<Sound>
    {
        protected override Sound ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var atNodeField = new Mech3DotNet.Json.Converters.Option<AtNode>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'Sound'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "at_node":
                        {
                            AtNode? __value = ReadFieldValue<AtNode?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'at_node' was null for 'Sound'");
                                throw new JsonException();
                            }
                            atNodeField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Sound'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var atNode = atNodeField.Unwrap("at_node");
            return new Sound(name, atNode);
        }

        public override void Write(Utf8JsonWriter writer, Sound value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("at_node");
            JsonSerializer.Serialize(writer, value.atNode, options);
            writer.WriteEndObject();
        }
    }
}
