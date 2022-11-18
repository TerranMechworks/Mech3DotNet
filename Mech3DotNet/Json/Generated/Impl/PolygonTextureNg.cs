namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.PolygonTextureNgConverter))]
    public class PolygonTextureNg
    {
        public uint textureIndex;
        public System.Collections.Generic.List<UvCoord> uvCoords;

        public PolygonTextureNg(uint textureIndex, System.Collections.Generic.List<UvCoord> uvCoords)
        {
            this.textureIndex = textureIndex;
            this.uvCoords = uvCoords;
        }
    }
}
