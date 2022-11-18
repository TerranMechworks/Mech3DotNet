using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class LightAnimationConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.LightAnimation>
    {
        protected override Mech3DotNet.Json.Anim.Events.LightAnimation ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var rangeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Range>();
            var colorField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Color>();
            var runtimeField = new Mech3DotNet.Json.Converters.Option<float>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'LightAnimation'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "range":
                        {
                            Mech3DotNet.Json.Types.Range __value = ReadFieldValue<Mech3DotNet.Json.Types.Range>(ref __reader, __options);
                            rangeField.Set(__value);
                            break;
                        }
                    case "color":
                        {
                            Mech3DotNet.Json.Types.Color __value = ReadFieldValue<Mech3DotNet.Json.Types.Color>(ref __reader, __options);
                            colorField.Set(__value);
                            break;
                        }
                    case "runtime":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            runtimeField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'LightAnimation'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var range = rangeField.Unwrap("range");
            var color = colorField.Unwrap("color");
            var runtime = runtimeField.Unwrap("runtime");
            return new Mech3DotNet.Json.Anim.Events.LightAnimation(name, range, color, runtime);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.LightAnimation value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("range");
            JsonSerializer.Serialize(writer, value.range, options);
            writer.WritePropertyName("color");
            JsonSerializer.Serialize(writer, value.color, options);
            writer.WritePropertyName("runtime");
            JsonSerializer.Serialize(writer, value.runtime, options);
            writer.WriteEndObject();
        }
    }
}
