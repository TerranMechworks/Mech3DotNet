using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(SoundNodeConverter))]
    public class SoundNode
    {
        public string name;
        public bool activeState;
        public AtNode? atNode = null;

        public SoundNode(string name, bool activeState, AtNode? atNode)
        {
            this.name = name;
            this.activeState = activeState;
            this.atNode = atNode;
        }
    }
}
