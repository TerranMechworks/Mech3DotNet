using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes
{
    public sealed class Partition
    {
        public static readonly TypeConverter<Partition> Converter = new TypeConverter<Partition>(Deserialize, Serialize);
        public int x;
        public int y;
        public float zMin;
        public float zMax;
        public float zMid;
        public System.Collections.Generic.List<uint> nodes;
        public uint ptr;

        public Partition(int x, int y, float zMin, float zMax, float zMid, System.Collections.Generic.List<uint> nodes, uint ptr)
        {
            this.x = x;
            this.y = y;
            this.zMin = zMin;
            this.zMax = zMax;
            this.zMid = zMid;
            this.nodes = nodes;
            this.ptr = ptr;
        }

        private struct Fields
        {
            public Field<int> x;
            public Field<int> y;
            public Field<float> zMin;
            public Field<float> zMax;
            public Field<float> zMid;
            public Field<System.Collections.Generic.List<uint>> nodes;
            public Field<uint> ptr;
        }

        public static void Serialize(Partition v, Serializer s)
        {
            s.SerializeStruct("Partition", 7);
            s.SerializeFieldName("x");
            ((Action<int>)s.SerializeI32)(v.x);
            s.SerializeFieldName("y");
            ((Action<int>)s.SerializeI32)(v.y);
            s.SerializeFieldName("z_min");
            ((Action<float>)s.SerializeF32)(v.zMin);
            s.SerializeFieldName("z_max");
            ((Action<float>)s.SerializeF32)(v.zMax);
            s.SerializeFieldName("z_mid");
            ((Action<float>)s.SerializeF32)(v.zMid);
            s.SerializeFieldName("nodes");
            s.SerializeVec(((Action<uint>)s.SerializeU32))(v.nodes);
            s.SerializeFieldName("ptr");
            ((Action<uint>)s.SerializeU32)(v.ptr);
        }

        public static Partition Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                x = new Field<int>(),
                y = new Field<int>(),
                zMin = new Field<float>(),
                zMax = new Field<float>(),
                zMid = new Field<float>(),
                nodes = new Field<System.Collections.Generic.List<uint>>(),
                ptr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("Partition"))
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
                    case "z_mid":
                        fields.zMid.Value = d.DeserializeF32();
                        break;
                    case "nodes":
                        fields.nodes.Value = d.DeserializeVec(d.DeserializeU32)();
                        break;
                    case "ptr":
                        fields.ptr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Partition", fieldName);
                }
            }
            return new Partition(

                fields.x.Unwrap("Partition", "x"),

                fields.y.Unwrap("Partition", "y"),

                fields.zMin.Unwrap("Partition", "zMin"),

                fields.zMax.Unwrap("Partition", "zMax"),

                fields.zMid.Unwrap("Partition", "zMid"),

                fields.nodes.Unwrap("Partition", "nodes"),

                fields.ptr.Unwrap("Partition", "ptr")

            );
        }
    }
}
