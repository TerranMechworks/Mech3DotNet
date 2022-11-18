using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class CallAnimationAtNodeConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.CallAnimationAtNode>
    {
        protected override Mech3DotNet.Json.Anim.Events.CallAnimationAtNode ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Mech3DotNet.Json.Converters.Option<string>();
            var translationField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3?>();
            var rotationField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3?>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'CallAnimationAtNode'");
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
                    case "rotation":
                        {
                            Mech3DotNet.Json.Types.Vec3? __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3?>(ref __reader, __options);
                            rotationField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'CallAnimationAtNode'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var translation = translationField.Unwrap("translation");
            var rotation = rotationField.Unwrap("rotation");
            return new Mech3DotNet.Json.Anim.Events.CallAnimationAtNode(node, translation, rotation);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.CallAnimationAtNode value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("translation");
            JsonSerializer.Serialize(writer, value.translation, options);
            writer.WritePropertyName("rotation");
            JsonSerializer.Serialize(writer, value.rotation, options);
            writer.WriteEndObject();
        }
    }
}
