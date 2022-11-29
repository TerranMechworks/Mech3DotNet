using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class SoundNode
    {
        public static readonly TypeConverter<SoundNode> Converter = new TypeConverter<SoundNode>(Deserialize, Serialize);
        public string name;
        public bool activeState;
        public Mech3DotNet.Types.Anim.Events.AtNode? atNode = null;

        public SoundNode(string name, bool activeState, Mech3DotNet.Types.Anim.Events.AtNode? atNode)
        {
            this.name = name;
            this.activeState = activeState;
            this.atNode = atNode;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<bool> activeState;
            public Field<Mech3DotNet.Types.Anim.Events.AtNode?> atNode;
        }

        public static void Serialize(SoundNode v, Serializer s)
        {
            s.SerializeStruct("SoundNode", 3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("active_state");
            ((Action<bool>)s.SerializeBool)(v.activeState);
            s.SerializeFieldName("at_node");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter))(v.atNode);
        }

        public static SoundNode Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                activeState = new Field<bool>(),
                atNode = new Field<Mech3DotNet.Types.Anim.Events.AtNode?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct("SoundNode"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "active_state":
                        fields.activeState.Value = d.DeserializeBool();
                        break;
                    case "at_node":
                        fields.atNode.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("SoundNode", fieldName);
                }
            }
            return new SoundNode(

                fields.name.Unwrap("SoundNode", "name"),

                fields.activeState.Unwrap("SoundNode", "activeState"),

                fields.atNode.Unwrap("SoundNode", "atNode")

            );
        }
    }
}
