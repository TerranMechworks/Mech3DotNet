using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(MeshTextureConverter))]
    public class MeshTexture
    {
        public uint textureIndex;
        public uint polygonUsageCount;
        public uint unkPtr;

        public MeshTexture(uint textureIndex, uint polygonUsageCount, uint unkPtr)
        {
            this.textureIndex = textureIndex;
            this.polygonUsageCount = polygonUsageCount;
            this.unkPtr = unkPtr;
        }
    }
}
