using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(GravityConverter))]
    public struct Gravity
    {
        public GravityMode mode;
        public float value;

        public Gravity(GravityMode mode, float value)
        {
            this.mode = mode;
            this.value = value;
        }
    }
}
