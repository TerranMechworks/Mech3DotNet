using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectCycleTexture
    {
        public static readonly TypeConverter<ObjectCycleTexture> Converter = new TypeConverter<ObjectCycleTexture>(Deserialize, Serialize);
        public string node;
        public ushort reset;

        public ObjectCycleTexture(string node, ushort reset)
        {
            this.node = node;
            this.reset = reset;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<ushort> reset;
        }

        public static void Serialize(ObjectCycleTexture v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("reset");
            ((Action<ushort>)s.SerializeU16)(v.reset);
        }

        public static ObjectCycleTexture Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                reset = new Field<ushort>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "reset":
                        fields.reset.Value = d.DeserializeU16();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectCycleTexture", fieldName);
                }
            }
            return new ObjectCycleTexture(

                fields.node.Unwrap("ObjectCycleTexture", "node"),

                fields.reset.Unwrap("ObjectCycleTexture", "reset")

            );
        }
    }
}
