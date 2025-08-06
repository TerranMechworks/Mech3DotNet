using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Archive
{
    public sealed class ArchiveEntryInfoInvalid
    {
        public byte[] comment;
        public ulong filetime;

        public ArchiveEntryInfoInvalid(byte[] comment, ulong filetime)
        {
            this.comment = comment;
            this.filetime = filetime;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<ArchiveEntryInfoInvalid> Converter = new TypeConverter<ArchiveEntryInfoInvalid>(Deserialize, Serialize);

        public static void Serialize(ArchiveEntryInfoInvalid v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("comment");
            ((Action<byte[]>)s.SerializeBytes)(v.comment);
            s.SerializeFieldName("filetime");
            ((Action<ulong>)s.SerializeU64)(v.filetime);
        }

        private struct Fields
        {
            public Field<byte[]> comment;
            public Field<ulong> filetime;
        }

        public static ArchiveEntryInfoInvalid Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                comment = new Field<byte[]>(),
                filetime = new Field<ulong>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "comment":
                        fields.comment.Value = d.DeserializeBytes();
                        break;
                    case "filetime":
                        fields.filetime.Value = d.DeserializeU64();
                        break;
                    default:
                        throw new UnknownFieldException("ArchiveEntryInfoInvalid", fieldName);
                }
            }
            return new ArchiveEntryInfoInvalid(

                fields.comment.Unwrap("ArchiveEntryInfoInvalid", "comment"),

                fields.filetime.Unwrap("ArchiveEntryInfoInvalid", "filetime")

            );
        }

        #endregion
    }
}
