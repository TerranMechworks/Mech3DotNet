using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Support
{
    public sealed class StaticSoundRef
    {
        public static readonly TypeConverter<StaticSoundRef> Converter = new TypeConverter<StaticSoundRef>(Deserialize, Serialize);
        public string name;
        public byte[] pad;

        public StaticSoundRef(string name, byte[] pad)
        {
            this.name = name;
            this.pad = pad;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<byte[]> pad;
        }

        public static void Serialize(StaticSoundRef v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("pad");
            ((Action<byte[]>)s.SerializeBytes)(v.pad);
        }

        public static StaticSoundRef Deserialize(Deserializer d)
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
                        throw new UnknownFieldException("StaticSoundRef", fieldName);
                }
            }
            return new StaticSoundRef(

                fields.name.Unwrap("StaticSoundRef", "name"),

                fields.pad.Unwrap("StaticSoundRef", "pad")

            );
        }
    }
}
