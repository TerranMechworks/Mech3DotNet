using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(SeqDefConverter))]
    public class SeqDef
    {
        public string name;
        public SeqActivation activation;
        public List<Event> events;
        public uint pointer;

        public SeqDef(string name, SeqActivation activation, List<Event> events, uint pointer)
        {
            this.name = name;
            this.activation = activation;
            this.events = events;
            this.pointer = pointer;
        }
    }
}
