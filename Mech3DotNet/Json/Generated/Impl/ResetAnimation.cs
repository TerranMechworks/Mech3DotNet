using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ResetAnimationConverter))]
    public class ResetAnimation
    {
        public string name;

        public ResetAnimation(string name)
        {
            this.name = name;
        }
    }
}
