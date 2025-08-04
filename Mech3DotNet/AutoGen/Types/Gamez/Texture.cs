using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class Texture
    {
        public static readonly TypeConverter<Texture> Converter = new TypeConverter<Texture>(Deserialize, Serialize);
        public string name;
        public short mipIndex = -1;

        public Texture(string name, short mipIndex)
        {
            this.name = name;
            this.mipIndex = mipIndex;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<short> mipIndex;
        }

        public static void Serialize(Texture v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("mip_index");
            ((Action<short>)s.SerializeI16)(v.mipIndex);
        }

        public static Texture Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                mipIndex = new Field<short>(-1),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "mip_index":
                        fields.mipIndex.Value = d.DeserializeI16();
                        break;
                    default:
                        throw new UnknownFieldException("Texture", fieldName);
                }
            }
            return new Texture(

                fields.name.Unwrap("Texture", "name"),

                fields.mipIndex.Unwrap("Texture", "mipIndex")

            );
        }
    }
}
