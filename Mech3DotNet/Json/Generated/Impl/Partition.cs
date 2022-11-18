namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.PartitionConverter))]
    public class Partition
    {
        public int x;
        public int y;
        public float zMin;
        public float zMax;
        public float zMid;
        public System.Collections.Generic.List<uint> nodes;
        public uint ptr;

        public Partition(int x, int y, float zMin, float zMax, float zMid, System.Collections.Generic.List<uint> nodes, uint ptr)
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
