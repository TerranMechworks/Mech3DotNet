using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CallAnimationWithNode
    {
        public static readonly TypeConverter<CallAnimationWithNode> Converter = new TypeConverter<CallAnimationWithNode>(Deserialize, Serialize);
        public string node;
        public Mech3DotNet.Types.Types.Vec3? translation;

        public CallAnimationWithNode(string node, Mech3DotNet.Types.Types.Vec3? translation)
        {
            this.node = node;
            this.translation = translation;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<Mech3DotNet.Types.Types.Vec3?> translation;
        }

        public static void Serialize(CallAnimationWithNode v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("translation");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))(v.translation);
        }

        public static CallAnimationWithNode Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                translation = new Field<Mech3DotNet.Types.Types.Vec3?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "translation":
                        fields.translation.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("CallAnimationWithNode", fieldName);
                }
            }
            return new CallAnimationWithNode(

                fields.node.Unwrap("CallAnimationWithNode", "node"),

                fields.translation.Unwrap("CallAnimationWithNode", "translation")

            );
        }
    }
}
