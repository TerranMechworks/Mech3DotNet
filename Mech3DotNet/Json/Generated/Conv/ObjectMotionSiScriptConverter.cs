using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class ObjectMotionSiScriptConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.ObjectMotionSiScript>
    {
        protected override Mech3DotNet.Json.Anim.Events.ObjectMotionSiScript ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodeField = new Mech3DotNet.Json.Converters.Option<string>();
            var framesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Mech3DotNet.Json.Anim.Events.ObjectMotionSiFrame>>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'node' was null for 'ObjectMotionSiScript'");
                                throw new JsonException();
                            }
                            nodeField.Set(__value);
                            break;
                        }
                    case "frames":
                        {
                            System.Collections.Generic.List<Mech3DotNet.Json.Anim.Events.ObjectMotionSiFrame>? __value = ReadFieldValue<System.Collections.Generic.List<Mech3DotNet.Json.Anim.Events.ObjectMotionSiFrame>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'frames' was null for 'ObjectMotionSiScript'");
                                throw new JsonException();
                            }
                            framesField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectMotionSiScript'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var node = nodeField.Unwrap("node");
            var frames = framesField.Unwrap("frames");
            return new Mech3DotNet.Json.Anim.Events.ObjectMotionSiScript(node, frames);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.ObjectMotionSiScript value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("node");
            JsonSerializer.Serialize(writer, value.node, options);
            writer.WritePropertyName("frames");
            JsonSerializer.Serialize(writer, value.frames, options);
            writer.WriteEndObject();
        }
    }
}
