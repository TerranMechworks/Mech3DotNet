using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Archive
{
    public sealed class ArchiveEntryInfoValid
    {
        public static readonly TypeConverter<ArchiveEntryInfoValid> Converter = new TypeConverter<ArchiveEntryInfoValid>(Deserialize, Serialize);
        public string comment;
        public System.DateTime datetime;

        public ArchiveEntryInfoValid(string comment, System.DateTime datetime)
        {
            this.comment = comment;
            this.datetime = datetime;
        }

        private struct Fields
        {
            public Field<string> comment;
            public Field<System.DateTime> datetime;
        }

        public static void Serialize(ArchiveEntryInfoValid v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("comment");
            ((Action<string>)s.SerializeString)(v.comment);
            s.SerializeFieldName("datetime");
            ((Action<DateTime>)s.SerializeDateTime)(v.datetime);
        }

        public static ArchiveEntryInfoValid Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                comment = new Field<string>(),
                datetime = new Field<System.DateTime>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "comment":
                        fields.comment.Value = d.DeserializeString();
                        break;
                    case "datetime":
                        fields.datetime.Value = d.DeserializeDateTime();
                        break;
                    default:
                        throw new UnknownFieldException("ArchiveEntryInfoValid", fieldName);
                }
            }
            return new ArchiveEntryInfoValid(

                fields.comment.Unwrap("ArchiveEntryInfoValid", "comment"),

                fields.datetime.Unwrap("ArchiveEntryInfoValid", "datetime")

            );
        }
    }
}
