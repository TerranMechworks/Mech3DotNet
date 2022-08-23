using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(PrereqAnimationConverter))]
    public struct PrereqAnimation
    {
        public string name;

        public PrereqAnimation(string name)
        {
            this.name = name;
        }
    }
}
