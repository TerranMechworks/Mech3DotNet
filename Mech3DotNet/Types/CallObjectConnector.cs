using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CallObjectConnector
    {
        public static readonly TypeConverter<CallObjectConnector> Converter = new TypeConverter<CallObjectConnector>(Deserialize, Serialize);
        public string node;
        public string fromNode;
        public string toNode;
        public Mech3DotNet.Types.Types.Vec3 toPos;

        public CallObjectConnector(string node, string fromNode, string toNode, Mech3DotNet.Types.Types.Vec3 toPos)
        {
            this.node = node;
            this.fromNode = fromNode;
            this.toNode = toNode;
            this.toPos = toPos;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<string> fromNode;
            public Field<string> toNode;
            public Field<Mech3DotNet.Types.Types.Vec3> toPos;
        }

        public static void Serialize(CallObjectConnector v, Serializer s)
        {
            s.SerializeStruct("CallObjectConnector", 4);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("from_node");
            ((Action<string>)s.SerializeString)(v.fromNode);
            s.SerializeFieldName("to_node");
            ((Action<string>)s.SerializeString)(v.toNode);
            s.SerializeFieldName("to_pos");
            s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(v.toPos);
        }

        public static CallObjectConnector Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                fromNode = new Field<string>(),
                toNode = new Field<string>(),
                toPos = new Field<Mech3DotNet.Types.Types.Vec3>(),
            };
            foreach (var fieldName in d.DeserializeStruct("CallObjectConnector"))
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "from_node":
                        fields.fromNode.Value = d.DeserializeString();
                        break;
                    case "to_node":
                        fields.toNode.Value = d.DeserializeString();
                        break;
                    case "to_pos":
                        fields.toPos.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("CallObjectConnector", fieldName);
                }
            }
            return new CallObjectConnector(

                fields.node.Unwrap("CallObjectConnector", "node"),

                fields.fromNode.Unwrap("CallObjectConnector", "fromNode"),

                fields.toNode.Unwrap("CallObjectConnector", "toNode"),

                fields.toPos.Unwrap("CallObjectConnector", "toPos")

            );
        }
    }
}
