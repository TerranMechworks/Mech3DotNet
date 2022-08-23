using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectScaleStateConverter))]
    public class ObjectScaleState
    {
        public string node;
        public Vec3 scale;

        public ObjectScaleState(string node, Vec3 scale)
        {
            this.node = node;
            this.scale = scale;
        }
    }
}
