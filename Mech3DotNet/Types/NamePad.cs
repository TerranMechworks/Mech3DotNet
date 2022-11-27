using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public struct NamePad
    {
        public static readonly TypeConverter<NamePad> Converter = new TypeConverter<NamePad>(Deserialize, Serialize);
        public string name;
        public byte[] pad;

        public NamePad(string name, byte[] pad)
        {
            this.name = name;
            this.pad = pad;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<byte[]> pad;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.NamePad v, Serializer s)
        {
            s.SerializeStruct("NamePad", 2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("pad");
            ((Action<byte[]>)s.SerializeBytes)(v.pad);
        }

        public static Mech3DotNet.Types.Anim.NamePad Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                pad = new Field<byte[]>(),
            };
            foreach (var fieldName in d.DeserializeStruct("NamePad"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "pad":
                        fields.pad.Value = d.DeserializeBytes();
                        break;
                    default:
                        throw new UnknownFieldException("NamePad", fieldName);
                }
            }
            return new NamePad(

                fields.name.Unwrap("NamePad", "name"),

                fields.pad.Unwrap("NamePad", "pad")

            );
        }
    }
}
