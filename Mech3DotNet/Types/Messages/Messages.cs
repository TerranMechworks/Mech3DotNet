using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Messages
{
    public partial class Messages
    {
        public static readonly TypeConverter<Messages> Converter = new TypeConverter<Messages>(Deserialize, Serialize);
        public uint languageId;
        public System.Collections.Generic.List<Mech3DotNet.Types.Messages.MessageEntry> entries;

        public Messages(uint languageId, System.Collections.Generic.List<Mech3DotNet.Types.Messages.MessageEntry> entries)
        {
            this.languageId = languageId;
            this.entries = entries;
        }

        private struct Fields
        {
            public Field<uint> languageId;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Messages.MessageEntry>> entries;
        }

        public static void Serialize(Messages v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("language_id");
            ((Action<uint>)s.SerializeU32)(v.languageId);
            s.SerializeFieldName("entries");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Messages.MessageEntry.Converter))(v.entries);
        }

        public static Messages Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                languageId = new Field<uint>(),
                entries = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Messages.MessageEntry>>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "language_id":
                        fields.languageId.Value = d.DeserializeU32();
                        break;
                    case "entries":
                        fields.entries.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Messages.MessageEntry.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("Messages", fieldName);
                }
            }
            return new Messages(

                fields.languageId.Unwrap("Messages", "languageId"),

                fields.entries.Unwrap("Messages", "entries")

            );
        }
    }
}
