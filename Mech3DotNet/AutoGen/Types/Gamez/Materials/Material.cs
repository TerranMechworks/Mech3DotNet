using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Materials
{
    public sealed class Material
    {
        public static readonly TypeConverter<Material> Converter = new TypeConverter<Material>(Deserialize, Serialize);

        public enum Variants
        {
            Textured,
            Colored,
        }

        private Material(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static Material Textured(Mech3DotNet.Types.Gamez.Materials.TexturedMaterial value) => new Material(Variants.Textured, value);

        public static Material Colored(Mech3DotNet.Types.Gamez.Materials.ColoredMaterial value) => new Material(Variants.Colored, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsTextured() => Variant == Variants.Textured;
        public Mech3DotNet.Types.Gamez.Materials.TexturedMaterial AsTextured() => (Mech3DotNet.Types.Gamez.Materials.TexturedMaterial)Value;
        public bool IsColored() => Variant == Variants.Colored;
        public Mech3DotNet.Types.Gamez.Materials.ColoredMaterial AsColored() => (Mech3DotNet.Types.Gamez.Materials.ColoredMaterial)Value;

        private static void Serialize(Material v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Textured: // 0
                    {
                        var inner = v.AsTextured();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Gamez.Materials.TexturedMaterial.Converter)(inner);
                        break;
                    }

                case Variants.Colored: // 1
                    {
                        var inner = v.AsColored();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Gamez.Materials.ColoredMaterial.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static Material Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Textured
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Material", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Gamez.Materials.TexturedMaterial.Converter)();
                        return Material.Textured(inner);
                    }

                case 1: // Colored
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Material", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Gamez.Materials.ColoredMaterial.Converter)();
                        return Material.Colored(inner);
                    }

                default:
                    throw new UnknownVariantException("Material", variantIndex);
            }
        }
    }
}
