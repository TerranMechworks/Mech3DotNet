using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Types
{
    public struct Range
    {
        public static readonly TypeConverter<Range> Converter = new TypeConverter<Range>(Deserialize, Serialize);
        public float min;
        public float max;

        public Range(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        private struct Fields
        {
            public Field<float> min;
            public Field<float> max;
        }

        public static void Serialize(Mech3DotNet.Types.Types.Range v, Serializer s)
        {
            s.SerializeStruct("Range", 2);
            s.SerializeFieldName("min");
            ((Action<float>)s.SerializeF32)(v.min);
            s.SerializeFieldName("max");
            ((Action<float>)s.SerializeF32)(v.max);
        }

        public static Mech3DotNet.Types.Types.Range Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                min = new Field<float>(),
                max = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct("Range"))
            {
                switch (fieldName)
                {
                    case "min":
                        fields.min.Value = d.DeserializeF32();
                        break;
                    case "max":
                        fields.max.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("Range", fieldName);
                }
            }
            return new Range(

                fields.min.Unwrap("Range", "min"),

                fields.max.Unwrap("Range", "max")

            );
        }
    }
}
