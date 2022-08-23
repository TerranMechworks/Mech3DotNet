using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(InvalidateAnimationConverter))]
    public class InvalidateAnimation
    {
        public string name;

        public InvalidateAnimation(string name)
        {
            this.name = name;
        }
    }
}
