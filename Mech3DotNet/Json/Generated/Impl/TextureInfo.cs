namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.TextureInfoConverter))]
    public class TextureInfo
    {
        public string name;
        public string? rename = null;
        public TextureAlpha alpha;
        public ushort width;
        public ushort height;
        public TextureStretch stretch;
        public bool imageLoaded;
        public bool alphaLoaded;
        public bool paletteLoaded;
        public TexturePalette palette;

        public TextureInfo(string name, string? rename, TextureAlpha alpha, ushort width, ushort height, TextureStretch stretch, bool imageLoaded, bool alphaLoaded, bool paletteLoaded, TexturePalette palette)
        {
            this.name = name;
            this.rename = rename;
            this.alpha = alpha;
            this.width = width;
            this.height = height;
            this.stretch = stretch;
            this.imageLoaded = imageLoaded;
            this.alphaLoaded = alphaLoaded;
            this.paletteLoaded = paletteLoaded;
            this.palette = palette;
        }
    }
}
