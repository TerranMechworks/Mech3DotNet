using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Rc
{
    public sealed class Transformation
    {
        public static readonly TypeConverter<Transformation> Converter = new TypeConverter<Transformation>(Deserialize, Serialize);

        public enum Variants
        {
            None,
            ScaleOnly,
            RotationTranslation,
            TranslationOnly,
        }

        private Transformation(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static readonly Transformation None = new Transformation(Variants.None, new object());

        public static Transformation ScaleOnly(Mech3DotNet.Types.Types.Vec3 value) => new Transformation(Variants.ScaleOnly, value);

        public static Transformation RotationTranslation(Mech3DotNet.Types.Nodes.Rc.RotationTranslation value) => new Transformation(Variants.RotationTranslation, value);

        public static Transformation TranslationOnly(Mech3DotNet.Types.Nodes.Rc.TranslationOnly value) => new Transformation(Variants.TranslationOnly, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsNone() => Variant == Variants.None;
        public bool IsScaleOnly() => Variant == Variants.ScaleOnly;
        public Mech3DotNet.Types.Types.Vec3 AsScaleOnly() => (Mech3DotNet.Types.Types.Vec3)Value;
        public bool IsRotationTranslation() => Variant == Variants.RotationTranslation;
        public Mech3DotNet.Types.Nodes.Rc.RotationTranslation AsRotationTranslation() => (Mech3DotNet.Types.Nodes.Rc.RotationTranslation)Value;
        public bool IsTranslationOnly() => Variant == Variants.TranslationOnly;
        public Mech3DotNet.Types.Nodes.Rc.TranslationOnly AsTranslationOnly() => (Mech3DotNet.Types.Nodes.Rc.TranslationOnly)Value;

        private static void Serialize(Transformation v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.None: // 0
                    {
                        s.SerializeUnitVariant(0);
                        break;
                    }

                case Variants.ScaleOnly: // 1
                    {
                        var inner = v.AsScaleOnly();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(inner);
                        break;
                    }

                case Variants.RotationTranslation: // 2
                    {
                        var inner = v.AsRotationTranslation();
                        s.SerializeNewTypeVariant(2);
                        s.Serialize(Mech3DotNet.Types.Nodes.Rc.RotationTranslation.Converter)(inner);
                        break;
                    }

                case Variants.TranslationOnly: // 3
                    {
                        var inner = v.AsTranslationOnly();
                        s.SerializeNewTypeVariant(3);
                        s.Serialize(Mech3DotNet.Types.Nodes.Rc.TranslationOnly.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static Transformation Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // None
                    {
                        if (enumType != EnumType.Unit)
                            throw new InvalidVariantException("Transformation", 0, EnumType.Unit, enumType);
                        return Transformation.None;
                    }

                case 1: // ScaleOnly
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Transformation", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        return Transformation.ScaleOnly(inner);
                    }

                case 2: // RotationTranslation
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Transformation", 2, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Rc.RotationTranslation.Converter)();
                        return Transformation.RotationTranslation(inner);
                    }

                case 3: // TranslationOnly
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Transformation", 3, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Rc.TranslationOnly.Converter)();
                        return Transformation.TranslationOnly(inner);
                    }

                default:
                    throw new UnknownVariantException("Transformation", variantIndex);
            }
        }
    }
}
