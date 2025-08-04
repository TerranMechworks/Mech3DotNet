using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class Partition
    {
        public static readonly TypeConverter<Partition> Converter = new TypeConverter<Partition>(Deserialize, Serialize);
        public byte x;
        public byte z;

        public Partition(byte x, byte z)
        {
            this.x = x;
            this.z = z;
        }

        private struct Fields
        {
            public Field<byte> x;
            public Field<byte> z;
        }

        public static void Serialize(Partition v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("x");
            ((Action<byte>)s.SerializeU8)(v.x);
            s.SerializeFieldName("z");
            ((Action<byte>)s.SerializeU8)(v.z);
        }

        public static Partition Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                x = new Field<byte>(),
                z = new Field<byte>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "x":
                        fields.x.Value = d.DeserializeU8();
                        break;
                    case "z":
                        fields.z.Value = d.DeserializeU8();
                        break;
                    default:
                        throw new UnknownFieldException("Partition", fieldName);
                }
            }
            return new Partition(

                fields.x.Unwrap("Partition", "x"),

                fields.z.Unwrap("Partition", "z")

            );
        }
    }
}
