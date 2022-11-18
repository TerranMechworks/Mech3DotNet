namespace Mech3DotNet.Json.Gamez.Mesh.Ng
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Mesh.Ng.Converters.MeshTextureConverter))]
    public class MeshTexture
    {
        public uint textureIndex;
        public uint polygonUsageCount;
        public uint unkPtr;

        public MeshTexture(uint textureIndex, uint polygonUsageCount, uint unkPtr)
        {
            this.textureIndex = textureIndex;
            this.polygonUsageCount = polygonUsageCount;
            this.unkPtr = unkPtr;
        }
    }
}
