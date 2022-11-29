using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectTranslateState
    {
        public static readonly TypeConverter<ObjectTranslateState> Converter = new TypeConverter<ObjectTranslateState>(Deserialize, Serialize);
        public string node;
        public Mech3DotNet.Types.Types.Vec3 translate;
        public string? atNode = null;

        public ObjectTranslateState(string node, Mech3DotNet.Types.Types.Vec3 translate, string? atNode)
        {
            this.node = node;
            this.translate = translate;
            this.atNode = atNode;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<Mech3DotNet.Types.Types.Vec3> translate;
            public Field<string?> atNode;
        }

        public static void Serialize(ObjectTranslateState v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("translate");
            s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(v.translate);
            s.SerializeFieldName("at_node");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.atNode);
        }

        public static ObjectTranslateState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                translate = new Field<Mech3DotNet.Types.Types.Vec3>(),
                atNode = new Field<string?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "translate":
                        fields.translate.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
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

                fields.translate.Unwrap("ObjectTranslateState", "translate"),

                fields.atNode.Unwrap("ObjectTranslateState", "atNode")

            );
        }
    }
}
