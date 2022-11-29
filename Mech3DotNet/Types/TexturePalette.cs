using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Image
{
    public sealed class TexturePalette
    {
        public static readonly TypeConverter<TexturePalette> Converter = new TypeConverter<TexturePalette>(Deserialize, Serialize);

        public enum Variants
        {
            None,
            Local,
            Global,
        }

        private TexturePalette(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static readonly TexturePalette None = new TexturePalette(Variants.None, new object());

        public static TexturePalette Local(Mech3DotNet.Types.Image.PaletteData value) => new TexturePalette(Variants.Local, value);

        public static TexturePalette Global(Mech3DotNet.Types.Image.GlobalPalette value) => new TexturePalette(Variants.Global, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsNone() => Variant == Variants.None;
        public bool IsLocal() => Variant == Variants.Local;
        public Mech3DotNet.Types.Image.PaletteData AsLocal() => (Mech3DotNet.Types.Image.PaletteData)Value;
        public bool IsGlobal() => Variant == Variants.Global;
        public Mech3DotNet.Types.Image.GlobalPalette AsGlobal() => (Mech3DotNet.Types.Image.GlobalPalette)Value;

        private static void Serialize(TexturePalette v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.None: // 0
                    {
                        s.SerializeUnitVariant(0);
                        break;
                    }

                case Variants.Local: // 1
                    {
                        var inner = v.AsLocal();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Image.PaletteData.Converter)(inner);
                        break;
                    }

                case Variants.Global: // 2
                    {
                        var inner = v.AsGlobal();
                        s.SerializeNewTypeVariant(2);
                        s.Serialize(Mech3DotNet.Types.Image.GlobalPalette.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static TexturePalette Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // None
                    {
                        if (enumType != EnumType.Unit)
                            throw new InvalidVariantException("TexturePalette", 0, EnumType.Unit, enumType);
                        return TexturePalette.None;
                    }

                case 1: // Local
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("TexturePalette", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Image.PaletteData.Converter)();
                        return TexturePalette.Local(inner);
                    }

                case 2: // Global
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("TexturePalette", 2, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Image.GlobalPalette.Converter)();
                        return TexturePalette.Global(inner);
                    }

                default:
                    throw new UnknownVariantException("TexturePalette", variantIndex);
            }
        }
    }
}
