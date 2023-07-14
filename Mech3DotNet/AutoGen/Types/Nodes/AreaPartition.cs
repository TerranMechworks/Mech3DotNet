using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes
{
    public struct AreaPartition
    {
        public int x;
        public int y;

        public AreaPartition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public static class AreaPartitionConverter
    {
        public static readonly TypeConverter<AreaPartition> Converter = new TypeConverter<AreaPartition>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<int> x;
            public Field<int> y;
        }

        public static void Serialize(AreaPartition v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("x");
            ((Action<int>)s.SerializeI32)(v.x);
            s.SerializeFieldName("y");
            ((Action<int>)s.SerializeI32)(v.y);
        }

        public static AreaPartition Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                x = new Field<int>(),
                y = new Field<int>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "x":
                        fields.x.Value = d.DeserializeI32();
                        break;
                    case "y":
                        fields.y.Value = d.DeserializeI32();
                        break;
                    default:
                        throw new UnknownFieldException("AreaPartition", fieldName);
                }
            }
            return new AreaPartition(

                fields.x.Unwrap("AreaPartition", "x"),

                fields.y.Unwrap("AreaPartition", "y")

            );
        }
    }
}
