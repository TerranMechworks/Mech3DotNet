using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CallAnimationAtNode
    {
        public static readonly TypeConverter<CallAnimationAtNode> Converter = new TypeConverter<CallAnimationAtNode>(Deserialize, Serialize);
        public string node;
        public Mech3DotNet.Types.Common.Vec3? position;
        public Mech3DotNet.Types.Common.Vec3? translate;

        public CallAnimationAtNode(string node, Mech3DotNet.Types.Common.Vec3? position, Mech3DotNet.Types.Common.Vec3? translate)
        {
            this.node = node;
            this.position = position;
            this.translate = translate;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<Mech3DotNet.Types.Common.Vec3?> position;
            public Field<Mech3DotNet.Types.Common.Vec3?> translate;
        }

        public static void Serialize(CallAnimationAtNode v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("position");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.position);
            s.SerializeFieldName("translate");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.translate);
        }

        public static CallAnimationAtNode Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                position = new Field<Mech3DotNet.Types.Common.Vec3?>(),
                translate = new Field<Mech3DotNet.Types.Common.Vec3?>(),
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
                    case "translate":
                        fields.translate.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("CallAnimationAtNode", fieldName);
                }
            }
            return new CallAnimationAtNode(

                fields.node.Unwrap("CallAnimationAtNode", "node"),

                fields.position.Unwrap("CallAnimationAtNode", "position"),

                fields.translate.Unwrap("CallAnimationAtNode", "translate")

            );
        }
    }
}
