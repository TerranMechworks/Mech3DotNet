using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class SoundNode
    {
        public static readonly TypeConverter<SoundNode> Converter = new TypeConverter<SoundNode>(Deserialize, Serialize);
        public string name;
        public bool activeState;
        public Mech3DotNet.Types.Anim.Events.Translate? translate;

        public SoundNode(string name, bool activeState, Mech3DotNet.Types.Anim.Events.Translate? translate)
        {
            this.name = name;
            this.activeState = activeState;
            this.translate = translate;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<bool> activeState;
            public Field<Mech3DotNet.Types.Anim.Events.Translate?> translate;
        }

        public static void Serialize(SoundNode v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("active_state");
            ((Action<bool>)s.SerializeBool)(v.activeState);
            s.SerializeFieldName("translate");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.Translate.Converter))(v.translate);
        }

        public static SoundNode Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                activeState = new Field<bool>(),
                translate = new Field<Mech3DotNet.Types.Anim.Events.Translate?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "active_state":
                        fields.activeState.Value = d.DeserializeBool();
                        break;
                    case "translate":
                        fields.translate.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.Translate.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("SoundNode", fieldName);
                }
            }
            return new SoundNode(

                fields.name.Unwrap("SoundNode", "name"),

                fields.activeState.Unwrap("SoundNode", "activeState"),

                fields.translate.Unwrap("SoundNode", "translate")

            );
        }
    }
}
