using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class Partition
    {
        [JsonProperty("x", Required = Required.Always)]
        public int x;
        [JsonProperty("y", Required = Required.Always)]
        public int y;
        [JsonProperty("nodes", Required = Required.Always)]
        public List<uint> nodes;
        [JsonProperty("z_min", Required = Required.Always)]
        public float zMin;
        [JsonProperty("z_max", Required = Required.Always)]
        public float zMax;
        [JsonProperty("z_mid", Required = Required.Always)]
        public float zMid;
        [JsonProperty("ptr", Required = Required.Always)]
        public uint ptr;

        public Partition(int x, int y, List<uint> nodes, float zMin, float zMax, float zMid, uint ptr)
        {
            this.x = x;
            this.y = y;
            this.nodes = nodes;
            this.zMin = zMin;
            this.zMax = zMax;
            this.zMid = zMid;
            this.ptr = ptr;
        }

        [JsonConstructor]
        private Partition() { }
    }
}
