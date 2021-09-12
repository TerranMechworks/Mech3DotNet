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
        [JsonProperty("unk", Required = Required.Always)]
        public Vec3 unk;
        [JsonProperty("ptr", Required = Required.Always)]
        public uint ptr;

        public Partition(int x, int y, List<uint> nodes, Vec3 unk, uint ptr)
        {
            this.x = x;
            this.y = y;
            this.nodes = nodes ?? throw new ArgumentNullException(nameof(nodes));
            this.unk = unk;
            this.ptr = ptr;
        }

        [JsonConstructor]
        private Partition() { }
    }
}
