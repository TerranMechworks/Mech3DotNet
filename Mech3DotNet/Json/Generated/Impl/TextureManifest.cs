namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.TextureManifestConverter))]
    public class TextureManifest
    {
        public System.Collections.Generic.List<TextureInfo> textureInfos;
        public System.Collections.Generic.List<PaletteData> globalPalettes;

        public TextureManifest(System.Collections.Generic.List<TextureInfo> textureInfos, System.Collections.Generic.List<PaletteData> globalPalettes)
        {
            this.textureInfos = textureInfos;
            this.globalPalettes = globalPalettes;
        }
    }
}
