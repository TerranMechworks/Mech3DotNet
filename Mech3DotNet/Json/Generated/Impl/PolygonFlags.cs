namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.PolygonFlagsConverter))]
    public class PolygonFlags
    {
        public bool unk2 = false;
        public bool unk3 = false;
        public bool triangleStrip = false;
        public bool unk6 = false;

        public PolygonFlags(bool unk2, bool unk3, bool triangleStrip, bool unk6)
        {
            this.unk2 = unk2;
            this.unk3 = unk3;
            this.triangleStrip = triangleStrip;
            this.unk6 = unk6;
        }
    }
}
