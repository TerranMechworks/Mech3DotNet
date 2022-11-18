using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(PolygonTextureNgConverter))]
    public class PolygonTextureNg
    {
        public uint textureIndex;
        public List<UvCoord> uvCoords;

        public PolygonTextureNg(uint textureIndex, List<UvCoord> uvCoords)
        {
            this.textureIndex = textureIndex;
            this.uvCoords = uvCoords;
        }
    }
}
