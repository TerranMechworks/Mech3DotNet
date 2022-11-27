using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public struct NamePtrFlags
    {
        public static readonly TypeConverter<NamePtrFlags> Converter = new TypeConverter<NamePtrFlags>(Deserialize, Serialize);
        public string name;
        public uint pointer;
        public uint flags;

        public NamePtrFlags(string name, uint pointer, uint flags)
        {
            this.name = name;
            this.pointer = pointer;
            this.flags = flags;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<uint> pointer;
            public Field<uint> flags;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.NamePtrFlags v, Serializer s)
        {
            s.SerializeStruct("NamePtrFlags", 3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("pointer");
            ((Action<uint>)s.SerializeU32)(v.pointer);
            s.SerializeFieldName("flags");
            ((Action<uint>)s.SerializeU32)(v.flags);
        }

        public static Mech3DotNet.Types.Anim.NamePtrFlags Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                pointer = new Field<uint>(),
                flags = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("NamePtrFlags"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "pointer":
                        fields.pointer.Value = d.DeserializeU32();
                        break;
                    case "flags":
                        fields.flags.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("NamePtrFlags", fieldName);
                }
            }
            return new NamePtrFlags(

                fields.name.Unwrap("NamePtrFlags", "name"),

                fields.pointer.Unwrap("NamePtrFlags", "pointer"),

                fields.flags.Unwrap("NamePtrFlags", "flags")

            );
        }
    }
}
