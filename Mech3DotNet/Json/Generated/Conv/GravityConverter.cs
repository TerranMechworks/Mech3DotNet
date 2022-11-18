using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class GravityConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.Gravity>
    {
        protected override Mech3DotNet.Json.Anim.Events.Gravity ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var modeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.GravityMode>();
            var valueField = new Mech3DotNet.Json.Converters.Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "mode":
                        {
                            Mech3DotNet.Json.Anim.Events.GravityMode __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.GravityMode>(ref __reader, __options);
                            modeField.Set(__value);
                            break;
                        }
                    case "value":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            valueField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Gravity'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var mode = modeField.Unwrap("mode");
            var value = valueField.Unwrap("value");
            return new Mech3DotNet.Json.Anim.Events.Gravity(mode, value);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.Gravity value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("mode");
            JsonSerializer.Serialize(writer, value.mode, options);
            writer.WritePropertyName("value");
            JsonSerializer.Serialize(writer, value.value, options);
            writer.WriteEndObject();
        }
    }
}
