using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Support
{
    public sealed class EffectRef
    {
        public string name;
        public uint index;
        public byte[] pad;

        public EffectRef(string name, uint index, byte[] pad)
        {
            this.name = name;
            this.index = index;
            this.pad = pad;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<EffectRef> Converter = new TypeConverter<EffectRef>(Deserialize, Serialize);

        public static void Serialize(EffectRef v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("index");
            ((Action<uint>)s.SerializeU32)(v.index);
            s.SerializeFieldName("pad");
            ((Action<byte[]>)s.SerializeBytes)(v.pad);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<uint> index;
            public Field<byte[]> pad;
        }

        public static EffectRef Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                index = new Field<uint>(),
                pad = new Field<byte[]>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "index":
                        fields.index.Value = d.DeserializeU32();
                        break;
                    case "pad":
                        fields.pad.Value = d.DeserializeBytes();
                        break;
                    default:
                        throw new UnknownFieldException("EffectRef", fieldName);
                }
            }
            return new EffectRef(

                fields.name.Unwrap("EffectRef", "name"),

                fields.index.Unwrap("EffectRef", "index"),

                fields.pad.Unwrap("EffectRef", "pad")

            );
        }

        #endregion
    }
}
