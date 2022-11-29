using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public struct RandomWeightCond
    {
        public float value;

        public RandomWeightCond(float value)
        {
            this.value = value;
        }
    }

    public static class RandomWeightCondConverter
    {
        public static readonly TypeConverter<RandomWeightCond> Converter = new TypeConverter<RandomWeightCond>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<float> value;
        }

        public static void Serialize(RandomWeightCond v, Serializer s)
        {
            s.SerializeStruct("RandomWeightCond", 1);
            s.SerializeFieldName("value");
            ((Action<float>)s.SerializeF32)(v.value);
        }

        public static RandomWeightCond Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                value = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct("RandomWeightCond"))
            {
                switch (fieldName)
                {
                    case "value":
                        fields.value.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("RandomWeightCond", fieldName);
                }
            }
            return new RandomWeightCond(

                fields.value.Unwrap("RandomWeightCond", "value")

            );
        }
    }
}
