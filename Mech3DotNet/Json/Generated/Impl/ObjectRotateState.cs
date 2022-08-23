using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectRotateStateConverter))]
    public class ObjectRotateState
    {
        public string node;
        public RotateState rotate;

        public ObjectRotateState(string node, RotateState rotate)
        {
            this.node = node;
            this.rotate = rotate;
        }
    }
}
