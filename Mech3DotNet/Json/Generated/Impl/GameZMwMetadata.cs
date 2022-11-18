using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(GameZMwMetadataConverter))]
    public class GameZMwMetadata
    {
        public short materialArraySize;
        public int meshesArraySize;
        public uint nodeArraySize;
        public uint nodeDataCount;

        public GameZMwMetadata(short materialArraySize, int meshesArraySize, uint nodeArraySize, uint nodeDataCount)
        {
            this.materialArraySize = materialArraySize;
            this.meshesArraySize = meshesArraySize;
            this.nodeArraySize = nodeArraySize;
            this.nodeDataCount = nodeDataCount;
        }
    }
}
