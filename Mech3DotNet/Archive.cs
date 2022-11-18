using System;
using System.Collections.Generic;
using Mech3DotNet.Json.Archive;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public class Archive<TEntry>
    {
        public Dictionary<string, TEntry> items;
        public List<ArchiveEntry> entries;

        public Archive(Dictionary<string, TEntry> items, byte[] manifest)
        {
            this.items = items ?? throw new ArgumentNullException(nameof(items));
            this.entries = Interop.Deserialize<List<ArchiveEntry>>(manifest);
        }

        public Archive(Dictionary<string, TEntry> items, List<ArchiveEntry> entries)
        {
            this.items = items ?? throw new ArgumentNullException(nameof(items));
            this.entries = entries ?? throw new ArgumentNullException(nameof(entries));
        }

        public byte[] SerializeManifest() => Interop.Serialize(entries);
    }
}
