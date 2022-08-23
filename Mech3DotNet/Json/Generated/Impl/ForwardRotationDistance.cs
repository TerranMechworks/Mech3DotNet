using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ForwardRotationDistanceConverter))]
    public struct ForwardRotationDistance
    {
        public float v1;

        public ForwardRotationDistance(float v1)
        {
            this.v1 = v1;
        }
    }
}
