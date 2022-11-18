using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ForwardRotationTimeConverter : Mech3DotNet.Json.Converters.StructConverter<ForwardRotationTime>
    {
        protected override ForwardRotationTime ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var v1Field = new Mech3DotNet.Json.Converters.Option<float>();
            var v2Field = new Mech3DotNet.Json.Converters.Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "v1":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            v1Field.Set(__value);
                            break;
                        }
                    case "v2":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            v2Field.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ForwardRotationTime'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var v1 = v1Field.Unwrap("v1");
            var v2 = v2Field.Unwrap("v2");
            return new ForwardRotationTime(v1, v2);
        }

        public override void Write(Utf8JsonWriter writer, ForwardRotationTime value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("v1");
            JsonSerializer.Serialize(writer, value.v1, options);
            writer.WritePropertyName("v2");
            JsonSerializer.Serialize(writer, value.v2, options);
            writer.WriteEndObject();
        }
    }
}
