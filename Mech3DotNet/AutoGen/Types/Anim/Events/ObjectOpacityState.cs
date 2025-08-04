using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectOpacityState
    {
        public static readonly TypeConverter<ObjectOpacityState> Converter = new TypeConverter<ObjectOpacityState>(Deserialize, Serialize);
        public string name;
        public bool state;
        public float? opacity;

        public ObjectOpacityState(string name, bool state, float? opacity)
        {
            this.name = name;
            this.state = state;
            this.opacity = opacity;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<bool> state;
            public Field<float?> opacity;
        }

        public static void Serialize(ObjectOpacityState v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("state");
            ((Action<bool>)s.SerializeBool)(v.state);
            s.SerializeFieldName("opacity");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.opacity);
        }

        public static ObjectOpacityState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                state = new Field<bool>(),
                opacity = new Field<float?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "state":
                        fields.state.Value = d.DeserializeBool();
                        break;
                    case "opacity":
                        fields.opacity.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectOpacityState", fieldName);
                }
            }
            return new ObjectOpacityState(

                fields.name.Unwrap("ObjectOpacityState", "name"),

                fields.state.Unwrap("ObjectOpacityState", "state"),

                fields.opacity.Unwrap("ObjectOpacityState", "opacity")

            );
        }
    }
}
