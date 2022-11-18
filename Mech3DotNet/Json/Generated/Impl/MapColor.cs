namespace Mech3DotNet.Json.Zmap
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Zmap.Converters.MapColorConverter))]
    public struct MapColor
    {
        public byte r;
        public byte g;
        public byte b;

        public MapColor(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
}
