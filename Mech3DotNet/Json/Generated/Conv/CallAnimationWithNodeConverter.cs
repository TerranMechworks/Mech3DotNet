using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class CallAnimationWithNodeConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.CallAnimationWithNode>
    {
        protected override Mech3DotNet.Json.Anim.Events.CallAnimationWithNode ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Mech3DotNet.Json.Converters.Option<string>();
            var translationField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3?>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'CallAnimationWithNode'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "translation":
                        {
                            Mech3DotNet.Json.Types.Vec3? __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3?>(ref __reader, __options);
                            translationField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'CallAnimationWithNode'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var translation = translationField.Unwrap("translation");
            return new Mech3DotNet.Json.Anim.Events.CallAnimationWithNode(node, translation);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.CallAnimationWithNode value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("translation");
            JsonSerializer.Serialize(writer, value.translation, options);
            writer.WriteEndObject();
        }
    }
}
