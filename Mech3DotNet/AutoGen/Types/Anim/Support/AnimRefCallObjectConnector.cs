using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Support
{
    public sealed class AnimRefCallObjectConnector
    {
        public static readonly TypeConverter<AnimRefCallObjectConnector> Converter = new TypeConverter<AnimRefCallObjectConnector>(Deserialize, Serialize);
        public string name;
        public byte[] namePad;
        public string localName;
        public byte[] localNamePad;

        public AnimRefCallObjectConnector(string name, byte[] namePad, string localName, byte[] localNamePad)
        {
            this.name = name;
            this.namePad = namePad;
            this.localName = localName;
            this.localNamePad = localNamePad;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<byte[]> namePad;
            public Field<string> localName;
            public Field<byte[]> localNamePad;
        }

        public static void Serialize(AnimRefCallObjectConnector v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("name_pad");
            ((Action<byte[]>)s.SerializeBytes)(v.namePad);
            s.SerializeFieldName("local_name");
            ((Action<string>)s.SerializeString)(v.localName);
            s.SerializeFieldName("local_name_pad");
            ((Action<byte[]>)s.SerializeBytes)(v.localNamePad);
        }

        public static AnimRefCallObjectConnector Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                namePad = new Field<byte[]>(),
                localName = new Field<string>(),
                localNamePad = new Field<byte[]>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "name_pad":
                        fields.namePad.Value = d.DeserializeBytes();
                        break;
                    case "local_name":
                        fields.localName.Value = d.DeserializeString();
                        break;
                    case "local_name_pad":
                        fields.localNamePad.Value = d.DeserializeBytes();
                        break;
                    default:
                        throw new UnknownFieldException("AnimRefCallObjectConnector", fieldName);
                }
            }
            return new AnimRefCallObjectConnector(

                fields.name.Unwrap("AnimRefCallObjectConnector", "name"),

                fields.namePad.Unwrap("AnimRefCallObjectConnector", "namePad"),

                fields.localName.Unwrap("AnimRefCallObjectConnector", "localName"),

                fields.localNamePad.Unwrap("AnimRefCallObjectConnector", "localNamePad")

            );
        }
    }
}
