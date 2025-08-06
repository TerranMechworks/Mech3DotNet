using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Support
{
    public sealed class PufferRef
    {
        public string name;
        public byte flags;
        public uint ptr;

        public PufferRef(string name, byte flags, uint ptr)
        {
            this.name = name;
            this.flags = flags;
            this.ptr = ptr;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<PufferRef> Converter = new TypeConverter<PufferRef>(Deserialize, Serialize);

        public static void Serialize(PufferRef v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("flags");
            ((Action<byte>)s.SerializeU8)(v.flags);
            s.SerializeFieldName("ptr");
            ((Action<uint>)s.SerializeU32)(v.ptr);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<byte> flags;
            public Field<uint> ptr;
        }

        public static PufferRef Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                flags = new Field<byte>(),
                ptr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "flags":
                        fields.flags.Value = d.DeserializeU8();
                        break;
                    case "ptr":
                        fields.ptr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("PufferRef", fieldName);
                }
            }
            return new PufferRef(

                fields.name.Unwrap("PufferRef", "name"),

                fields.flags.Unwrap("PufferRef", "flags"),

                fields.ptr.Unwrap("PufferRef", "ptr")

            );
        }

        #endregion
    }
}
