using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class IntervalType
    {
        public static readonly TypeConverter<IntervalType> Converter = new TypeConverter<IntervalType>(Deserialize, Serialize);

        public enum Variants
        {
            Unset,
            Time,
            Distance,
        }

        private IntervalType(Variants variant)
        {
            Variant = variant;
        }
        public static readonly IntervalType Unset = new IntervalType(Variants.Unset);

        public static readonly IntervalType Time = new IntervalType(Variants.Time);

        public static readonly IntervalType Distance = new IntervalType(Variants.Distance);

        public Variants Variant { get; private set; }
        public bool IsUnset() => Variant == Variants.Unset;
        public bool IsTime() => Variant == Variants.Time;
        public bool IsDistance() => Variant == Variants.Distance;
        public override bool Equals(object obj) => Equals(obj as IntervalType);
        public bool Equals(IntervalType? other) => other != null && Variant == other.Variant;
        public override int GetHashCode() => System.HashCode.Combine(Variant);

        private static void Serialize(IntervalType v, Serializer s)
        {
            uint variantIndex = v.Variant switch
            {
                Variants.Unset => 0,
                Variants.Time => 1,
                Variants.Distance => 2,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant("IntervalType", variantIndex);
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
