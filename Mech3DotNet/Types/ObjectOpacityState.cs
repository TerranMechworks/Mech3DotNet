using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectOpacityState
    {
        public static readonly TypeConverter<ObjectOpacityState> Converter = new TypeConverter<ObjectOpacityState>(Deserialize, Serialize);
        public string node;
        public bool isSet;
        public bool state;
        public float opacity;

        public ObjectOpacityState(string node, bool isSet, bool state, float opacity)
        {
            this.node = node;
            this.isSet = isSet;
            this.state = state;
            this.opacity = opacity;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<bool> isSet;
            public Field<bool> state;
            public Field<float> opacity;
        }

        public static void Serialize(ObjectOpacityState v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("is_set");
            ((Action<bool>)s.SerializeBool)(v.isSet);
            s.SerializeFieldName("state");
            ((Action<bool>)s.SerializeBool)(v.state);
            s.SerializeFieldName("opacity");
            ((Action<float>)s.SerializeF32)(v.opacity);
        }

        public static ObjectOpacityState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                isSet = new Field<bool>(),
                state = new Field<bool>(),
                opacity = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "is_set":
                        fields.isSet.Value = d.DeserializeBool();
                        break;
                    case "state":
                        fields.state.Value = d.DeserializeBool();
                        break;
                    case "opacity":
                        fields.opacity.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectOpacityState", fieldName);
                }
            }
            return new ObjectOpacityState(

                fields.node.Unwrap("ObjectOpacityState", "node"),

                fields.isSet.Unwrap("ObjectOpacityState", "isSet"),

                fields.state.Unwrap("ObjectOpacityState", "state"),

                fields.opacity.Unwrap("ObjectOpacityState", "opacity")

            );
        }
    }
}
