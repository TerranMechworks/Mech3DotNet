using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(PlayerFirstPersonCondConverter))]
    public struct PlayerFirstPersonCond
    {
        public bool value;

        public PlayerFirstPersonCond(bool value)
        {
            this.value = value;
        }
    }
}
