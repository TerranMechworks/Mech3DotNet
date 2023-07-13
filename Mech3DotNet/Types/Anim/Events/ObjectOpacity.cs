using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public struct ObjectOpacity
    {
        public float value;
        public short state;

        public ObjectOpacity(float value, short state)
        {
            this.value = value;
            this.state = state;
        }
    }

    public static class ObjectOpacityConverter
    {
        public static readonly TypeConverter<ObjectOpacity> Converter = new TypeConverter<ObjectOpacity>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<float> value;
            public Field<short> state;
        }

        public static void Serialize(ObjectOpacity v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("value");
            ((Action<float>)s.SerializeF32)(v.value);
            s.SerializeFieldName("state");
            ((Action<short>)s.SerializeI16)(v.state);
        }

        public static ObjectOpacity Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                value = new Field<float>(),
                state = new Field<short>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "value":
                        fields.value.Value = d.DeserializeF32();
                        break;
                    case "state":
                        fields.state.Value = d.DeserializeI16();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectOpacity", fieldName);
                }
            }
            return new ObjectOpacity(

                fields.value.Unwrap("ObjectOpacity", "value"),

                fields.state.Unwrap("ObjectOpacity", "state")

            );
        }
    }
}
