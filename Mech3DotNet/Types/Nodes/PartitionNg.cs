using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes
{
    public sealed class PartitionNg
    {
        public static readonly TypeConverter<PartitionNg> Converter = new TypeConverter<PartitionNg>(Deserialize, Serialize);
        public int x;
        public int y;
        public float zMin;
        public float zMax;
        public System.Collections.Generic.List<Mech3DotNet.Types.Nodes.PartitionValue> nodes;
        public uint ptr;

        public PartitionNg(int x, int y, float zMin, float zMax, System.Collections.Generic.List<Mech3DotNet.Types.Nodes.PartitionValue> nodes, uint ptr)
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
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.PartitionValue>> nodes;
            public Field<uint> ptr;
        }

        public static void Serialize(PartitionNg v, Serializer s)
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
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Nodes.PartitionValue.Converter))(v.nodes);
            s.SerializeFieldName("ptr");
            ((Action<uint>)s.SerializeU32)(v.ptr);
        }

        public static PartitionNg Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                x = new Field<int>(),
                y = new Field<int>(),
                zMin = new Field<float>(),
                zMax = new Field<float>(),
                nodes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.PartitionValue>>(),
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
                        fields.nodes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Nodes.PartitionValue.Converter))();
                        break;
                    case "ptr":
                        fields.ptr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("PartitionNg", fieldName);
                }
            }
            return new PartitionNg(

                fields.x.Unwrap("PartitionNg", "x"),

                fields.y.Unwrap("PartitionNg", "y"),

                fields.zMin.Unwrap("PartitionNg", "zMin"),

                fields.zMax.Unwrap("PartitionNg", "zMax"),

                fields.nodes.Unwrap("PartitionNg", "nodes"),

                fields.ptr.Unwrap("PartitionNg", "ptr")

            );
        }
    }
}
