using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Archive
{
    public sealed class ArchiveEntry
    {
        public string name;
        public string? rename = null;
        public uint flags;
        public Mech3DotNet.Types.Archive.ArchiveEntryInfo info;

        public ArchiveEntry(string name, string? rename, uint flags, Mech3DotNet.Types.Archive.ArchiveEntryInfo info)
        {
            this.name = name;
            this.rename = rename;
            this.flags = flags;
            this.info = info;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<ArchiveEntry> Converter = new TypeConverter<ArchiveEntry>(Deserialize, Serialize);

        public static void Serialize(ArchiveEntry v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("rename");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.rename);
            s.SerializeFieldName("flags");
            ((Action<uint>)s.SerializeU32)(v.flags);
            s.SerializeFieldName("info");
            s.Serialize(Mech3DotNet.Types.Archive.ArchiveEntryInfo.Converter)(v.info);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<string?> rename;
            public Field<uint> flags;
            public Field<Mech3DotNet.Types.Archive.ArchiveEntryInfo> info;
        }

        public static ArchiveEntry Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                rename = new Field<string?>(null),
                flags = new Field<uint>(),
                info = new Field<Mech3DotNet.Types.Archive.ArchiveEntryInfo>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "rename":
                        fields.rename.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "flags":
                        fields.flags.Value = d.DeserializeU32();
                        break;
                    case "info":
                        fields.info.Value = d.Deserialize(Mech3DotNet.Types.Archive.ArchiveEntryInfo.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("ArchiveEntry", fieldName);
                }
            }
            return new ArchiveEntry(

                fields.name.Unwrap("ArchiveEntry", "name"),

                fields.rename.Unwrap("ArchiveEntry", "rename"),

                fields.flags.Unwrap("ArchiveEntry", "flags"),

                fields.info.Unwrap("ArchiveEntry", "info")

            );
        }

        #endregion
    }
}
