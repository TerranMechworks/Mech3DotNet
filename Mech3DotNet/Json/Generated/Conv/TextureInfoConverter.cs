using System.Text.Json;

namespace Mech3DotNet.Json.Image.Converters
{
    public class TextureInfoConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Image.TextureInfo>
    {
        protected override Mech3DotNet.Json.Image.TextureInfo ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var renameField = new Mech3DotNet.Json.Converters.Option<string?>(null);
            var alphaField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Image.TextureAlpha>();
            var widthField = new Mech3DotNet.Json.Converters.Option<ushort>();
            var heightField = new Mech3DotNet.Json.Converters.Option<ushort>();
            var stretchField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Image.TextureStretch>();
            var imageLoadedField = new Mech3DotNet.Json.Converters.Option<bool>();
            var alphaLoadedField = new Mech3DotNet.Json.Converters.Option<bool>();
            var paletteLoadedField = new Mech3DotNet.Json.Converters.Option<bool>();
            var paletteField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Image.TexturePalette>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'TextureInfo'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "rename":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            renameField.Set(__value);
                            break;
                        }
                    case "alpha":
                        {
                            Mech3DotNet.Json.Image.TextureAlpha __value = ReadFieldValue<Mech3DotNet.Json.Image.TextureAlpha>(ref __reader, __options);
                            alphaField.Set(__value);
                            break;
                        }
                    case "width":
                        {
                            ushort __value = ReadFieldValue<ushort>(ref __reader, __options);
                            widthField.Set(__value);
                            break;
                        }
                    case "height":
                        {
                            ushort __value = ReadFieldValue<ushort>(ref __reader, __options);
                            heightField.Set(__value);
                            break;
                        }
                    case "stretch":
                        {
                            Mech3DotNet.Json.Image.TextureStretch __value = ReadFieldValue<Mech3DotNet.Json.Image.TextureStretch>(ref __reader, __options);
                            stretchField.Set(__value);
                            break;
                        }
                    case "image_loaded":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            imageLoadedField.Set(__value);
                            break;
                        }
                    case "alpha_loaded":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            alphaLoadedField.Set(__value);
                            break;
                        }
                    case "palette_loaded":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            paletteLoadedField.Set(__value);
                            break;
                        }
                    case "palette":
                        {
                            Mech3DotNet.Json.Image.TexturePalette? __value = ReadFieldValue<Mech3DotNet.Json.Image.TexturePalette?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'palette' was null for 'TextureInfo'");
                                throw new JsonException();
                            }
                            paletteField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'TextureInfo'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var rename = renameField.Unwrap("rename");
            var alpha = alphaField.Unwrap("alpha");
            var width = widthField.Unwrap("width");
            var height = heightField.Unwrap("height");
            var stretch = stretchField.Unwrap("stretch");
            var imageLoaded = imageLoadedField.Unwrap("image_loaded");
            var alphaLoaded = alphaLoadedField.Unwrap("alpha_loaded");
            var paletteLoaded = paletteLoadedField.Unwrap("palette_loaded");
            var palette = paletteField.Unwrap("palette");
            return new Mech3DotNet.Json.Image.TextureInfo(name, rename, alpha, width, height, stretch, imageLoaded, alphaLoaded, paletteLoaded, palette);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Image.TextureInfo value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            if (value.rename != null)
            {
                writer.WritePropertyName("rename");
                JsonSerializer.Serialize(writer, value.rename, options);
            }
            writer.WritePropertyName("alpha");
            JsonSerializer.Serialize(writer, value.alpha, options);
            writer.WritePropertyName("width");
            JsonSerializer.Serialize(writer, value.width, options);
            writer.WritePropertyName("height");
            JsonSerializer.Serialize(writer, value.height, options);
            writer.WritePropertyName("stretch");
            JsonSerializer.Serialize(writer, value.stretch, options);
            writer.WritePropertyName("image_loaded");
            JsonSerializer.Serialize(writer, value.imageLoaded, options);
            writer.WritePropertyName("alpha_loaded");
            JsonSerializer.Serialize(writer, value.alphaLoaded, options);
            writer.WritePropertyName("palette_loaded");
            JsonSerializer.Serialize(writer, value.paletteLoaded, options);
            writer.WritePropertyName("palette");
            JsonSerializer.Serialize(writer, value.palette, options);
            writer.WriteEndObject();
        }
    }
}
