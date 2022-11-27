using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Image
{
    public sealed class TextureAlpha
    {
        public static readonly TypeConverter<TextureAlpha> Converter = new TypeConverter<TextureAlpha>(Deserialize, Serialize);

        public enum Variants
        {
            None,
            Simple,
            Full,
        }

        private TextureAlpha(Variants variant)
        {
            Variant = variant;
        }
        public static readonly TextureAlpha None = new TextureAlpha(Variants.None);

        public static readonly TextureAlpha Simple = new TextureAlpha(Variants.Simple);

        public static readonly TextureAlpha Full = new TextureAlpha(Variants.Full);

        public Variants Variant { get; private set; }
        public bool IsNone() => Variant == Variants.None;
        public bool IsSimple() => Variant == Variants.Simple;
        public bool IsFull() => Variant == Variants.Full;
        public override bool Equals(object obj) => Equals(obj as TextureAlpha);
        public bool Equals(TextureAlpha? other) => other != null && Variant == other.Variant;
        public override int GetHashCode() => System.HashCode.Combine(Variant);

        private static void Serialize(TextureAlpha v, Serializer s)
        {
            uint variantIndex = v.Variant switch
            {
                Variants.None => 0,
                Variants.Simple => 1,
                Variants.Full => 2,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant("TextureAlpha", variantIndex);
        }

        private static TextureAlpha Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("TextureAlpha");
            return variantIndex switch
            {
                0 => TextureAlpha.None,
                1 => TextureAlpha.Simple,
                2 => TextureAlpha.Full,
                _ => throw new UnknownVariantException("TextureAlpha", variantIndex),
            };
        }
    }
}
