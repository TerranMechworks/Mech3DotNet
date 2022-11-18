using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectActiveStateConverter : Mech3DotNet.Json.Converters.StructConverter<ObjectActiveState>
    {
        protected override ObjectActiveState ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Mech3DotNet.Json.Converters.Option<string>();
            var stateField = new Mech3DotNet.Json.Converters.Option<bool>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "node":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'ObjectActiveState'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "state":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            stateField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectActiveState'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var state = stateField.Unwrap("state");
            return new ObjectActiveState(node, state);
        }

        public override void Write(Utf8JsonWriter writer, ObjectActiveState value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("state");
            JsonSerializer.Serialize(writer, value.state, options);
            writer.WriteEndObject();
        }
    }
}
