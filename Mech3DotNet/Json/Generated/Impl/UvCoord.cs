namespace Mech3DotNet.Json.Gamez.Mesh
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Mesh.Converters.UvCoordConverter))]
    public struct UvCoord
    {
        public float u;
        public float v;

        public UvCoord(float u, float v)
        {
            this.u = u;
            this.v = v;
        }
    }
}
