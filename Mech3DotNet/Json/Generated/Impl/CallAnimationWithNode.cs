using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(CallAnimationWithNodeConverter))]
    public class CallAnimationWithNode
    {
        public string node;
        public Vec3? translation;

        public CallAnimationWithNode(string node, Vec3? translation)
        {
            this.node = node;
            this.translation = translation;
        }
    }
}
