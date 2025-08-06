using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class Transform
    {
        public static readonly TypeConverter<Transform> Converter = new TypeConverter<Transform>(Deserialize, Serialize);

        public enum Variants
        {
            Initial,
            Matrix,
            RotateTranslateScale,
        }

        private Transform(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static readonly Transform Initial = new Transform(Variants.Initial, new object());

        public static Transform Matrix(Mech3DotNet.Types.Common.AffineMatrix value) => new Transform(Variants.Matrix, value);

        public static Transform RotateTranslateScale(Mech3DotNet.Types.Gamez.Nodes.RotateTranslateScale value) => new Transform(Variants.RotateTranslateScale, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsInitial() => Variant == Variants.Initial;
        public bool IsMatrix() => Variant == Variants.Matrix;
        public Mech3DotNet.Types.Common.AffineMatrix AsMatrix() => (Mech3DotNet.Types.Common.AffineMatrix)Value;
        public bool IsRotateTranslateScale() => Variant == Variants.RotateTranslateScale;
        public Mech3DotNet.Types.Gamez.Nodes.RotateTranslateScale AsRotateTranslateScale() => (Mech3DotNet.Types.Gamez.Nodes.RotateTranslateScale)Value;

        #region "Serialize/Deserialize logic"

        private static void Serialize(Transform v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Initial: // 0
                    {
                        s.SerializeUnitVariant(0);
                        break;
                    }

                case Variants.Matrix: // 1
                    {
                        var inner = v.AsMatrix();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Common.AffineMatrix.Converter)(inner);
                        break;
                    }

                case Variants.RotateTranslateScale: // 2
                    {
                        var inner = v.AsRotateTranslateScale();
                        s.SerializeNewTypeVariant(2);
                        s.Serialize(Mech3DotNet.Types.Gamez.Nodes.RotateTranslateScale.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static Transform Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Initial
                    {
                        if (enumType != EnumType.Unit)
                            throw new InvalidVariantException("Transform", 0, EnumType.Unit, enumType);
                        return Transform.Initial;
                    }

                case 1: // Matrix
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Transform", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Common.AffineMatrix.Converter)();
                        return Transform.Matrix(inner);
                    }

                case 2: // RotateTranslateScale
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Transform", 2, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.RotateTranslateScale.Converter)();
                        return Transform.RotateTranslateScale(inner);
                    }

                default:
                    throw new UnknownVariantException("Transform", variantIndex);
            }
        }

        #endregion
    }
}
