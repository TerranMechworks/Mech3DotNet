using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectOpacityStateConverter))]
    public class ObjectOpacityState
    {
        public string node;
        public bool isSet;
        public bool state;
        public float opacity;

        public ObjectOpacityState(string node, bool isSet, bool state, float opacity)
        {
            this.node = node;
            this.isSet = isSet;
            this.state = state;
            this.opacity = opacity;
        }
    }
}
