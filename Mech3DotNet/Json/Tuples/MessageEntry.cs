using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
            this.key = key ?? throw new ArgumentNullException(nameof(key));
            this.id = id;
            this.value = value ?? throw new ArgumentNullException(nameof(value));
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
