using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectTranslateState
    {
        public static readonly TypeConverter<ObjectTranslateState> Converter = new TypeConverter<ObjectTranslateState>(Deserialize, Serialize);
        public string node;
        public bool relative;
        public Mech3DotNet.Types.Common.Vec3 state;
        public string? atNode;

        public ObjectTranslateState(string node, bool relative, Mech3DotNet.Types.Common.Vec3 state, string? atNode)
        {
            this.node = node;
            this.relative = relative;
            this.state = state;
            this.atNode = atNode;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<bool> relative;
            public Field<Mech3DotNet.Types.Common.Vec3> state;
            public Field<string?> atNode;
        }

        public static void Serialize(ObjectTranslateState v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("relative");
            ((Action<bool>)s.SerializeBool)(v.relative);
            s.SerializeFieldName("state");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.state);
            s.SerializeFieldName("at_node");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.atNode);
        }

        public static ObjectTranslateState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                relative = new Field<bool>(),
                state = new Field<Mech3DotNet.Types.Common.Vec3>(),
                atNode = new Field<string?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "relative":
                        fields.relative.Value = d.DeserializeBool();
                        break;
                    case "state":
                        fields.state.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "at_node":
                        fields.atNode.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectTranslateState", fieldName);
                }
            }
            return new ObjectTranslateState(

                fields.node.Unwrap("ObjectTranslateState", "node"),

                fields.relative.Unwrap("ObjectTranslateState", "relative"),

                fields.state.Unwrap("ObjectTranslateState", "state"),

                fields.atNode.Unwrap("ObjectTranslateState", "atNode")

            );
        }
    }
}
