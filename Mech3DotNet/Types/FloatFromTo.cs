using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class FloatFromTo
    {
        public static readonly TypeConverter<FloatFromTo> Converter = new TypeConverter<FloatFromTo>(Deserialize, Serialize);
        public float from;
        public float to;
        public float delta;

        public FloatFromTo(float from, float to, float delta)
        {
            this.from = from;
            this.to = to;
            this.delta = delta;
        }

        private struct Fields
        {
            public Field<float> from;
            public Field<float> to;
            public Field<float> delta;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo v, Serializer s)
        {
            s.SerializeStruct("FloatFromTo", 3);
            s.SerializeFieldName("from");
            ((Action<float>)s.SerializeF32)(v.from);
            s.SerializeFieldName("to");
            ((Action<float>)s.SerializeF32)(v.to);
            s.SerializeFieldName("delta");
            ((Action<float>)s.SerializeF32)(v.delta);
        }

        public static Mech3DotNet.Types.Anim.Events.FloatFromTo Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                from = new Field<float>(),
                to = new Field<float>(),
                delta = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct("FloatFromTo"))
            {
                switch (fieldName)
                {
                    case "from":
                        fields.from.Value = d.DeserializeF32();
                        break;
                    case "to":
                        fields.to.Value = d.DeserializeF32();
                        break;
                    case "delta":
                        fields.delta.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("FloatFromTo", fieldName);
                }
            }
            return new FloatFromTo(

                fields.from.Unwrap("FloatFromTo", "from"),

                fields.to.Unwrap("FloatFromTo", "to"),

                fields.delta.Unwrap("FloatFromTo", "delta")

            );
        }
    }
}
