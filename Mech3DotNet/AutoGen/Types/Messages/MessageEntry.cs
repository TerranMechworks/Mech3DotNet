using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Messages
{
    public sealed class MessageEntry
    {
        public string key;
        public uint id;
        public string value;

        public MessageEntry(string key, uint id, string value)
        {
            this.key = key;
            this.id = id;
            this.value = value;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<MessageEntry> Converter = new TypeConverter<MessageEntry>(Deserialize, Serialize);

        public static void Serialize(MessageEntry v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("key");
            ((Action<string>)s.SerializeString)(v.key);
            s.SerializeFieldName("id");
            ((Action<uint>)s.SerializeU32)(v.id);
            s.SerializeFieldName("value");
            ((Action<string>)s.SerializeString)(v.value);
        }

        private struct Fields
        {
            public Field<string> key;
            public Field<uint> id;
            public Field<string> value;
        }

        public static MessageEntry Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                key = new Field<string>(),
                id = new Field<uint>(),
                value = new Field<string>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "key":
                        fields.key.Value = d.DeserializeString();
                        break;
                    case "id":
                        fields.id.Value = d.DeserializeU32();
                        break;
                    case "value":
                        fields.value.Value = d.DeserializeString();
                        break;
                    default:
                        throw new UnknownFieldException("MessageEntry", fieldName);
                }
            }
            return new MessageEntry(

                fields.key.Unwrap("MessageEntry", "key"),

                fields.id.Unwrap("MessageEntry", "id"),

                fields.value.Unwrap("MessageEntry", "value")

            );
        }

        #endregion
    }
}
