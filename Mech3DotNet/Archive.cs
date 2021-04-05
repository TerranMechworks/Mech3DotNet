using Mech3DotNet.Json;
using Mech3DotNet.Unsafe;
using System;
using System.Collections.Generic;

namespace Mech3DotNet
{
    public class Archive<T>
    {
        public Dictionary<string, T> items;
        public List<ArchiveEntry> entries;

        public Archive(Dictionary<string, T> items, byte[] manifest)
        {
            if (manifest == null)
                throw new ArgumentNullException(nameof(manifest));
            this.items = items ?? throw new ArgumentNullException(nameof(items));
            var json = Interop.GetString(manifest);
            entries = Settings.DeserializeObject<List<ArchiveEntry>>(json);
        }

        public Archive(Dictionary<string, T> items, List<ArchiveEntry> entries)
        {
            this.items = items ?? throw new ArgumentNullException(nameof(items));
            this.entries = entries ?? throw new ArgumentNullException(nameof(entries));
        }

        public byte[] GetManifest()
        {
            var json = Settings.SerializeObject(entries);
            return Interop.GetBytes(json);
        }
    }
}
