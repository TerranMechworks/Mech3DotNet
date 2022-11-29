using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Image
{
    public sealed class TextureStretch
    {
        public static readonly TypeConverter<TextureStretch> Converter = new TypeConverter<TextureStretch>(Deserialize, Serialize);

        public enum Variants
        {
            None,
            Vertical,
            Horizontal,
            Both,
            Unk4,
            Unk7,
            Unk8,
        }

        private TextureStretch(Variants variant)
        {
            Variant = variant;
        }
        public static readonly TextureStretch None = new TextureStretch(Variants.None);

        public static readonly TextureStretch Vertical = new TextureStretch(Variants.Vertical);

        public static readonly TextureStretch Horizontal = new TextureStretch(Variants.Horizontal);

        public static readonly TextureStretch Both = new TextureStretch(Variants.Both);

        public static readonly TextureStretch Unk4 = new TextureStretch(Variants.Unk4);

        public static readonly TextureStretch Unk7 = new TextureStretch(Variants.Unk7);

        public static readonly TextureStretch Unk8 = new TextureStretch(Variants.Unk8);

        public Variants Variant { get; private set; }
        public bool IsNone() => Variant == Variants.None;
        public bool IsVertical() => Variant == Variants.Vertical;
        public bool IsHorizontal() => Variant == Variants.Horizontal;
        public bool IsBoth() => Variant == Variants.Both;
        public bool IsUnk4() => Variant == Variants.Unk4;
        public bool IsUnk7() => Variant == Variants.Unk7;
        public bool IsUnk8() => Variant == Variants.Unk8;
        public override bool Equals(object obj) => Equals(obj as TextureStretch);
        public bool Equals(TextureStretch? other) => other != null && Variant == other.Variant;
        public override int GetHashCode() => System.HashCode.Combine(Variant);

        private static void Serialize(TextureStretch v, Serializer s)
        {
            uint variantIndex = v.Variant switch
            {
                Variants.None => 0,
                Variants.Vertical => 1,
                Variants.Horizontal => 2,
                Variants.Both => 3,
                Variants.Unk4 => 4,
                Variants.Unk7 => 5,
                Variants.Unk8 => 6,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static TextureStretch Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("TextureStretch");
            return variantIndex switch
            {
                0 => TextureStretch.None,
                1 => TextureStretch.Vertical,
                2 => TextureStretch.Horizontal,
                3 => TextureStretch.Both,
                4 => TextureStretch.Unk4,
                5 => TextureStretch.Unk7,
                6 => TextureStretch.Unk8,
                _ => throw new UnknownVariantException("TextureStretch", variantIndex),
            };
        }
    }
}
