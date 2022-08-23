using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(FrameBufferEffectColorConverter))]
    public class FrameBufferEffectColor
    {
        public Rgba from;
        public Rgba to;
        public float runtime;
        public bool fudgeAlpha = false;

        public FrameBufferEffectColor(Rgba from, Rgba to, float runtime, bool fudgeAlpha)
        {
            this.from = from;
            this.to = to;
            this.runtime = runtime;
            this.fudgeAlpha = fudgeAlpha;
        }
    }
}
