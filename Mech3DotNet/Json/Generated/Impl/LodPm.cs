using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(LodPmConverter))]
    public class LodPm
    {
        public string name;
        public bool level;
        public Range range;
        public float unk64;
        public float unk72;
        public uint parent;
        public List<uint> children;
        public uint dataPtr;
        public uint parentArrayPtr;
        public uint childrenArrayPtr;
        public BoundingBox unk164;

        public LodPm(string name, bool level, Range range, float unk64, float unk72, uint parent, List<uint> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, BoundingBox unk164)
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
