namespace Mech3DotNet.Json.Nodes.Mw
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Nodes.Mw.Converters.LodConverter))]
    public class Lod
    {
        public string name;
        public bool level;
        public Mech3DotNet.Json.Types.Range range;
        public float unk60;
        public uint? unk76;
        public Mech3DotNet.Json.Nodes.NodeFlags flags;
        public uint zoneId;
        public Mech3DotNet.Json.Nodes.AreaPartition? areaPartition;
        public uint parent;
        public System.Collections.Generic.List<uint> children;
        public uint dataPtr;
        public uint parentArrayPtr;
        public uint childrenArrayPtr;
        public Mech3DotNet.Json.Nodes.BoundingBox unk116;

        public Lod(string name, bool level, Mech3DotNet.Json.Types.Range range, float unk60, uint? unk76, Mech3DotNet.Json.Nodes.NodeFlags flags, uint zoneId, Mech3DotNet.Json.Nodes.AreaPartition? areaPartition, uint parent, System.Collections.Generic.List<uint> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, Mech3DotNet.Json.Nodes.BoundingBox unk116)
        {
            this.name = name;
            this.level = level;
            this.range = range;
            this.unk60 = unk60;
            this.unk76 = unk76;
            this.flags = flags;
            this.zoneId = zoneId;
            this.areaPartition = areaPartition;
            this.parent = parent;
            this.children = children;
            this.dataPtr = dataPtr;
            this.parentArrayPtr = parentArrayPtr;
            this.childrenArrayPtr = childrenArrayPtr;
            this.unk116 = unk116;
        }
    }
}
