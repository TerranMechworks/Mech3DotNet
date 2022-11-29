using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public sealed class SeqActivation
    {
        public static readonly TypeConverter<SeqActivation> Converter = new TypeConverter<SeqActivation>(Deserialize, Serialize);

        public enum Variants
        {
            Initial,
            OnCall,
        }

        private SeqActivation(Variants variant)
        {
            Variant = variant;
        }
        public static readonly SeqActivation Initial = new SeqActivation(Variants.Initial);

        public static readonly SeqActivation OnCall = new SeqActivation(Variants.OnCall);

        public Variants Variant { get; private set; }
        public bool IsInitial() => Variant == Variants.Initial;
        public bool IsOnCall() => Variant == Variants.OnCall;
        public override bool Equals(object obj) => Equals(obj as SeqActivation);
        public bool Equals(SeqActivation? other) => other != null && Variant == other.Variant;
        public override int GetHashCode() => System.HashCode.Combine(Variant);

        private static void Serialize(SeqActivation v, Serializer s)
        {
            uint variantIndex = v.Variant switch
            {
                Variants.Initial => 0,
                Variants.OnCall => 1,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static SeqActivation Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("SeqActivation");
            return variantIndex switch
            {
                0 => SeqActivation.Initial,
                1 => SeqActivation.OnCall,
                _ => throw new UnknownVariantException("SeqActivation", variantIndex),
            };
        }
    }
}
