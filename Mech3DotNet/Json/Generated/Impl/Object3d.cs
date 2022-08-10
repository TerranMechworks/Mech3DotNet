using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(Object3dConverter))]
    public class Object3d
    {
        public string name;
        public Transformation? transformation;
        public uint matrixSigns;
        public NodeFlags flags;
        public uint zoneId;
        public AreaPartition? areaPartition;
        public int meshIndex;
        public uint? parent;
        public List<uint> children;
        public uint dataPtr;
        public uint parentArrayPtr;
        public uint childrenArrayPtr;
        public BoundingBox unk116;
        public BoundingBox unk140;
        public BoundingBox unk164;

        public Object3d(string name, Transformation? transformation, uint matrixSigns, NodeFlags flags, uint zoneId, AreaPartition? areaPartition, int meshIndex, uint? parent, List<uint> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, BoundingBox unk116, BoundingBox unk140, BoundingBox unk164)
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
