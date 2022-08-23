using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectMotionFromToConverter))]
    public class ObjectMotionFromTo
    {
        public string node;
        public float runTime;
        public FloatFromTo? morph = null;
        public Vec3FromTo? translate = null;
        public Vec3FromTo? rotate = null;
        public Vec3FromTo? scale = null;

        public ObjectMotionFromTo(string node, float runTime, FloatFromTo? morph, Vec3FromTo? translate, Vec3FromTo? rotate, Vec3FromTo? scale)
        {
            this.node = node;
            this.runTime = runTime;
            this.morph = morph;
            this.translate = translate;
            this.rotate = rotate;
            this.scale = scale;
        }
    }
}
