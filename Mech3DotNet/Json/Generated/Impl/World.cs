namespace Mech3DotNet.Json.Nodes.Mw
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Nodes.Mw.Converters.WorldConverter))]
    public class World
    {
        public string name;
        public Mech3DotNet.Json.Nodes.Area area;
        public System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Json.Nodes.Partition>> partitions;
        public uint areaPartitionXCount;
        public uint areaPartitionYCount;
        public bool fudgeCount;
        public uint areaPartitionPtr;
        public uint virtPartitionPtr;
        public uint worldChildrenPtr;
        public uint worldChildValue;
        public uint worldLightsPtr;
        public System.Collections.Generic.List<uint> children;
        public uint dataPtr;
        public uint childrenArrayPtr;

        public World(string name, Mech3DotNet.Json.Nodes.Area area, System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Json.Nodes.Partition>> partitions, uint areaPartitionXCount, uint areaPartitionYCount, bool fudgeCount, uint areaPartitionPtr, uint virtPartitionPtr, uint worldChildrenPtr, uint worldChildValue, uint worldLightsPtr, System.Collections.Generic.List<uint> children, uint dataPtr, uint childrenArrayPtr)
        {
            this.name = name;
            this.area = area;
            this.partitions = partitions;
            this.areaPartitionXCount = areaPartitionXCount;
            this.areaPartitionYCount = areaPartitionYCount;
            this.fudgeCount = fudgeCount;
            this.areaPartitionPtr = areaPartitionPtr;
            this.virtPartitionPtr = virtPartitionPtr;
            this.worldChildrenPtr = worldChildrenPtr;
            this.worldChildValue = worldChildValue;
            this.worldLightsPtr = worldLightsPtr;
            this.children = children;
            this.dataPtr = dataPtr;
            this.childrenArrayPtr = childrenArrayPtr;
        }
    }
}
