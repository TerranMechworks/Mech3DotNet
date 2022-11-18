namespace Mech3DotNet.Json.Image
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Image.Converters.TextureInfoConverter))]
    public class TextureInfo
    {
        public string name;
        public string? rename = null;
        public Mech3DotNet.Json.Image.TextureAlpha alpha;
        public ushort width;
        public ushort height;
        public Mech3DotNet.Json.Image.TextureStretch stretch;
        public bool imageLoaded;
        public bool alphaLoaded;
        public bool paletteLoaded;
        public Mech3DotNet.Json.Image.TexturePalette palette;

        public TextureInfo(string name, string? rename, Mech3DotNet.Json.Image.TextureAlpha alpha, ushort width, ushort height, Mech3DotNet.Json.Image.TextureStretch stretch, bool imageLoaded, bool alphaLoaded, bool paletteLoaded, Mech3DotNet.Json.Image.TexturePalette palette)
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
