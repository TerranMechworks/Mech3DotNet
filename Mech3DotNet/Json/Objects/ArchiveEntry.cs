using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class ArchiveEntry
    {
        [JsonProperty("name", Required = Required.Always)]
        public string name;
        [JsonProperty("garbage", Required = Required.Always)]
        public byte[] garbage;

        public ArchiveEntry(string name, byte[] garbage)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.garbage = garbage ?? throw new ArgumentNullException(nameof(garbage));
        }

        [JsonConstructor]
        private ArchiveEntry() { }

        public override bool Equals(object obj)
        {
            return obj is ArchiveEntry entry &&
                   name == entry.name &&
                   EqualityComparer<byte[]>.Default.Equals(garbage, entry.garbage);
        }

        public override int GetHashCode()
        {
            int hashCode = 1214626306;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<byte[]>.Default.GetHashCode(garbage);
            return hashCode;
        }
    }
}
