using System;
using System.Collections.Generic;
using Mech3DotNet.Exchange;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public class Archive<TEntry>
    {
        private static readonly TypeConverter<List<ArchiveEntry>> ArchiveEntriesConverter = new TypeConverter<List<ArchiveEntry>>(DeserializeArchiveEntries, SerializeArchiveEntries);

        public Dictionary<string, TEntry> items;
        public List<ArchiveEntry> entries;

        public Archive(Dictionary<string, TEntry> items, byte[] manifest)
        {
            this.items = items ?? throw new ArgumentNullException(nameof(items));
            this.entries = Interop.Deserialize(manifest, ArchiveEntriesConverter);
        }

        public Archive(Dictionary<string, TEntry> items, List<ArchiveEntry> entries)
        {
            this.items = items ?? throw new ArgumentNullException(nameof(items));
            this.entries = entries ?? throw new ArgumentNullException(nameof(entries));
        }

        public byte[] SerializeManifest() => Interop.Serialize(entries, ArchiveEntriesConverter);

        private static void SerializeArchiveEntries(List<ArchiveEntry> v, Serializer s)
        {
            s.SerializeVec(s.Serialize(ArchiveEntry.Converter))(v);
        }

        private static List<ArchiveEntry> DeserializeArchiveEntries(Deserializer d)
        {
            return d.DeserializeVec(d.Deserialize(ArchiveEntry.Converter))();
        }
    }
}
