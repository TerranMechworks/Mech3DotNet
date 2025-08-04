using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class MechlibTexturedMaterial
    {
        public static readonly TypeConverter<MechlibTexturedMaterial> Converter = new TypeConverter<MechlibTexturedMaterial>(Deserialize, Serialize);
        public string textureName;
        public uint ptr;

        public MechlibTexturedMaterial(string textureName, uint ptr)
        {
            this.textureName = textureName;
            this.ptr = ptr;
        }

        private struct Fields
        {
            public Field<string> textureName;
            public Field<uint> ptr;
        }

        public static void Serialize(MechlibTexturedMaterial v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("texture_name");
            ((Action<string>)s.SerializeString)(v.textureName);
            s.SerializeFieldName("ptr");
            ((Action<uint>)s.SerializeU32)(v.ptr);
        }

        public static MechlibTexturedMaterial Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textureName = new Field<string>(),
                ptr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "texture_name":
                        fields.textureName.Value = d.DeserializeString();
                        break;
                    case "ptr":
                        fields.ptr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("MechlibTexturedMaterial", fieldName);
                }
            }
            return new MechlibTexturedMaterial(

                fields.textureName.Unwrap("MechlibTexturedMaterial", "textureName"),

                fields.ptr.Unwrap("MechlibTexturedMaterial", "ptr")

            );
        }
    }
}
