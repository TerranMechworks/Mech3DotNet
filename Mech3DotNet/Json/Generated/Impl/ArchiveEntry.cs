using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ArchiveEntryConverter))]
    public class ArchiveEntry
    {
        public string name;
        public string? rename = null;
        public byte[] garbage;

        public ArchiveEntry(string name, string? rename, byte[] garbage)
        {
            this.name = name;
            this.rename = rename;
            this.garbage = garbage;
        }
    }
}
