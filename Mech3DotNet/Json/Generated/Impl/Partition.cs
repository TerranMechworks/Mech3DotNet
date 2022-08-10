using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(PartitionConverter))]
    public class Partition
    {
        public int x;
        public int y;
        public float zMin;
        public float zMax;
        public float zMid;
        public List<uint> nodes;
        public uint ptr;

        public Partition(int x, int y, float zMin, float zMax, float zMid, List<uint> nodes, uint ptr)
        {
            this.x = x;
            this.y = y;
            this.zMin = zMin;
            this.zMax = zMax;
            this.zMid = zMid;
            this.nodes = nodes;
            this.ptr = ptr;
        }
    }
}
