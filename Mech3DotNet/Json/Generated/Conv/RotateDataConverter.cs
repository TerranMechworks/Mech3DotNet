using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class RotateDataConverter : Mech3DotNet.Json.Converters.StructConverter<RotateData>
    {
        protected override RotateData ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var valueField = new Mech3DotNet.Json.Converters.Option<Quaternion>();
            var unkField = new Mech3DotNet.Json.Converters.Option<byte[]>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "value":
                        {
                            Quaternion __value = ReadFieldValue<Quaternion>(ref __reader, __options);
                            valueField.Set(__value);
                            break;
                        }
                    case "unk":
                        {
                            byte[] __value = ReadFieldValue<byte[]>(ref __reader, __options);
                            unkField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'RotateData'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var value = valueField.Unwrap("value");
            var unk = unkField.Unwrap("unk");
            return new RotateData(value, unk);
        }

        public override void Write(Utf8JsonWriter writer, RotateData value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value");
            JsonSerializer.Serialize(writer, value.value, options);
            writer.WritePropertyName("unk");
            JsonSerializer.Serialize(writer, value.unk, options);
            writer.WriteEndObject();
        }
    }
}
