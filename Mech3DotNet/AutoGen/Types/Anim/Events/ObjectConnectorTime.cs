using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectConnectorTime
    {
        public static readonly TypeConverter<ObjectConnectorTime> Converter = new TypeConverter<ObjectConnectorTime>(Deserialize, Serialize);

        public enum Variants
        {
            Scalar,
            Range,
        }

        private ObjectConnectorTime(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static ObjectConnectorTime Scalar(float value) => new ObjectConnectorTime(Variants.Scalar, value);

        public static ObjectConnectorTime Range(Mech3DotNet.Types.Common.Range value) => new ObjectConnectorTime(Variants.Range, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsScalar() => Variant == Variants.Scalar;
        public float AsScalar() => (float)Value;
        public bool IsRange() => Variant == Variants.Range;
        public Mech3DotNet.Types.Common.Range AsRange() => (Mech3DotNet.Types.Common.Range)Value;

        #region "Serialize/Deserialize logic"

        private static void Serialize(ObjectConnectorTime v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Scalar: // 0
                    {
                        var inner = v.AsScalar();
                        s.SerializeNewTypeVariant(0);
                        ((Action<float>)s.SerializeF32)(inner);
                        break;
                    }

                case Variants.Range: // 1
                    {
                        var inner = v.AsRange();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static ObjectConnectorTime Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Scalar
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ObjectConnectorTime", 0, EnumType.NewType, enumType);
                        var inner = d.DeserializeF32();
                        return ObjectConnectorTime.Scalar(inner);
                    }

                case 1: // Range
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ObjectConnectorTime", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter)();
                        return ObjectConnectorTime.Range(inner);
                    }

                default:
                    throw new UnknownVariantException("ObjectConnectorTime", variantIndex);
            }
        }

        #endregion
    }
}
