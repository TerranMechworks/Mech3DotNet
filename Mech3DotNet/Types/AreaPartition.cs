using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes
{
    public struct AreaPartition
    {
        public static readonly TypeConverter<AreaPartition> Converter = new TypeConverter<AreaPartition>(Deserialize, Serialize);
        public int x;
        public int y;

        public AreaPartition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        private struct Fields
        {
            public Field<int> x;
            public Field<int> y;
        }

        public static void Serialize(Mech3DotNet.Types.Nodes.AreaPartition v, Serializer s)
        {
            s.SerializeStruct("AreaPartition", 2);
            s.SerializeFieldName("x");
            ((Action<int>)s.SerializeI32)(v.x);
            s.SerializeFieldName("y");
            ((Action<int>)s.SerializeI32)(v.y);
        }

        public static Mech3DotNet.Types.Nodes.AreaPartition Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                x = new Field<int>(),
                y = new Field<int>(),
            };
            foreach (var fieldName in d.DeserializeStruct("AreaPartition"))
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
