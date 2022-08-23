using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(LightAnimationConverter))]
    public class LightAnimation
    {
        public string name;
        public Range range;
        public Color color;
        public float runtime;

        public LightAnimation(string name, Range range, Color color, float runtime)
        {
            this.name = name;
            this.range = range;
            this.color = color;
            this.runtime = runtime;
        }
    }
}
