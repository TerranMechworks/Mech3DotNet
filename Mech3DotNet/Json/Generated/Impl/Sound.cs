using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(SoundConverter))]
    public class Sound
    {
        public string name;
        public AtNode atNode;

        public Sound(string name, AtNode atNode)
        {
            this.name = name;
            this.atNode = atNode;
        }
    }
}
