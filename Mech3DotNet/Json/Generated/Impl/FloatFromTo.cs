using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(FloatFromToConverter))]
    public class FloatFromTo
    {
        public float from;
        public float to;
        public float delta;

        public FloatFromTo(float from, float to, float delta)
        {
            this.from = from;
            this.to = to;
            this.delta = delta;
        }
    }
}
