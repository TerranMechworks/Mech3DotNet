using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(WorldConverter))]
    public class World
    {
        public string name;
        public Area area;
        public List<List<Partition>> partitions;
        public uint areaPartitionXCount;
        public uint areaPartitionYCount;
        public bool fudgeCount;
        public uint areaPartitionPtr;
        public uint virtPartitionPtr;
        public uint worldChildrenPtr;
        public uint worldChildValue;
        public uint worldLightsPtr;
        public List<uint> children;
        public uint dataPtr;
        public uint childrenArrayPtr;

        public World(string name, Area area, List<List<Partition>> partitions, uint areaPartitionXCount, uint areaPartitionYCount, bool fudgeCount, uint areaPartitionPtr, uint virtPartitionPtr, uint worldChildrenPtr, uint worldChildValue, uint worldLightsPtr, List<uint> children, uint dataPtr, uint childrenArrayPtr)
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
