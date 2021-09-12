using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class TextureManifest
    {
        [JsonProperty("texture_infos", Required = Required.Always)]
        public List<TextureInfo> textureInfos;
        [JsonProperty("global_palettes", Required = Required.Always)]
        public List<byte[]> globalPalettes;

        public TextureManifest(List<TextureInfo> textureInfos, List<byte[]> globalPalettes)
        {
            this.textureInfos = textureInfos ?? throw new ArgumentNullException(nameof(textureInfos));
            this.globalPalettes = globalPalettes ?? throw new ArgumentNullException(nameof(globalPalettes));
        }

        [JsonConstructor]
        private TextureManifest() { }
    }
}
