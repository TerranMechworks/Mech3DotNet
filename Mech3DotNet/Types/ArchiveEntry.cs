using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Archive
{
    public sealed class ArchiveEntry
    {
        public static readonly TypeConverter<ArchiveEntry> Converter = new TypeConverter<ArchiveEntry>(Deserialize, Serialize);
        public string name;
        public string? rename = null;
        public byte[] garbage;

        public ArchiveEntry(string name, string? rename, byte[] garbage)
        {
            this.name = name;
            this.rename = rename;
            this.garbage = garbage;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<string?> rename;
            public Field<byte[]> garbage;
        }

        public static void Serialize(ArchiveEntry v, Serializer s)
        {
            s.SerializeStruct("ArchiveEntry", 3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("rename");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.rename);
            s.SerializeFieldName("garbage");
            ((Action<byte[]>)s.SerializeBytes)(v.garbage);
        }

        public static ArchiveEntry Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                rename = new Field<string?>(null),
                garbage = new Field<byte[]>(),
            };
            foreach (var fieldName in d.DeserializeStruct("ArchiveEntry"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "rename":
                        fields.rename.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "garbage":
                        fields.garbage.Value = d.DeserializeBytes();
                        break;
                    default:
                        throw new UnknownFieldException("ArchiveEntry", fieldName);
                }
            }
            return new ArchiveEntry(

                fields.name.Unwrap("ArchiveEntry", "name"),

                fields.rename.Unwrap("ArchiveEntry", "rename"),

                fields.garbage.Unwrap("ArchiveEntry", "garbage")

            );
        }
    }
}
