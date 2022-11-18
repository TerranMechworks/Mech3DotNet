namespace Mech3DotNet.Json.Image
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Image.Converters.TextureManifestConverter))]
    public class TextureManifest
    {
        public System.Collections.Generic.List<Mech3DotNet.Json.Image.TextureInfo> textureInfos;
        public System.Collections.Generic.List<Mech3DotNet.Json.Image.PaletteData> globalPalettes;

        public TextureManifest(System.Collections.Generic.List<Mech3DotNet.Json.Image.TextureInfo> textureInfos, System.Collections.Generic.List<Mech3DotNet.Json.Image.PaletteData> globalPalettes)
        {
            this.textureInfos = textureInfos;
            this.globalPalettes = globalPalettes;
        }
    }
}
