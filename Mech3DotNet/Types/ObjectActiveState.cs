using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectActiveState
    {
        public static readonly TypeConverter<ObjectActiveState> Converter = new TypeConverter<ObjectActiveState>(Deserialize, Serialize);
        public string node;
        public bool state;

        public ObjectActiveState(string node, bool state)
        {
            this.node = node;
            this.state = state;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<bool> state;
        }

        public static void Serialize(ObjectActiveState v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("state");
            ((Action<bool>)s.SerializeBool)(v.state);
        }

        public static ObjectActiveState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                state = new Field<bool>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "state":
                        fields.state.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectActiveState", fieldName);
                }
            }
            return new ObjectActiveState(

                fields.node.Unwrap("ObjectActiveState", "node"),

                fields.state.Unwrap("ObjectActiveState", "state")

            );
        }
    }
}
