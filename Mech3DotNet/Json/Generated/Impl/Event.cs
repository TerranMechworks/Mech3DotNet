using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(EventConverter))]
    public class Event
    {
        public EventData data;
        public EventStart? start;

        public Event(EventData data, EventStart? start)
        {
            this.data = data;
            this.start = start;
        }
    }
}
