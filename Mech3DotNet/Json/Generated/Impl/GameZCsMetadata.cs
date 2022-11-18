using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(GameZCsMetadataConverter))]
    public class GameZCsMetadata
    {
        public uint gamezHeaderUnk08;
        public short materialArraySize;
        public uint nodeArraySize;
        public uint nodeDataCount;
        public List<uint?> texturePtrs;

        public GameZCsMetadata(uint gamezHeaderUnk08, short materialArraySize, uint nodeArraySize, uint nodeDataCount, List<uint?> texturePtrs)
        {
            this.gamezHeaderUnk08 = gamezHeaderUnk08;
            this.materialArraySize = materialArraySize;
            this.nodeArraySize = nodeArraySize;
            this.nodeDataCount = nodeDataCount;
            this.texturePtrs = texturePtrs;
        }
    }
}
