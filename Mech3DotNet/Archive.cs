using System.Collections.Generic;
using Mech3DotNet.Exchange;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    /// <summary>A generic archive, used for archive-based ZBD data.</summary>
    public class Archive<TEntry>
    {
        public Dictionary<string, TEntry> items;
        public List<ArchiveEntry> entries;

        public Archive(Dictionary<string, TEntry> items, List<ArchiveEntry> entries)
        {
            this.items = items ?? throw new System.ArgumentNullException(nameof(items));
            this.entries = entries ?? throw new System.ArgumentNullException(nameof(entries));
        }

        internal byte[] SerializeManifest() => Interop.Serialize(entries, ArchiveEntriesConverter);
        internal static List<ArchiveEntry> DeserializeManifest(byte[] manifest_data) => Interop.Deserialize(manifest_data, ArchiveEntriesConverter);

        private static readonly TypeConverter<List<ArchiveEntry>> ArchiveEntriesConverter = new TypeConverter<List<ArchiveEntry>>(DeserializeArchiveEntries, SerializeArchiveEntries);

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
