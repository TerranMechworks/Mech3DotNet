using System;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class TextureInfo
    {
        [JsonProperty("name", Required = Required.Always)]
        public string name;
        [JsonProperty("alpha", Required = Required.Always)]
        public TextureAlpha alpha;
        [JsonProperty("width", Required = Required.Always)]
        public ushort width;
        [JsonProperty("height", Required = Required.Always)]
        public ushort height;
        [JsonProperty("stretch", Required = Required.Always)]
        public TextureStretch stretch;
        [JsonProperty("image_loaded", Required = Required.Always)]
        public bool imageLoaded;
        [JsonProperty("alpha_loaded", Required = Required.Always)]
        public bool alphaLoaded;
        [JsonProperty("palette_loaded", Required = Required.Always)]
        public bool paletteLoaded;
        [JsonProperty("palette", Required = Required.Always)]
        public TexturePalette palette;

        public TextureInfo(string name, TextureAlpha alpha, ushort width, ushort height, TextureStretch stretch, bool imageLoaded, bool alphaLoaded, bool paletteLoaded, TexturePalette palette)
        {
            this.name = name;
            this.alpha = alpha;
            this.width = width;
            this.height = height;
            this.stretch = stretch;
            this.imageLoaded = imageLoaded;
            this.alphaLoaded = alphaLoaded;
            this.paletteLoaded = paletteLoaded;
            this.palette = palette;
        }

        [JsonConstructor]
        private TextureInfo() { }
    }
}
