using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(MessageEntryConverter))]
    public class MessageEntry
    {
        public string key;
        public uint id;
        public string value;

        public MessageEntry(string key, uint id, string value)
        {
            this.key = key;
            this.id = id;
            this.value = value;
        }
    }
}
