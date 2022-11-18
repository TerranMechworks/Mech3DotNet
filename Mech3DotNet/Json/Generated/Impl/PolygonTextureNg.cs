namespace Mech3DotNet.Json.Gamez.Mesh.Ng
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Mesh.Ng.Converters.PolygonTextureNgConverter))]
    public class PolygonTextureNg
    {
        public uint textureIndex;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.UvCoord> uvCoords;

        public PolygonTextureNg(uint textureIndex, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.UvCoord> uvCoords)
        {
            this.textureIndex = textureIndex;
            this.uvCoords = uvCoords;
        }
    }
}
