using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes
{
    public sealed class PartitionValue
    {
        public static readonly TypeConverter<PartitionValue> Converter = new TypeConverter<PartitionValue>(Deserialize, Serialize);
        public uint index;
        public float zMin;
        public float zMax;

        public PartitionValue(uint index, float zMin, float zMax)
        {
            this.index = index;
            this.zMin = zMin;
            this.zMax = zMax;
        }

        private struct Fields
        {
            public Field<uint> index;
            public Field<float> zMin;
            public Field<float> zMax;
        }

        public static void Serialize(PartitionValue v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("index");
            ((Action<uint>)s.SerializeU32)(v.index);
            s.SerializeFieldName("z_min");
            ((Action<float>)s.SerializeF32)(v.zMin);
            s.SerializeFieldName("z_max");
            ((Action<float>)s.SerializeF32)(v.zMax);
        }

        public static PartitionValue Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                index = new Field<uint>(),
                zMin = new Field<float>(),
                zMax = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "index":
                        fields.index.Value = d.DeserializeU32();
                        break;
                    case "z_min":
                        fields.zMin.Value = d.DeserializeF32();
                        break;
                    case "z_max":
                        fields.zMax.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("PartitionValue", fieldName);
                }
            }
            return new PartitionValue(

                fields.index.Unwrap("PartitionValue", "index"),

                fields.zMin.Unwrap("PartitionValue", "zMin"),

                fields.zMax.Unwrap("PartitionValue", "zMax")

            );
        }
    }
}
