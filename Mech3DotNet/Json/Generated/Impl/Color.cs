namespace Mech3DotNet.Json.Types
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Types.Converters.ColorConverter))]
    public struct Color
    {
        public float r;
        public float g;
        public float b;

        public Color(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
}
