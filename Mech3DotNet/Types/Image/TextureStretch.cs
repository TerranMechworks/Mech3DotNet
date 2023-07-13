using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Image
{
    public enum TextureStretch
    {
        None,
        Vertical,
        Horizontal,
        Both,
        Unk4,
        Unk7,
        Unk8,
    }

    public static class TextureStretchConverter
    {
        public static readonly TypeConverter<TextureStretch> Converter = new TypeConverter<TextureStretch>(Deserialize, Serialize);

        private static void Serialize(TextureStretch v, Serializer s)
        {
            uint variantIndex = v switch
            {
                TextureStretch.None => 0,
                TextureStretch.Vertical => 1,
                TextureStretch.Horizontal => 2,
                TextureStretch.Both => 3,
                TextureStretch.Unk4 => 4,
                TextureStretch.Unk7 => 5,
                TextureStretch.Unk8 => 6,
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
