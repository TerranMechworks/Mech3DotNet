using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class AnimationLodCondConverter : Mech3DotNet.Json.Converters.StructConverter<AnimationLodCond>
    {
        protected override AnimationLodCond ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var valueField = new Mech3DotNet.Json.Converters.Option<uint>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "value":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            valueField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'AnimationLodCond'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var value = valueField.Unwrap("value");
            return new AnimationLodCond(value);
        }

        public override void Write(Utf8JsonWriter writer, AnimationLodCond value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value");
            JsonSerializer.Serialize(writer, value.value, options);
            writer.WriteEndObject();
        }
    }
}
