using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(StopAnimationConverter))]
    public class StopAnimation
    {
        public string name;

        public StopAnimation(string name)
        {
            this.name = name;
        }
    }
}
