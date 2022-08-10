using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(UvCoordConverter))]
    public struct UvCoord
    {
        public float u;
        public float v;

        public UvCoord(float u, float v)
        {
            this.u = u;
            this.v = v;
        }
    }
}
