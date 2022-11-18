using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class ObjectCycleTextureConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.ObjectCycleTexture>
    {
        protected override Mech3DotNet.Json.Anim.Events.ObjectCycleTexture ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Mech3DotNet.Json.Converters.Option<string>();
            var resetField = new Mech3DotNet.Json.Converters.Option<ushort>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'ObjectCycleTexture'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "reset":
                        {
                            ushort __value = ReadFieldValue<ushort>(ref __reader, __options);
                            resetField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectCycleTexture'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var reset = resetField.Unwrap("reset");
            return new Mech3DotNet.Json.Anim.Events.ObjectCycleTexture(node, reset);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.ObjectCycleTexture value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("reset");
            JsonSerializer.Serialize(writer, value.reset, options);
            writer.WriteEndObject();
        }
    }
}
