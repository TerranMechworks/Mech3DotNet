using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class ObjectScaleStateConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.ObjectScaleState>
    {
        protected override Mech3DotNet.Json.Anim.Events.ObjectScaleState ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Mech3DotNet.Json.Converters.Option<string>();
            var scaleField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'ObjectScaleState'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "scale":
                        {
                            Mech3DotNet.Json.Types.Vec3 __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3>(ref __reader, __options);
                            scaleField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectScaleState'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var scale = scaleField.Unwrap("scale");
            return new Mech3DotNet.Json.Anim.Events.ObjectScaleState(node, scale);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.ObjectScaleState value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("scale");
            JsonSerializer.Serialize(writer, value.scale, options);
            writer.WriteEndObject();
        }
    }
}
