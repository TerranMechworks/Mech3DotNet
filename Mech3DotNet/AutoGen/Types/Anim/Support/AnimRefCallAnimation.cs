using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Support
{
    public sealed class AnimRefCallAnimation
    {
        public string name;
        public byte[] namePad;

        public AnimRefCallAnimation(string name, byte[] namePad)
        {
            this.name = name;
            this.namePad = namePad;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<AnimRefCallAnimation> Converter = new TypeConverter<AnimRefCallAnimation>(Deserialize, Serialize);

        public static void Serialize(AnimRefCallAnimation v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("name_pad");
            ((Action<byte[]>)s.SerializeBytes)(v.namePad);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<byte[]> namePad;
        }

        public static AnimRefCallAnimation Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                namePad = new Field<byte[]>(),
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
                    default:
                        throw new UnknownFieldException("AnimRefCallAnimation", fieldName);
                }
            }
            return new AnimRefCallAnimation(

                fields.name.Unwrap("AnimRefCallAnimation", "name"),

                fields.namePad.Unwrap("AnimRefCallAnimation", "namePad")

            );
        }

        #endregion
    }
}
