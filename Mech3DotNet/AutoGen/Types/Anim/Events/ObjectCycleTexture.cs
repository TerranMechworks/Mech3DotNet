using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectCycleTexture
    {
        public static readonly TypeConverter<ObjectCycleTexture> Converter = new TypeConverter<ObjectCycleTexture>(Deserialize, Serialize);
        public string name;
        public ushort reset;

        public ObjectCycleTexture(string name, ushort reset)
        {
            this.name = name;
            this.reset = reset;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<ushort> reset;
        }

        public static void Serialize(ObjectCycleTexture v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("reset");
            ((Action<ushort>)s.SerializeU16)(v.reset);
        }

        public static ObjectCycleTexture Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                reset = new Field<ushort>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "reset":
                        fields.reset.Value = d.DeserializeU16();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectCycleTexture", fieldName);
                }
            }
            return new ObjectCycleTexture(

                fields.name.Unwrap("ObjectCycleTexture", "name"),

                fields.reset.Unwrap("ObjectCycleTexture", "reset")

            );
        }
    }
}
