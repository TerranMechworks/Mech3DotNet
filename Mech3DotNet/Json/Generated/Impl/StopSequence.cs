using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(StopSequenceConverter))]
    public class StopSequence
    {
        public string name;

        public StopSequence(string name)
        {
            this.name = name;
        }
    }
}
