using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public struct NamePtr
    {
        public static readonly TypeConverter<NamePtr> Converter = new TypeConverter<NamePtr>(Deserialize, Serialize);
        public string name;
        public uint pointer;

        public NamePtr(string name, uint pointer)
        {
            this.name = name;
            this.pointer = pointer;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<uint> pointer;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.NamePtr v, Serializer s)
        {
            s.SerializeStruct("NamePtr", 2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("pointer");
            ((Action<uint>)s.SerializeU32)(v.pointer);
        }

        public static Mech3DotNet.Types.Anim.NamePtr Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                pointer = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("NamePtr"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "pointer":
                        fields.pointer.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("NamePtr", fieldName);
                }
            }
            return new NamePtr(

                fields.name.Unwrap("NamePtr", "name"),

                fields.pointer.Unwrap("NamePtr", "pointer")

            );
        }
    }
}
