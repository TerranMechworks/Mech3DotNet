using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public sealed class Execution
    {
        public static readonly TypeConverter<Execution> Converter = new TypeConverter<Execution>(Deserialize, Serialize);

        public enum Variants
        {
            ByRange,
            ByZone,
            None,
        }

        private Execution(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static Execution ByRange(Mech3DotNet.Types.Types.Range value) => new Execution(Variants.ByRange, value);

        public static readonly Execution ByZone = new Execution(Variants.ByZone, new object());

        public static readonly Execution None = new Execution(Variants.None, new object());

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsByRange() => Variant == Variants.ByRange;
        public Mech3DotNet.Types.Types.Range AsByRange() => (Mech3DotNet.Types.Types.Range)Value;
        public bool IsByZone() => Variant == Variants.ByZone;
        public bool IsNone() => Variant == Variants.None;

        private static void Serialize(Execution v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.ByRange: // 0
                    {
                        var inner = v.AsByRange();
                        s.SerializeNewTypeVariant("Execution", 0);
                        s.Serialize(Mech3DotNet.Types.Types.RangeConverter.Converter)(inner);
                        break;
                    }

                case Variants.ByZone: // 1
                    {
                        s.SerializeUnitVariant("Execution", 1);
                        break;
                    }

                case Variants.None: // 2
                    {
                        s.SerializeUnitVariant("Execution", 2);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static Execution Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum("Execution");
            switch (variantIndex)
            {
                case 0: // ByRange
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Execution", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Types.RangeConverter.Converter)();
                        return Execution.ByRange(inner);
                    }

                case 1: // ByZone
                    {
                        if (enumType != EnumType.Unit)
                            throw new InvalidVariantException("Execution", 1, EnumType.Unit, enumType);
                        return Execution.ByZone;
                    }

                case 2: // None
                    {
                        if (enumType != EnumType.Unit)
                            throw new InvalidVariantException("Execution", 2, EnumType.Unit, enumType);
                        return Execution.None;
                    }

                default:
                    throw new UnknownVariantException("Execution", variantIndex);
            }
        }
    }
}
