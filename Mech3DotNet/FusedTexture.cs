namespace Mech3DotNet.Types.Image
{
    /// <summary>Texture information and data.</summary>
    public sealed class FusedTexture
    {
        public TextureInfo info;
        public byte[] data;

        public FusedTexture(TextureInfo info, byte[] data)
        {
            this.info = info;
            this.data = data;
        }
    }
}
