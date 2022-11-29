using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class FogType
    {
        public static readonly TypeConverter<FogType> Converter = new TypeConverter<FogType>(Deserialize, Serialize);

        public enum Variants
        {
            Off,
            Linear,
            Exponential,
        }

        private FogType(Variants variant)
        {
            Variant = variant;
        }
        public static readonly FogType Off = new FogType(Variants.Off);

        public static readonly FogType Linear = new FogType(Variants.Linear);

        public static readonly FogType Exponential = new FogType(Variants.Exponential);

        public Variants Variant { get; private set; }
        public bool IsOff() => Variant == Variants.Off;
        public bool IsLinear() => Variant == Variants.Linear;
        public bool IsExponential() => Variant == Variants.Exponential;
        public override bool Equals(object obj) => Equals(obj as FogType);
        public bool Equals(FogType? other) => other != null && Variant == other.Variant;
        public override int GetHashCode() => System.HashCode.Combine(Variant);

        private static void Serialize(FogType v, Serializer s)
        {
            uint variantIndex = v.Variant switch
            {
                Variants.Off => 0,
                Variants.Linear => 1,
                Variants.Exponential => 2,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static FogType Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("FogType");
            return variantIndex switch
            {
                0 => FogType.Off,
                1 => FogType.Linear,
                2 => FogType.Exponential,
                _ => throw new UnknownVariantException("FogType", variantIndex),
            };
        }
    }
}
