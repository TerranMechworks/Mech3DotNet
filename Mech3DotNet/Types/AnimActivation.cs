using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public sealed class AnimActivation
    {
        public static readonly TypeConverter<AnimActivation> Converter = new TypeConverter<AnimActivation>(Deserialize, Serialize);

        public enum Variants
        {
            WeaponHit,
            CollideHit,
            WeaponOrCollideHit,
            OnCall,
            OnStartup,
        }

        private AnimActivation(Variants variant)
        {
            Variant = variant;
        }
        public static readonly AnimActivation WeaponHit = new AnimActivation(Variants.WeaponHit);

        public static readonly AnimActivation CollideHit = new AnimActivation(Variants.CollideHit);

        public static readonly AnimActivation WeaponOrCollideHit = new AnimActivation(Variants.WeaponOrCollideHit);

        public static readonly AnimActivation OnCall = new AnimActivation(Variants.OnCall);

        public static readonly AnimActivation OnStartup = new AnimActivation(Variants.OnStartup);

        public Variants Variant { get; private set; }
        public bool IsWeaponHit() => Variant == Variants.WeaponHit;
        public bool IsCollideHit() => Variant == Variants.CollideHit;
        public bool IsWeaponOrCollideHit() => Variant == Variants.WeaponOrCollideHit;
        public bool IsOnCall() => Variant == Variants.OnCall;
        public bool IsOnStartup() => Variant == Variants.OnStartup;
        public override bool Equals(object obj) => Equals(obj as AnimActivation);
        public bool Equals(AnimActivation? other) => other != null && Variant == other.Variant;
        public override int GetHashCode() => System.HashCode.Combine(Variant);

        private static void Serialize(AnimActivation v, Serializer s)
        {
            uint variantIndex = v.Variant switch
            {
                Variants.WeaponHit => 0,
                Variants.CollideHit => 1,
                Variants.WeaponOrCollideHit => 2,
                Variants.OnCall => 3,
                Variants.OnStartup => 4,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static AnimActivation Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("AnimActivation");
            return variantIndex switch
            {
                0 => AnimActivation.WeaponHit,
                1 => AnimActivation.CollideHit,
                2 => AnimActivation.WeaponOrCollideHit,
                3 => AnimActivation.OnCall,
                4 => AnimActivation.OnStartup,
                _ => throw new UnknownVariantException("AnimActivation", variantIndex),
            };
        }
    }
}
