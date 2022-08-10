using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class TextureManifestConverter : StructConverter<TextureManifest>
    {
        protected override TextureManifest ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var textureInfosField = new Option<List<TextureInfo>>();
            var globalPalettesField = new Option<List<PaletteData>>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "texture_infos":
                        {
                            List<TextureInfo>? __value = ReadFieldValue<List<TextureInfo>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'texture_infos' was null for 'TextureManifest'");
                                throw new JsonException();
                            }
                            textureInfosField.Set(__value);
                            break;
                        }
                    case "global_palettes":
                        {
                            List<PaletteData>? __value = ReadFieldValue<List<PaletteData>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'global_palettes' was null for 'TextureManifest'");
                                throw new JsonException();
                            }
                            globalPalettesField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'TextureManifest'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var textureInfos = textureInfosField.Unwrap("texture_infos");
            var globalPalettes = globalPalettesField.Unwrap("global_palettes");
            return new TextureManifest(textureInfos, globalPalettes);
        }

        public override void Write(Utf8JsonWriter writer, TextureManifest value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("texture_infos");
            JsonSerializer.Serialize(writer, value.textureInfos, options);
            writer.WritePropertyName("global_palettes");
            JsonSerializer.Serialize(writer, value.globalPalettes, options);
            writer.WriteEndObject();
        }
    }
}
