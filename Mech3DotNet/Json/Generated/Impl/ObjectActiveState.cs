using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectActiveStateConverter))]
    public class ObjectActiveState
    {
        public string node;
        public bool state;

        public ObjectActiveState(string node, bool state)
        {
            this.node = node;
            this.state = state;
        }
    }
}
