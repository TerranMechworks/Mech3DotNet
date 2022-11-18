using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(MapVertexConverter))]
    public struct MapVertex
    {
        public float x;
        public float z;
        public float y;

        public MapVertex(float x, float z, float y)
        {
            this.x = x;
            this.z = z;
            this.y = y;
        }
    }
}
