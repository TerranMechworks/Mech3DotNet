using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class Motion<V3, V4>
    {
        [JsonProperty("loop_time", Required = Required.Always)]
        public float loopTime;
        [JsonProperty("parts", Required = Required.Always)]
        public List<MotionPart<V3, V4>> parts;
        [JsonProperty("frame_count", Required = Required.Always)]
        public int frameCount;

        public Motion(float loopTime, List<MotionPart<V3, V4>> parts, int frameCount)
        {
            this.loopTime = loopTime;
            this.parts = parts ?? throw new ArgumentNullException(nameof(parts));
            this.frameCount = frameCount;
        }

        [JsonConstructor]
        private Motion() { }

        public static MotionPartConverter<V3, V4> GetConverter() => new MotionPartConverter<V3, V4>();
    }
}
