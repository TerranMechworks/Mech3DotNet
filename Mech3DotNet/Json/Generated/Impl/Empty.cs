namespace Mech3DotNet.Json.Nodes.Mw
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Nodes.Mw.Converters.EmptyConverter))]
    public class Empty
    {
        public string name;
        public Mech3DotNet.Json.Nodes.NodeFlags flags;
        public uint unk044;
        public uint zoneId;
        public Mech3DotNet.Json.Nodes.BoundingBox unk116;
        public Mech3DotNet.Json.Nodes.BoundingBox unk140;
        public Mech3DotNet.Json.Nodes.BoundingBox unk164;
        public uint parent;

        public Empty(string name, Mech3DotNet.Json.Nodes.NodeFlags flags, uint unk044, uint zoneId, Mech3DotNet.Json.Nodes.BoundingBox unk116, Mech3DotNet.Json.Nodes.BoundingBox unk140, Mech3DotNet.Json.Nodes.BoundingBox unk164, uint parent)
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
