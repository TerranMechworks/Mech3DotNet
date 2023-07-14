using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class RotateState
    {
        public static readonly TypeConverter<RotateState> Converter = new TypeConverter<RotateState>(Deserialize, Serialize);

        public enum Variants
        {
            Absolute,
            AtNodeXYZ,
            AtNodeMatrix,
        }

        private RotateState(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static RotateState Absolute(Mech3DotNet.Types.Types.Vec3 value) => new RotateState(Variants.Absolute, value);

        public static readonly RotateState AtNodeXYZ = new RotateState(Variants.AtNodeXYZ, new object());

        public static readonly RotateState AtNodeMatrix = new RotateState(Variants.AtNodeMatrix, new object());

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsAbsolute() => Variant == Variants.Absolute;
        public Mech3DotNet.Types.Types.Vec3 AsAbsolute() => (Mech3DotNet.Types.Types.Vec3)Value;
        public bool IsAtNodeXYZ() => Variant == Variants.AtNodeXYZ;
        public bool IsAtNodeMatrix() => Variant == Variants.AtNodeMatrix;

        private static void Serialize(RotateState v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Absolute: // 0
                    {
                        var inner = v.AsAbsolute();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)(inner);
                        break;
                    }

                case Variants.AtNodeXYZ: // 1
                    {
                        s.SerializeUnitVariant(1);
                        break;
                    }

                case Variants.AtNodeMatrix: // 2
                    {
                        s.SerializeUnitVariant(2);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static RotateState Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Absolute
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("RotateState", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter)();
                        return RotateState.Absolute(inner);
                    }

                case 1: // AtNodeXYZ
                    {
                        if (enumType != EnumType.Unit)
                            throw new InvalidVariantException("RotateState", 1, EnumType.Unit, enumType);
                        return RotateState.AtNodeXYZ;
                    }

                case 2: // AtNodeMatrix
                    {
                        if (enumType != EnumType.Unit)
                            throw new InvalidVariantException("RotateState", 2, EnumType.Unit, enumType);
                        return RotateState.AtNodeMatrix;
                    }

                default:
                    throw new UnknownVariantException("RotateState", variantIndex);
            }
        }
    }
}
