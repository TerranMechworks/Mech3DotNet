using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(Object3dPmConverter))]
    public class Object3dPm
    {
        public string name;
        public Transformation? transformation;
        public uint matrixSigns;
        public NodeFlags flags;
        public int meshIndex;
        public uint? parent;
        public List<uint> children;
        public uint dataPtr;
        public uint parentArrayPtr;
        public uint childrenArrayPtr;
        public uint unk044;
        public uint unk112;
        public BoundingBox unk116;
        public BoundingBox unk140;
        public BoundingBox unk164;

        public Object3dPm(string name, Transformation? transformation, uint matrixSigns, NodeFlags flags, int meshIndex, uint? parent, List<uint> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, uint unk044, uint unk112, BoundingBox unk116, BoundingBox unk140, BoundingBox unk164)
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
