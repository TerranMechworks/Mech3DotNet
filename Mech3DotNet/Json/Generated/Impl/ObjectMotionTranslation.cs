using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectMotionTranslationConverter))]
    public class ObjectMotionTranslation
    {
        public Vec3 delta;
        public Vec3 initial;
        public Vec3 unk;

        public ObjectMotionTranslation(Vec3 delta, Vec3 initial, Vec3 unk)
        {
            this.delta = delta;
            this.initial = initial;
            this.unk = unk;
        }
    }
}
