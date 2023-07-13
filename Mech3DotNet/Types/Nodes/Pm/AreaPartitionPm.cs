using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Pm
{
    public sealed class AreaPartitionPm
    {
        public static readonly TypeConverter<AreaPartitionPm> Converter = new TypeConverter<AreaPartitionPm>(Deserialize, Serialize);
        public short x;
        public short y;
        public short virtualX;
        public short virtualY;

        public AreaPartitionPm(short x, short y, short virtualX, short virtualY)
        {
            this.x = x;
            this.y = y;
            this.virtualX = virtualX;
            this.virtualY = virtualY;
        }

        private struct Fields
        {
            public Field<short> x;
            public Field<short> y;
            public Field<short> virtualX;
            public Field<short> virtualY;
        }

        public static void Serialize(AreaPartitionPm v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("x");
            ((Action<short>)s.SerializeI16)(v.x);
            s.SerializeFieldName("y");
            ((Action<short>)s.SerializeI16)(v.y);
            s.SerializeFieldName("virtual_x");
            ((Action<short>)s.SerializeI16)(v.virtualX);
            s.SerializeFieldName("virtual_y");
            ((Action<short>)s.SerializeI16)(v.virtualY);
        }

        public static AreaPartitionPm Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                x = new Field<short>(),
                y = new Field<short>(),
                virtualX = new Field<short>(),
                virtualY = new Field<short>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "x":
                        fields.x.Value = d.DeserializeI16();
                        break;
                    case "y":
                        fields.y.Value = d.DeserializeI16();
                        break;
                    case "virtual_x":
                        fields.virtualX.Value = d.DeserializeI16();
                        break;
                    case "virtual_y":
                        fields.virtualY.Value = d.DeserializeI16();
                        break;
                    default:
                        throw new UnknownFieldException("AreaPartitionPm", fieldName);
                }
            }
            return new AreaPartitionPm(

                fields.x.Unwrap("AreaPartitionPm", "x"),

                fields.y.Unwrap("AreaPartitionPm", "y"),

                fields.virtualX.Unwrap("AreaPartitionPm", "virtualX"),

                fields.virtualY.Unwrap("AreaPartitionPm", "virtualY")

            );
        }
    }
}
