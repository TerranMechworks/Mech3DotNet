using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ForwardRotationTimeConverter))]
    public struct ForwardRotationTime
    {
        public float v1;
        public float v2;

        public ForwardRotationTime(float v1, float v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}
