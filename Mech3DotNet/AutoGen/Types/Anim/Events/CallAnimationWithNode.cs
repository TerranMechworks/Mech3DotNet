using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CallAnimationWithNode
    {
        public string node;
        public Mech3DotNet.Types.Common.Vec3? position;

        public CallAnimationWithNode(string node, Mech3DotNet.Types.Common.Vec3? position)
        {
            this.node = node;
            this.position = position;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<CallAnimationWithNode> Converter = new TypeConverter<CallAnimationWithNode>(Deserialize, Serialize);

        public static void Serialize(CallAnimationWithNode v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("position");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.position);
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<Mech3DotNet.Types.Common.Vec3?> position;
        }

        public static CallAnimationWithNode Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                position = new Field<Mech3DotNet.Types.Common.Vec3?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "position":
                        fields.position.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("CallAnimationWithNode", fieldName);
                }
            }
            return new CallAnimationWithNode(

                fields.node.Unwrap("CallAnimationWithNode", "node"),

                fields.position.Unwrap("CallAnimationWithNode", "position")

            );
        }

        #endregion
    }
}
