using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Image
{
    public enum TextureAlpha
    {
        None,
        Simple,
        Full,
    }

    public static class TextureAlphaConverter
    {
        public static readonly TypeConverter<TextureAlpha> Converter = new TypeConverter<TextureAlpha>(Deserialize, Serialize);

        private static void Serialize(TextureAlpha v, Serializer s)
        {
            uint variantIndex = v switch
            {
                TextureAlpha.None => 0,
                TextureAlpha.Simple => 1,
                TextureAlpha.Full => 2,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
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
