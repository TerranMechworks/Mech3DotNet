using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class GravityMode
    {
        public static readonly TypeConverter<GravityMode> Converter = new TypeConverter<GravityMode>(Deserialize, Serialize);

        public enum Variants
        {
            Local,
            Complex,
            NoAltitude,
        }

        private GravityMode(Variants variant)
        {
            Variant = variant;
        }
        public static readonly GravityMode Local = new GravityMode(Variants.Local);

        public static readonly GravityMode Complex = new GravityMode(Variants.Complex);

        public static readonly GravityMode NoAltitude = new GravityMode(Variants.NoAltitude);

        public Variants Variant { get; private set; }
        public bool IsLocal() => Variant == Variants.Local;
        public bool IsComplex() => Variant == Variants.Complex;
        public bool IsNoAltitude() => Variant == Variants.NoAltitude;
        public override bool Equals(object obj) => Equals(obj as GravityMode);
        public bool Equals(GravityMode? other) => other != null && Variant == other.Variant;
        public override int GetHashCode() => System.HashCode.Combine(Variant);

        private static void Serialize(GravityMode v, Serializer s)
        {
            uint variantIndex = v.Variant switch
            {
                Variants.Local => 0,
                Variants.Complex => 1,
                Variants.NoAltitude => 2,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant("GravityMode", variantIndex);
        }

        private static GravityMode Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("GravityMode");
            return variantIndex switch
            {
                0 => GravityMode.Local,
                1 => GravityMode.Complex,
                2 => GravityMode.NoAltitude,
                _ => throw new UnknownVariantException("GravityMode", variantIndex),
            };
        }
    }
}
