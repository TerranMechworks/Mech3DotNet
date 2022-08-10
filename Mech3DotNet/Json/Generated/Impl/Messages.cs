using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(MessagesConverter))]
    public class Messages
    {
        public uint languageId;
        public List<MessageEntry> entries;

        public Messages(uint languageId, List<MessageEntry> entries)
        {
            this.languageId = languageId;
            this.entries = entries;
        }
    }
}
