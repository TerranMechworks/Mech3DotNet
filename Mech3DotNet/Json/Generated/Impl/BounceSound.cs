using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(BounceSoundConverter))]
    public class BounceSound
    {
        public string name;
        public float volume;

        public BounceSound(string name, float volume)
        {
            this.name = name;
            this.volume = volume;
        }
    }
}
