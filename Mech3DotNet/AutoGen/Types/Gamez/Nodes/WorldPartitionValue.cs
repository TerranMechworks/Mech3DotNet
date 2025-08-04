using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class WorldPartitionValue
    {
        public static readonly TypeConverter<WorldPartitionValue> Converter = new TypeConverter<WorldPartitionValue>(Deserialize, Serialize);
        public short nodeIndex;
        public float yMin;
        public float yMax;

        public WorldPartitionValue(short nodeIndex, float yMin, float yMax)
        {
            this.nodeIndex = nodeIndex;
            this.yMin = yMin;
            this.yMax = yMax;
        }

        private struct Fields
        {
            public Field<short> nodeIndex;
            public Field<float> yMin;
            public Field<float> yMax;
        }

        public static void Serialize(WorldPartitionValue v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("node_index");
            ((Action<short>)s.SerializeI16)(v.nodeIndex);
            s.SerializeFieldName("y_min");
            ((Action<float>)s.SerializeF32)(v.yMin);
            s.SerializeFieldName("y_max");
            ((Action<float>)s.SerializeF32)(v.yMax);
        }

        public static WorldPartitionValue Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                nodeIndex = new Field<short>(),
                yMin = new Field<float>(),
                yMax = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "node_index":
                        fields.nodeIndex.Value = d.DeserializeI16();
                        break;
                    case "y_min":
                        fields.yMin.Value = d.DeserializeF32();
                        break;
                    case "y_max":
                        fields.yMax.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("WorldPartitionValue", fieldName);
                }
            }
            return new WorldPartitionValue(

                fields.nodeIndex.Unwrap("WorldPartitionValue", "nodeIndex"),

                fields.yMin.Unwrap("WorldPartitionValue", "yMin"),

                fields.yMax.Unwrap("WorldPartitionValue", "yMax")

            );
        }
    }
}
