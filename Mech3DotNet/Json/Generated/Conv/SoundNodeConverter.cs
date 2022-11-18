using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class SoundNodeConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.SoundNode>
    {
        protected override Mech3DotNet.Json.Anim.Events.SoundNode ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var activeStateField = new Mech3DotNet.Json.Converters.Option<bool>();
            var atNodeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.AtNode?>(null);
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'SoundNode'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "active_state":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            activeStateField.Set(__value);
                            break;
                        }
                    case "at_node":
                        {
                            Mech3DotNet.Json.Anim.Events.AtNode? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.AtNode?>(ref __reader, __options);
                            atNodeField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'SoundNode'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var activeState = activeStateField.Unwrap("active_state");
            var atNode = atNodeField.Unwrap("at_node");
            return new Mech3DotNet.Json.Anim.Events.SoundNode(name, activeState, atNode);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.SoundNode value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("active_state");
            JsonSerializer.Serialize(writer, value.activeState, options);
            if (value.atNode != null)
            {
                writer.WritePropertyName("at_node");
                JsonSerializer.Serialize(writer, value.atNode, options);
            }
            writer.WriteEndObject();
        }
    }
}
