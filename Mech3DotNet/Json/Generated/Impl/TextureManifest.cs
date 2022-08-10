using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TextureManifestConverter))]
    public class TextureManifest
    {
        public List<TextureInfo> textureInfos;
        public List<PaletteData> globalPalettes;

        public TextureManifest(List<TextureInfo> textureInfos, List<PaletteData> globalPalettes)
        {
            this.textureInfos = textureInfos;
            this.globalPalettes = globalPalettes;
        }
    }
}
