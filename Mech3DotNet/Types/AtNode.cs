using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class AtNode
    {
        public static readonly TypeConverter<AtNode> Converter = new TypeConverter<AtNode>(Deserialize, Serialize);
        public string node;
        public Mech3DotNet.Types.Types.Vec3 translation;

        public AtNode(string node, Mech3DotNet.Types.Types.Vec3 translation)
        {
            this.node = node;
            this.translation = translation;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<Mech3DotNet.Types.Types.Vec3> translation;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.AtNode v, Serializer s)
        {
            s.SerializeStruct("AtNode", 2);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("translation");
            s.Serialize(Mech3DotNet.Types.Types.Vec3.Converter)(v.translation);
        }

        public static Mech3DotNet.Types.Anim.Events.AtNode Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                translation = new Field<Mech3DotNet.Types.Types.Vec3>(),
            };
            foreach (var fieldName in d.DeserializeStruct("AtNode"))
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "translation":
                        fields.translation.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("AtNode", fieldName);
                }
            }
            return new AtNode(

                fields.node.Unwrap("AtNode", "node"),

                fields.translation.Unwrap("AtNode", "translation")

            );
        }
    }
}
