using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class MechlibMaterial
    {
        public static readonly TypeConverter<MechlibMaterial> Converter = new TypeConverter<MechlibMaterial>(Deserialize, Serialize);

        public enum Variants
        {
            Textured,
            Colored,
        }

        private MechlibMaterial(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static MechlibMaterial Textured(Mech3DotNet.Types.Gamez.MechlibTexturedMaterial value) => new MechlibMaterial(Variants.Textured, value);

        public static MechlibMaterial Colored(Mech3DotNet.Types.Gamez.MechlibColoredMaterial value) => new MechlibMaterial(Variants.Colored, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsTextured() => Variant == Variants.Textured;
        public Mech3DotNet.Types.Gamez.MechlibTexturedMaterial AsTextured() => (Mech3DotNet.Types.Gamez.MechlibTexturedMaterial)Value;
        public bool IsColored() => Variant == Variants.Colored;
        public Mech3DotNet.Types.Gamez.MechlibColoredMaterial AsColored() => (Mech3DotNet.Types.Gamez.MechlibColoredMaterial)Value;

        #region "Serialize/Deserialize logic"

        private static void Serialize(MechlibMaterial v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Textured: // 0
                    {
                        var inner = v.AsTextured();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Gamez.MechlibTexturedMaterial.Converter)(inner);
                        break;
                    }

                case Variants.Colored: // 1
                    {
                        var inner = v.AsColored();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Gamez.MechlibColoredMaterial.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static MechlibMaterial Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Textured
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("MechlibMaterial", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Gamez.MechlibTexturedMaterial.Converter)();
                        return MechlibMaterial.Textured(inner);
                    }

                case 1: // Colored
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("MechlibMaterial", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Gamez.MechlibColoredMaterial.Converter)();
                        return MechlibMaterial.Colored(inner);
                    }

                default:
                    throw new UnknownVariantException("MechlibMaterial", variantIndex);
            }
        }

        #endregion
    }
}
