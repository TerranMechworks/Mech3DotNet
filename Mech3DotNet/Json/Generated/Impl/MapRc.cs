namespace Mech3DotNet.Json.Zmap
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Zmap.Converters.MapRcConverter))]
    public class MapRc
    {
        public uint unk04;
        public float maxX;
        public float maxY;
        public System.Collections.Generic.List<Mech3DotNet.Json.Zmap.MapFeature> features;

        public MapRc(uint unk04, float maxX, float maxY, System.Collections.Generic.List<Mech3DotNet.Json.Zmap.MapFeature> features)
        {
            this.unk04 = unk04;
            this.maxX = maxX;
            this.maxY = maxY;
            this.features = features;
        }
    }
}
