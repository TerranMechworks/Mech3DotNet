using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.AnimDef
{
    public sealed class NamePad
    {
        public string name;
        public byte[] pad;

        public NamePad(string name, byte[] pad)
        {
            this.name = name;
            this.pad = pad;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<NamePad> Converter = new TypeConverter<NamePad>(Deserialize, Serialize);

        public static void Serialize(NamePad v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("pad");
            ((Action<byte[]>)s.SerializeBytes)(v.pad);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<byte[]> pad;
        }

        public static NamePad Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                pad = new Field<byte[]>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
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

        #endregion
    }
}
