using System.Text.Json;

namespace Mech3DotNet.Json.Gamez.Materials.Converters
{
    public class ColoredMaterialConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Gamez.Materials.ColoredMaterial>
    {
        protected override Mech3DotNet.Json.Gamez.Materials.ColoredMaterial ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var colorField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Color>();
            var alphaField = new Mech3DotNet.Json.Converters.Option<byte>();
            var specularField = new Mech3DotNet.Json.Converters.Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "color":
                        {
                            Mech3DotNet.Json.Types.Color __value = ReadFieldValue<Mech3DotNet.Json.Types.Color>(ref __reader, __options);
                            colorField.Set(__value);
                            break;
                        }
                    case "alpha":
                        {
                            byte __value = ReadFieldValue<byte>(ref __reader, __options);
                            alphaField.Set(__value);
                            break;
                        }
                    case "specular":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            specularField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ColoredMaterial'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var color = colorField.Unwrap("color");
            var alpha = alphaField.Unwrap("alpha");
            var specular = specularField.Unwrap("specular");
            return new Mech3DotNet.Json.Gamez.Materials.ColoredMaterial(color, alpha, specular);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Gamez.Materials.ColoredMaterial value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("color");
            JsonSerializer.Serialize(writer, value.color, options);
            writer.WritePropertyName("alpha");
            JsonSerializer.Serialize(writer, value.alpha, options);
            writer.WritePropertyName("specular");
            JsonSerializer.Serialize(writer, value.specular, options);
            writer.WriteEndObject();
        }
    }
}
