using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Sound
    {
        public static readonly TypeConverter<Sound> Converter = new TypeConverter<Sound>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Anim.Events.AtNode atNode;

        public Sound(string name, Mech3DotNet.Types.Anim.Events.AtNode atNode)
        {
            this.name = name;
            this.atNode = atNode;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Anim.Events.AtNode> atNode;
        }

        public static void Serialize(Sound v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("at_node");
            s.Serialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter)(v.atNode);
        }

        public static Sound Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                atNode = new Field<Mech3DotNet.Types.Anim.Events.AtNode>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "at_node":
                        fields.atNode.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("Sound", fieldName);
                }
            }
            return new Sound(

                fields.name.Unwrap("Sound", "name"),

                fields.atNode.Unwrap("Sound", "atNode")

            );
        }
    }
}
