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
            this.name = name;
            this.garbage = garbage;
        }

        [JsonConstructor]
        private ArchiveEntry() { }
    }
}
