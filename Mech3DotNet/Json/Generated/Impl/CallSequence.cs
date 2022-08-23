using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(CallSequenceConverter))]
    public class CallSequence
    {
        public string name;

        public CallSequence(string name)
        {
            this.name = name;
        }
    }
}
