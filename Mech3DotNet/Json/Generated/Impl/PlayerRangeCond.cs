using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(PlayerRangeCondConverter))]
    public struct PlayerRangeCond
    {
        public float value;

        public PlayerRangeCond(float value)
        {
            this.value = value;
        }
    }
}
