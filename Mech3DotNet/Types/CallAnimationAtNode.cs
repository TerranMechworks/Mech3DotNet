using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CallAnimationAtNode
    {
        public static readonly TypeConverter<CallAnimationAtNode> Converter = new TypeConverter<CallAnimationAtNode>(Deserialize, Serialize);
        public string node;
        public Mech3DotNet.Types.Types.Vec3? translation;
        public Mech3DotNet.Types.Types.Vec3? rotation;

        public CallAnimationAtNode(string node, Mech3DotNet.Types.Types.Vec3? translation, Mech3DotNet.Types.Types.Vec3? rotation)
        {
            this.node = node;
            this.translation = translation;
            this.rotation = rotation;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<Mech3DotNet.Types.Types.Vec3?> translation;
            public Field<Mech3DotNet.Types.Types.Vec3?> rotation;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.CallAnimationAtNode v, Serializer s)
        {
            s.SerializeStruct("CallAnimationAtNode", 3);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("translation");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.Vec3.Converter))(v.translation);
            s.SerializeFieldName("rotation");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.Vec3.Converter))(v.rotation);
        }

        public static Mech3DotNet.Types.Anim.Events.CallAnimationAtNode Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                translation = new Field<Mech3DotNet.Types.Types.Vec3?>(),
                rotation = new Field<Mech3DotNet.Types.Types.Vec3?>(),
            };
            foreach (var fieldName in d.DeserializeStruct("CallAnimationAtNode"))
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "translation":
                        fields.translation.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.Vec3.Converter))();
                        break;
                    case "rotation":
                        fields.rotation.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.Vec3.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("CallAnimationAtNode", fieldName);
                }
            }
            return new CallAnimationAtNode(

                fields.node.Unwrap("CallAnimationAtNode", "node"),

                fields.translation.Unwrap("CallAnimationAtNode", "translation"),

                fields.rotation.Unwrap("CallAnimationAtNode", "rotation")

            );
        }
    }
}
