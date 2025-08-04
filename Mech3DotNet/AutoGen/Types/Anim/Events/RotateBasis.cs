using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class RotateBasis
    {
        public static readonly TypeConverter<RotateBasis> Converter = new TypeConverter<RotateBasis>(Deserialize, Serialize);

        public enum Variants
        {
            Absolute,
            Relative,
            AtNodeMatrix,
            AtNodeXYZ,
        }

        private RotateBasis(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static readonly RotateBasis Absolute = new RotateBasis(Variants.Absolute, new object());

        public static readonly RotateBasis Relative = new RotateBasis(Variants.Relative, new object());

        public static RotateBasis AtNodeMatrix(string value) => new RotateBasis(Variants.AtNodeMatrix, value);

        public static RotateBasis AtNodeXYZ(string value) => new RotateBasis(Variants.AtNodeXYZ, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsAbsolute() => Variant == Variants.Absolute;
        public bool IsRelative() => Variant == Variants.Relative;
        public bool IsAtNodeMatrix() => Variant == Variants.AtNodeMatrix;
        public string AsAtNodeMatrix() => (string)Value;
        public bool IsAtNodeXYZ() => Variant == Variants.AtNodeXYZ;
        public string AsAtNodeXYZ() => (string)Value;

        private static void Serialize(RotateBasis v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Absolute: // 0
                    {
                        s.SerializeUnitVariant(0);
                        break;
                    }

                case Variants.Relative: // 1
                    {
                        s.SerializeUnitVariant(1);
                        break;
                    }

                case Variants.AtNodeMatrix: // 2
                    {
                        var inner = v.AsAtNodeMatrix();
                        s.SerializeNewTypeVariant(2);
                        ((Action<string>)s.SerializeString)(inner);
                        break;
                    }

                case Variants.AtNodeXYZ: // 3
                    {
                        var inner = v.AsAtNodeXYZ();
                        s.SerializeNewTypeVariant(3);
                        ((Action<string>)s.SerializeString)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static RotateBasis Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Absolute
                    {
                        if (enumType != EnumType.Unit)
                            throw new InvalidVariantException("RotateBasis", 0, EnumType.Unit, enumType);
                        return RotateBasis.Absolute;
                    }

                case 1: // Relative
                    {
                        if (enumType != EnumType.Unit)
                            throw new InvalidVariantException("RotateBasis", 1, EnumType.Unit, enumType);
                        return RotateBasis.Relative;
                    }

                case 2: // AtNodeMatrix
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("RotateBasis", 2, EnumType.NewType, enumType);
                        var inner = d.DeserializeString();
                        return RotateBasis.AtNodeMatrix(inner);
                    }

                case 3: // AtNodeXYZ
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("RotateBasis", 3, EnumType.NewType, enumType);
                        var inner = d.DeserializeString();
                        return RotateBasis.AtNodeXYZ(inner);
                    }

                default:
                    throw new UnknownVariantException("RotateBasis", variantIndex);
            }
        }
    }
}
