namespace Mech3DotNet.Json.Gamez.Nodes
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Nodes.Converters.Object3dConverter))]
    public class Object3d
    {
        public string name;
        public Mech3DotNet.Json.Gamez.Nodes.Transformation? transformation;
        public uint matrixSigns;
        public Mech3DotNet.Json.Gamez.Nodes.NodeFlags flags;
        public uint zoneId;
        public Mech3DotNet.Json.Gamez.Nodes.AreaPartition? areaPartition;
        public int meshIndex;
        public uint? parent;
        public System.Collections.Generic.List<uint> children;
        public uint dataPtr;
        public uint parentArrayPtr;
        public uint childrenArrayPtr;
        public Mech3DotNet.Json.Gamez.Nodes.BoundingBox unk116;
        public Mech3DotNet.Json.Gamez.Nodes.BoundingBox unk140;
        public Mech3DotNet.Json.Gamez.Nodes.BoundingBox unk164;

        public Object3d(string name, Mech3DotNet.Json.Gamez.Nodes.Transformation? transformation, uint matrixSigns, Mech3DotNet.Json.Gamez.Nodes.NodeFlags flags, uint zoneId, Mech3DotNet.Json.Gamez.Nodes.AreaPartition? areaPartition, int meshIndex, uint? parent, System.Collections.Generic.List<uint> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, Mech3DotNet.Json.Gamez.Nodes.BoundingBox unk116, Mech3DotNet.Json.Gamez.Nodes.BoundingBox unk140, Mech3DotNet.Json.Gamez.Nodes.BoundingBox unk164)
        {
            this.name = name;
            this.transformation = transformation;
            this.matrixSigns = matrixSigns;
            this.flags = flags;
            this.zoneId = zoneId;
            this.areaPartition = areaPartition;
            this.meshIndex = meshIndex;
            this.parent = parent;
            this.children = children;
            this.dataPtr = dataPtr;
            this.parentArrayPtr = parentArrayPtr;
            this.childrenArrayPtr = childrenArrayPtr;
            this.unk116 = unk116;
            this.unk140 = unk140;
            this.unk164 = unk164;
        }
    }
}
