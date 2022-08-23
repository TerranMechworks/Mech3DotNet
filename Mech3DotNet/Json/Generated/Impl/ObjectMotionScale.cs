using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectMotionScaleConverter))]
    public class ObjectMotionScale
    {
        public Vec3 value;
        public Vec3 unk;

        public ObjectMotionScale(Vec3 value, Vec3 unk)
        {
            this.value = value;
            this.unk = unk;
        }
    }
}
