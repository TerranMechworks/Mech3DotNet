using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectOpacity
    {
        public static readonly TypeConverter<ObjectOpacity> Converter = new TypeConverter<ObjectOpacity>(Deserialize, Serialize);
        public float opacity;
        public bool? state;

        public ObjectOpacity(float opacity, bool? state)
        {
            this.opacity = opacity;
            this.state = state;
        }

        private struct Fields
        {
            public Field<float> opacity;
            public Field<bool?> state;
        }

        public static void Serialize(ObjectOpacity v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("opacity");
            ((Action<float>)s.SerializeF32)(v.opacity);
            s.SerializeFieldName("state");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.state);
        }

        public static ObjectOpacity Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                opacity = new Field<float>(),
                state = new Field<bool?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "opacity":
                        fields.opacity.Value = d.DeserializeF32();
                        break;
                    case "state":
                        fields.state.Value = d.DeserializeValOption(d.DeserializeBool)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectOpacity", fieldName);
                }
            }
            return new ObjectOpacity(

                fields.opacity.Unwrap("ObjectOpacity", "opacity"),

                fields.state.Unwrap("ObjectOpacity", "state")

            );
        }
    }
}
