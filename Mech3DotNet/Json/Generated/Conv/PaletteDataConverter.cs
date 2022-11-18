using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class PaletteDataConverter : Mech3DotNet.Json.Converters.StructConverter<PaletteData>
    {
        protected override PaletteData ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var dataField = new Mech3DotNet.Json.Converters.Option<byte[]>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "data":
                        {
                            byte[] __value = ReadFieldValue<byte[]>(ref __reader, __options);
                            dataField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'PaletteData'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var data = dataField.Unwrap("data");
            return new PaletteData(data);
        }

        public override void Write(Utf8JsonWriter writer, PaletteData value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("data");
            JsonSerializer.Serialize(writer, value.data, options);
            writer.WriteEndObject();
        }
    }
}
