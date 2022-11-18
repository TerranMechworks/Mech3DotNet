using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(GameZPmMetadataConverter))]
    public class GameZPmMetadata
    {
        public uint gamezHeaderUnk08;
        public short materialArraySize;
        public int meshesArraySize;
        public uint nodeArraySize;
        public uint nodeDataCount;
        public List<uint?> texturePtrs;

        public GameZPmMetadata(uint gamezHeaderUnk08, short materialArraySize, int meshesArraySize, uint nodeArraySize, uint nodeDataCount, List<uint?> texturePtrs)
        {
            this.gamezHeaderUnk08 = gamezHeaderUnk08;
            this.materialArraySize = materialArraySize;
            this.meshesArraySize = meshesArraySize;
            this.nodeArraySize = nodeArraySize;
            this.nodeDataCount = nodeDataCount;
            this.texturePtrs = texturePtrs;
        }
    }
}
