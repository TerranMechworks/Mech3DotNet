using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TupleConverter<MessageEntry>))]
    public class MessageEntry
    {
        public string key;
        public int id;
        public string value;

        public MessageEntry(string key, int id, string value)
        {
            this.key = key;
            this.id = id;
            this.value = value;
        }
    }
}
