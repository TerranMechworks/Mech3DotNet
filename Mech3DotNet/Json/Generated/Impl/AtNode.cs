using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(AtNodeConverter))]
    public class AtNode
    {
        public string node;
        public Vec3 translation;

        public AtNode(string node, Vec3 translation)
        {
            this.node = node;
            this.translation = translation;
        }
    }
}
