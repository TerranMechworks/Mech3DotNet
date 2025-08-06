using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class FloatFromTo
    {
        public float from;
        public float to;

        public FloatFromTo(float from, float to)
        {
            this.from = from;
            this.to = to;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<FloatFromTo> Converter = new TypeConverter<FloatFromTo>(Deserialize, Serialize);

        public static void Serialize(FloatFromTo v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("from");
            ((Action<float>)s.SerializeF32)(v.from);
            s.SerializeFieldName("to");
            ((Action<float>)s.SerializeF32)(v.to);
        }

        private struct Fields
        {
            public Field<float> from;
            public Field<float> to;
        }

        public static FloatFromTo Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                from = new Field<float>(),
                to = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "from":
                        fields.from.Value = d.DeserializeF32();
                        break;
                    case "to":
                        fields.to.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("FloatFromTo", fieldName);
                }
            }
            return new FloatFromTo(

                fields.from.Unwrap("FloatFromTo", "from"),

                fields.to.Unwrap("FloatFromTo", "to")

            );
        }

        #endregion
    }
}
