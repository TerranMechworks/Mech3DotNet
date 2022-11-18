using System.Text.Json;

namespace Mech3DotNet.Json.Gamez.Materials.Converters
{
    public class TexturedMaterialConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Gamez.Materials.TexturedMaterial>
    {
        protected override Mech3DotNet.Json.Gamez.Materials.TexturedMaterial ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var textureField = new Mech3DotNet.Json.Converters.Option<string>();
            var pointerField = new Mech3DotNet.Json.Converters.Option<uint>(0);
            var cycleField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Gamez.Materials.CycleData?>(null);
            var specularField = new Mech3DotNet.Json.Converters.Option<float>();
            var flagField = new Mech3DotNet.Json.Converters.Option<bool>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "texture":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'texture' was null for 'TexturedMaterial'");
                                throw new JsonException();
                            }
                            textureField.Set(__value);
                            break;
                        }
                    case "pointer":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            pointerField.Set(__value);
                            break;
                        }
                    case "cycle":
                        {
                            Mech3DotNet.Json.Gamez.Materials.CycleData? __value = ReadFieldValue<Mech3DotNet.Json.Gamez.Materials.CycleData?>(ref __reader, __options);
                            cycleField.Set(__value);
                            break;
                        }
                    case "specular":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            specularField.Set(__value);
                            break;
                        }
                    case "flag":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            flagField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'TexturedMaterial'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var texture = textureField.Unwrap("texture");
            var pointer = pointerField.Unwrap("pointer");
            var cycle = cycleField.Unwrap("cycle");
            var specular = specularField.Unwrap("specular");
            var flag = flagField.Unwrap("flag");
            return new Mech3DotNet.Json.Gamez.Materials.TexturedMaterial(texture, pointer, cycle, specular, flag);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Gamez.Materials.TexturedMaterial value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("texture");
            JsonSerializer.Serialize(writer, value.texture, options);
            if (value.pointer != 0)
            {
                writer.WritePropertyName("pointer");
                JsonSerializer.Serialize(writer, value.pointer, options);
            }
            if (value.cycle != null)
            {
                writer.WritePropertyName("cycle");
                JsonSerializer.Serialize(writer, value.cycle, options);
            }
            writer.WritePropertyName("specular");
            JsonSerializer.Serialize(writer, value.specular, options);
            writer.WritePropertyName("flag");
            JsonSerializer.Serialize(writer, value.flag, options);
            writer.WriteEndObject();
        }
    }
}
