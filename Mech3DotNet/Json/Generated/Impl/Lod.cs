using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(LodConverter))]
    public class Lod
    {
        public string name;
        public bool level;
        public Range range;
        public float unk60;
        public uint? unk76;
        public NodeFlags flags;
        public uint zoneId;
        public AreaPartition? areaPartition;
        public uint parent;
        public List<uint> children;
        public uint dataPtr;
        public uint parentArrayPtr;
        public uint childrenArrayPtr;
        public BoundingBox unk116;

        public Lod(string name, bool level, Range range, float unk60, uint? unk76, NodeFlags flags, uint zoneId, AreaPartition? areaPartition, uint parent, List<uint> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, BoundingBox unk116)
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
