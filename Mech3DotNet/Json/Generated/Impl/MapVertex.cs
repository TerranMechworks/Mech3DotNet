namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.MapVertexConverter))]
    public struct MapVertex
    {
        public float x;
        public float z;
        public float y;

        public MapVertex(float x, float z, float y)
        {
            this.x = x;
            this.z = z;
            this.y = y;
        }
    }
}
