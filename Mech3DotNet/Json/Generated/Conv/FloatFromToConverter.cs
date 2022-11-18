using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class FloatFromToConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.FloatFromTo>
    {
        protected override Mech3DotNet.Json.Anim.Events.FloatFromTo ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var fromField = new Mech3DotNet.Json.Converters.Option<float>();
            var toField = new Mech3DotNet.Json.Converters.Option<float>();
            var deltaField = new Mech3DotNet.Json.Converters.Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "from":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            fromField.Set(__value);
                            break;
                        }
                    case "to":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            toField.Set(__value);
                            break;
                        }
                    case "delta":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            deltaField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'FloatFromTo'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var from = fromField.Unwrap("from");
            var to = toField.Unwrap("to");
            var delta = deltaField.Unwrap("delta");
            return new Mech3DotNet.Json.Anim.Events.FloatFromTo(from, to, delta);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.FloatFromTo value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("from");
            JsonSerializer.Serialize(writer, value.from, options);
            writer.WritePropertyName("to");
            JsonSerializer.Serialize(writer, value.to, options);
            writer.WritePropertyName("delta");
            JsonSerializer.Serialize(writer, value.delta, options);
            writer.WriteEndObject();
        }
    }
}
