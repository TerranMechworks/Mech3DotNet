using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(LoopConverter))]
    public class Loop
    {
        public int start;
        public int loopCount;

        public Loop(int start, int loopCount)
        {
            this.start = start;
            this.loopCount = loopCount;
        }
    }
}
