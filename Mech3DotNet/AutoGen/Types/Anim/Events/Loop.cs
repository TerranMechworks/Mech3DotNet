using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Loop
    {
        public static readonly TypeConverter<Loop> Converter = new TypeConverter<Loop>(Deserialize, Serialize);

        public enum Variants
        {
            Count,
            RunTime,
        }

        private Loop(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static Loop Count(short value) => new Loop(Variants.Count, value);

        public static Loop RunTime(float value) => new Loop(Variants.RunTime, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsCount() => Variant == Variants.Count;
        public short AsCount() => (short)Value;
        public bool IsRunTime() => Variant == Variants.RunTime;
        public float AsRunTime() => (float)Value;

        private static void Serialize(Loop v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Count: // 0
                    {
                        var inner = v.AsCount();
                        s.SerializeNewTypeVariant(0);
                        ((Action<short>)s.SerializeI16)(inner);
                        break;
                    }

                case Variants.RunTime: // 1
                    {
                        var inner = v.AsRunTime();
                        s.SerializeNewTypeVariant(1);
                        ((Action<float>)s.SerializeF32)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static Loop Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Count
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Loop", 0, EnumType.NewType, enumType);
                        var inner = d.DeserializeI16();
                        return Loop.Count(inner);
                    }

                case 1: // RunTime
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Loop", 1, EnumType.NewType, enumType);
                        var inner = d.DeserializeF32();
                        return Loop.RunTime(inner);
                    }

                default:
                    throw new UnknownVariantException("Loop", variantIndex);
            }
        }
    }
}
