using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class StartOffset
    {
        public static readonly TypeConverter<StartOffset> Converter = new TypeConverter<StartOffset>(Deserialize, Serialize);

        public enum Variants
        {
            Animation,
            Sequence,
            Event,
        }

        private StartOffset(Variants variant)
        {
            Variant = variant;
        }
        public static readonly StartOffset Animation = new StartOffset(Variants.Animation);

        public static readonly StartOffset Sequence = new StartOffset(Variants.Sequence);

        public static readonly StartOffset Event = new StartOffset(Variants.Event);

        public Variants Variant { get; private set; }
        public bool IsAnimation() => Variant == Variants.Animation;
        public bool IsSequence() => Variant == Variants.Sequence;
        public bool IsEvent() => Variant == Variants.Event;
        public override bool Equals(object obj) => Equals(obj as StartOffset);
        public bool Equals(StartOffset? other) => other != null && Variant == other.Variant;
        public override int GetHashCode() => System.HashCode.Combine(Variant);

        private static void Serialize(StartOffset v, Serializer s)
        {
            uint variantIndex = v.Variant switch
            {
                Variants.Animation => 0,
                Variants.Sequence => 1,
                Variants.Event => 2,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant("StartOffset", variantIndex);
        }

        private static StartOffset Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("StartOffset");
            return variantIndex switch
            {
                0 => StartOffset.Animation,
                1 => StartOffset.Sequence,
                2 => StartOffset.Event,
                _ => throw new UnknownVariantException("StartOffset", variantIndex),
            };
        }
    }
}
