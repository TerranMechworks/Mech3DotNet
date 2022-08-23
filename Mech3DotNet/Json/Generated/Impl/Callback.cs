using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(CallbackConverter))]
    public class Callback
    {
        public uint value;

        public Callback(uint value)
        {
            this.value = value;
        }
    }
}
