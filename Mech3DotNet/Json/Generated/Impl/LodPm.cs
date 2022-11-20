namespace Mech3DotNet.Json.Nodes.Pm
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Nodes.Pm.Converters.LodPmConverter))]
    public class LodPm
    {
        public string name;
        public bool level;
        public Mech3DotNet.Json.Types.Range range;
        public float unk64;
        public float unk72;
        public uint parent;
        public System.Collections.Generic.List<uint> children;
        public uint dataPtr;
        public uint parentArrayPtr;
        public uint childrenArrayPtr;
        public Mech3DotNet.Json.Nodes.BoundingBox unk164;

        public LodPm(string name, bool level, Mech3DotNet.Json.Types.Range range, float unk64, float unk72, uint parent, System.Collections.Generic.List<uint> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, Mech3DotNet.Json.Nodes.BoundingBox unk164)
        {
            this.name = name;
            this.level = level;
            this.range = range;
            this.unk64 = unk64;
            this.unk72 = unk72;
            this.parent = parent;
            this.children = children;
            this.dataPtr = dataPtr;
            this.parentArrayPtr = parentArrayPtr;
            this.childrenArrayPtr = childrenArrayPtr;
            this.unk164 = unk164;
        }
    }
}
