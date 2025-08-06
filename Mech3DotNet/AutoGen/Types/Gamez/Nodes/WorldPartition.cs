using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class WorldPartition
    {
        public int x;
        public int z;
        public Mech3DotNet.Types.Common.Vec3 min;
        public Mech3DotNet.Types.Common.Vec3 max;
        public System.Collections.Generic.List<short> nodeIndices;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.WorldPartitionValue> values;
        public uint nodesPtr;

        public WorldPartition(int x, int z, Mech3DotNet.Types.Common.Vec3 min, Mech3DotNet.Types.Common.Vec3 max, System.Collections.Generic.List<short> nodeIndices, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.WorldPartitionValue> values, uint nodesPtr)
        {
            this.x = x;
            this.z = z;
            this.min = min;
            this.max = max;
            this.nodeIndices = nodeIndices;
            this.values = values;
            this.nodesPtr = nodesPtr;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<WorldPartition> Converter = new TypeConverter<WorldPartition>(Deserialize, Serialize);

        public static void Serialize(WorldPartition v, Serializer s)
        {
            s.SerializeStruct(7);
            s.SerializeFieldName("x");
            ((Action<int>)s.SerializeI32)(v.x);
            s.SerializeFieldName("z");
            ((Action<int>)s.SerializeI32)(v.z);
            s.SerializeFieldName("min");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.min);
            s.SerializeFieldName("max");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.max);
            s.SerializeFieldName("node_indices");
            s.SerializeVec(((Action<short>)s.SerializeI16))(v.nodeIndices);
            s.SerializeFieldName("values");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Nodes.WorldPartitionValue.Converter))(v.values);
            s.SerializeFieldName("nodes_ptr");
            ((Action<uint>)s.SerializeU32)(v.nodesPtr);
        }

        private struct Fields
        {
            public Field<int> x;
            public Field<int> z;
            public Field<Mech3DotNet.Types.Common.Vec3> min;
            public Field<Mech3DotNet.Types.Common.Vec3> max;
            public Field<System.Collections.Generic.List<short>> nodeIndices;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.WorldPartitionValue>> values;
            public Field<uint> nodesPtr;
        }

        public static WorldPartition Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                x = new Field<int>(),
                z = new Field<int>(),
                min = new Field<Mech3DotNet.Types.Common.Vec3>(),
                max = new Field<Mech3DotNet.Types.Common.Vec3>(),
                nodeIndices = new Field<System.Collections.Generic.List<short>>(),
                values = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.WorldPartitionValue>>(),
                nodesPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "x":
                        fields.x.Value = d.DeserializeI32();
                        break;
                    case "z":
                        fields.z.Value = d.DeserializeI32();
                        break;
                    case "min":
                        fields.min.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "max":
                        fields.max.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "node_indices":
                        fields.nodeIndices.Value = d.DeserializeVec(d.DeserializeI16)();
                        break;
                    case "values":
                        fields.values.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.WorldPartitionValue.Converter))();
                        break;
                    case "nodes_ptr":
                        fields.nodesPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("WorldPartition", fieldName);
                }
            }
            return new WorldPartition(

                fields.x.Unwrap("WorldPartition", "x"),

                fields.z.Unwrap("WorldPartition", "z"),

                fields.min.Unwrap("WorldPartition", "min"),

                fields.max.Unwrap("WorldPartition", "max"),

                fields.nodeIndices.Unwrap("WorldPartition", "nodeIndices"),

                fields.values.Unwrap("WorldPartition", "values"),

                fields.nodesPtr.Unwrap("WorldPartition", "nodesPtr")

            );
        }

        #endregion
    }
}
