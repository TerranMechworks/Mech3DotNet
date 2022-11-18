namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.EmptyConverter))]
    public class Empty
    {
        public string name;
        public NodeFlags flags;
        public uint unk044;
        public uint zoneId;
        public BoundingBox unk116;
        public BoundingBox unk140;
        public BoundingBox unk164;
        public uint parent;

        public Empty(string name, NodeFlags flags, uint unk044, uint zoneId, BoundingBox unk116, BoundingBox unk140, BoundingBox unk164, uint parent)
        {
            this.name = name;
            this.flags = flags;
            this.unk044 = unk044;
            this.zoneId = zoneId;
            this.unk116 = unk116;
            this.unk140 = unk140;
            this.unk164 = unk164;
            this.parent = parent;
        }
    }
}
