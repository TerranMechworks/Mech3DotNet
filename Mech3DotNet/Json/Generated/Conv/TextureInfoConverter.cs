using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class TextureInfoConverter : StructConverter<TextureInfo>
    {
        protected override TextureInfo ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var alphaField = new Option<TextureAlpha>();
            var widthField = new Option<ushort>();
            var heightField = new Option<ushort>();
            var stretchField = new Option<TextureStretch>();
            var imageLoadedField = new Option<bool>();
            var alphaLoadedField = new Option<bool>();
            var paletteLoadedField = new Option<bool>();
            var paletteField = new Option<TexturePalette>();
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
                    case "alpha":
                        {
                            TextureAlpha __value = ReadFieldValue<TextureAlpha>(ref __reader, __options);
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
                            TextureStretch __value = ReadFieldValue<TextureStretch>(ref __reader, __options);
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
                            TexturePalette? __value = ReadFieldValue<TexturePalette?>(ref __reader, __options);
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
            var alpha = alphaField.Unwrap("alpha");
            var width = widthField.Unwrap("width");
            var height = heightField.Unwrap("height");
            var stretch = stretchField.Unwrap("stretch");
            var imageLoaded = imageLoadedField.Unwrap("image_loaded");
            var alphaLoaded = alphaLoadedField.Unwrap("alpha_loaded");
            var paletteLoaded = paletteLoadedField.Unwrap("palette_loaded");
            var palette = paletteField.Unwrap("palette");
            return new TextureInfo(name, alpha, width, height, stretch, imageLoaded, alphaLoaded, paletteLoaded, palette);
        }

        public override void Write(Utf8JsonWriter writer, TextureInfo value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
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
