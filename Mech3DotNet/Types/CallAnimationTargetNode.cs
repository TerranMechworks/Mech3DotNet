using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CallAnimationTargetNode
    {
        public static readonly TypeConverter<CallAnimationTargetNode> Converter = new TypeConverter<CallAnimationTargetNode>(Deserialize, Serialize);
        public string operandNode;

        public CallAnimationTargetNode(string operandNode)
        {
            this.operandNode = operandNode;
        }

        private struct Fields
        {
            public Field<string> operandNode;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.CallAnimationTargetNode v, Serializer s)
        {
            s.SerializeStruct("CallAnimationTargetNode", 1);
            s.SerializeFieldName("operand_node");
            ((Action<string>)s.SerializeString)(v.operandNode);
        }

        public static Mech3DotNet.Types.Anim.Events.CallAnimationTargetNode Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                operandNode = new Field<string>(),
            };
            foreach (var fieldName in d.DeserializeStruct("CallAnimationTargetNode"))
            {
                switch (fieldName)
                {
                    case "operand_node":
                        fields.operandNode.Value = d.DeserializeString();
                        break;
                    default:
                        throw new UnknownFieldException("CallAnimationTargetNode", fieldName);
                }
            }
            return new CallAnimationTargetNode(

                fields.operandNode.Unwrap("CallAnimationTargetNode", "operandNode")

            );
        }
    }
}
