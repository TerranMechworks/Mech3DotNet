using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public enum IntervalType
    {
        Unset,
        Time,
        Distance,
    }

    public static class IntervalTypeConverter
    {
        public static readonly TypeConverter<IntervalType> Converter = new TypeConverter<IntervalType>(Deserialize, Serialize);

        private static void Serialize(IntervalType v, Serializer s)
        {
            uint variantIndex = v switch
            {
                IntervalType.Unset => 0,
                IntervalType.Time => 1,
                IntervalType.Distance => 2,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static IntervalType Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("IntervalType");
            return variantIndex switch
            {
                0 => IntervalType.Unset,
                1 => IntervalType.Time,
                2 => IntervalType.Distance,
                _ => throw new UnknownVariantException("IntervalType", variantIndex),
            };
        }
    }
}
