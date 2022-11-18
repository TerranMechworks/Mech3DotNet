namespace Mech3DotNet.Json.Gamez.Nodes
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Nodes.Converters.Object3dPmConverter))]
    public class Object3dPm
    {
        public string name;
        public Mech3DotNet.Json.Gamez.Nodes.Transformation? transformation;
        public uint matrixSigns;
        public Mech3DotNet.Json.Gamez.Nodes.NodeFlags flags;
        public int meshIndex;
        public uint? parent;
        public System.Collections.Generic.List<uint> children;
        public uint dataPtr;
        public uint parentArrayPtr;
        public uint childrenArrayPtr;
        public uint unk044;
        public uint unk112;
        public Mech3DotNet.Json.Gamez.Nodes.BoundingBox unk116;
        public Mech3DotNet.Json.Gamez.Nodes.BoundingBox unk140;
        public Mech3DotNet.Json.Gamez.Nodes.BoundingBox unk164;

        public Object3dPm(string name, Mech3DotNet.Json.Gamez.Nodes.Transformation? transformation, uint matrixSigns, Mech3DotNet.Json.Gamez.Nodes.NodeFlags flags, int meshIndex, uint? parent, System.Collections.Generic.List<uint> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, uint unk044, uint unk112, Mech3DotNet.Json.Gamez.Nodes.BoundingBox unk116, Mech3DotNet.Json.Gamez.Nodes.BoundingBox unk140, Mech3DotNet.Json.Gamez.Nodes.BoundingBox unk164)
        {
            this.name = name;
            this.transformation = transformation;
            this.matrixSigns = matrixSigns;
            this.flags = flags;
            this.meshIndex = meshIndex;
            this.parent = parent;
            this.children = children;
            this.dataPtr = dataPtr;
            this.parentArrayPtr = parentArrayPtr;
            this.childrenArrayPtr = childrenArrayPtr;
            this.unk044 = unk044;
            this.unk112 = unk112;
            this.unk116 = unk116;
            this.unk140 = unk140;
            this.unk164 = unk164;
        }
    }
}
