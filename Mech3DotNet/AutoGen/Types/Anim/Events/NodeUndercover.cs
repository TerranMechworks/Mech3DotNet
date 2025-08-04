using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class NodeUndercover
    {
        public static readonly TypeConverter<NodeUndercover> Converter = new TypeConverter<NodeUndercover>(Deserialize, Serialize);
        public uint nodeIndex;
        public uint distance;

        public NodeUndercover(uint nodeIndex, uint distance)
        {
            this.nodeIndex = nodeIndex;
            this.distance = distance;
        }

        private struct Fields
        {
            public Field<uint> nodeIndex;
            public Field<uint> distance;
        }

        public static void Serialize(NodeUndercover v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("node_index");
            ((Action<uint>)s.SerializeU32)(v.nodeIndex);
            s.SerializeFieldName("distance");
            ((Action<uint>)s.SerializeU32)(v.distance);
        }

        public static NodeUndercover Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                nodeIndex = new Field<uint>(),
                distance = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "node_index":
                        fields.nodeIndex.Value = d.DeserializeU32();
                        break;
                    case "distance":
                        fields.distance.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("NodeUndercover", fieldName);
                }
            }
            return new NodeUndercover(

                fields.nodeIndex.Unwrap("NodeUndercover", "nodeIndex"),

                fields.distance.Unwrap("NodeUndercover", "distance")

            );
        }
    }
}
