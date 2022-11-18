namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.RgbaConverter))]
    public struct Rgba
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public Rgba(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
}
