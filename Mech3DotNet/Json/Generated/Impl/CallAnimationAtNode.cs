using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(CallAnimationAtNodeConverter))]
    public class CallAnimationAtNode
    {
        public string node;
        public Vec3? translation;
        public Vec3? rotation;

        public CallAnimationAtNode(string node, Vec3? translation, Vec3? rotation)
        {
            this.node = node;
            this.translation = translation;
            this.rotation = rotation;
        }
    }
}
