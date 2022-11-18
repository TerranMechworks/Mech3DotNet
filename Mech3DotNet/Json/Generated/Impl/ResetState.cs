using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ResetStateConverter))]
    public class ResetState
    {
        public List<Event> events;
        public uint pointer;

        public ResetState(List<Event> events, uint pointer)
        {
            this.events = events;
            this.pointer = pointer;
        }
    }
}
