using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(EventStartConverter))]
    public struct EventStart
    {
        public StartOffset offset;
        public float time;

        public EventStart(StartOffset offset, float time)
        {
            this.offset = offset;
            this.time = time;
        }
    }
}
