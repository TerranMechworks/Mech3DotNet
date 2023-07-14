using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes
{
    public sealed class PartitionPg
    {
        public static readonly TypeConverter<PartitionPg> Converter = new TypeConverter<PartitionPg>(Deserialize, Serialize);
        public int x;
        public int y;
        public float zMin;
        public float zMax;
        public System.Collections.Generic.List<uint> nodes;
        public uint ptr;

        public PartitionPg(int x, int y, float zMin, float zMax, System.Collections.Generic.List<uint> nodes, uint ptr)
        {
            this.x = x;
            this.y = y;
            this.zMin = zMin;
            this.zMax = zMax;
            this.nodes = nodes;
            this.ptr = ptr;
        }

        private struct Fields
        {
            public Field<int> x;
            public Field<int> y;
            public Field<float> zMin;
            public Field<float> zMax;
            public Field<System.Collections.Generic.List<uint>> nodes;
            public Field<uint> ptr;
        }

        public static void Serialize(PartitionPg v, Serializer s)
        {
            s.SerializeStruct(6);
            s.SerializeFieldName("x");
            ((Action<int>)s.SerializeI32)(v.x);
            s.SerializeFieldName("y");
            ((Action<int>)s.SerializeI32)(v.y);
            s.SerializeFieldName("z_min");
            ((Action<float>)s.SerializeF32)(v.zMin);
            s.SerializeFieldName("z_max");
            ((Action<float>)s.SerializeF32)(v.zMax);
            s.SerializeFieldName("nodes");
            s.SerializeVec(((Action<uint>)s.SerializeU32))(v.nodes);
            s.SerializeFieldName("ptr");
            ((Action<uint>)s.SerializeU32)(v.ptr);
        }

        public static PartitionPg Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                x = new Field<int>(),
                y = new Field<int>(),
                zMin = new Field<float>(),
                zMax = new Field<float>(),
                nodes = new Field<System.Collections.Generic.List<uint>>(),
                ptr = new Field<uint>(),
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
                    case "z_min":
                        fields.zMin.Value = d.DeserializeF32();
                        break;
                    case "z_max":
                        fields.zMax.Value = d.DeserializeF32();
                        break;
                    case "nodes":
                        fields.nodes.Value = d.DeserializeVec(d.DeserializeU32)();
                        break;
                    case "ptr":
                        fields.ptr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("PartitionPg", fieldName);
                }
            }
            return new PartitionPg(

                fields.x.Unwrap("PartitionPg", "x"),

                fields.y.Unwrap("PartitionPg", "y"),

                fields.zMin.Unwrap("PartitionPg", "zMin"),

                fields.zMax.Unwrap("PartitionPg", "zMax"),

                fields.nodes.Unwrap("PartitionPg", "nodes"),

                fields.ptr.Unwrap("PartitionPg", "ptr")

            );
        }
    }
}
