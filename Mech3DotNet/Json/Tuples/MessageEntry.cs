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

        public override bool Equals(object obj)
        {
            return obj is MessageEntry entry &&
                   key == entry.key &&
                   id == entry.id &&
                   value == entry.value;
        }

        public override int GetHashCode()
        {
            int hashCode = -2002921770;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(key);
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(value);
            return hashCode;
        }
    }
}
