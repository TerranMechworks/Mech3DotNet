using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Condition
    {
        public static readonly TypeConverter<Condition> Converter = new TypeConverter<Condition>(Deserialize, Serialize);

        public enum Variants
        {
            RandomWeight,
            PlayerRange,
            AnimationLod,
            NodeUndercover,
            HwRender,
            PlayerFirstPerson,
        }

        private Condition(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static Condition RandomWeight(float value) => new Condition(Variants.RandomWeight, value);

        public static Condition PlayerRange(float value) => new Condition(Variants.PlayerRange, value);

        public static Condition AnimationLod(uint value) => new Condition(Variants.AnimationLod, value);

        public static Condition NodeUndercover(Mech3DotNet.Types.Anim.Events.NodeUndercover value) => new Condition(Variants.NodeUndercover, value);

        public static Condition HwRender(bool value) => new Condition(Variants.HwRender, value);

        public static Condition PlayerFirstPerson(bool value) => new Condition(Variants.PlayerFirstPerson, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsRandomWeight() => Variant == Variants.RandomWeight;
        public float AsRandomWeight() => (float)Value;
        public bool IsPlayerRange() => Variant == Variants.PlayerRange;
        public float AsPlayerRange() => (float)Value;
        public bool IsAnimationLod() => Variant == Variants.AnimationLod;
        public uint AsAnimationLod() => (uint)Value;
        public bool IsNodeUndercover() => Variant == Variants.NodeUndercover;
        public Mech3DotNet.Types.Anim.Events.NodeUndercover AsNodeUndercover() => (Mech3DotNet.Types.Anim.Events.NodeUndercover)Value;
        public bool IsHwRender() => Variant == Variants.HwRender;
        public bool AsHwRender() => (bool)Value;
        public bool IsPlayerFirstPerson() => Variant == Variants.PlayerFirstPerson;
        public bool AsPlayerFirstPerson() => (bool)Value;

        private static void Serialize(Condition v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.RandomWeight: // 0
                    {
                        var inner = v.AsRandomWeight();
                        s.SerializeNewTypeVariant(0);
                        ((Action<float>)s.SerializeF32)(inner);
                        break;
                    }

                case Variants.PlayerRange: // 1
                    {
                        var inner = v.AsPlayerRange();
                        s.SerializeNewTypeVariant(1);
                        ((Action<float>)s.SerializeF32)(inner);
                        break;
                    }

                case Variants.AnimationLod: // 2
                    {
                        var inner = v.AsAnimationLod();
                        s.SerializeNewTypeVariant(2);
                        ((Action<uint>)s.SerializeU32)(inner);
                        break;
                    }

                case Variants.NodeUndercover: // 3
                    {
                        var inner = v.AsNodeUndercover();
                        s.SerializeNewTypeVariant(3);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.NodeUndercover.Converter)(inner);
                        break;
                    }

                case Variants.HwRender: // 4
                    {
                        var inner = v.AsHwRender();
                        s.SerializeNewTypeVariant(4);
                        ((Action<bool>)s.SerializeBool)(inner);
                        break;
                    }

                case Variants.PlayerFirstPerson: // 5
                    {
                        var inner = v.AsPlayerFirstPerson();
                        s.SerializeNewTypeVariant(5);
                        ((Action<bool>)s.SerializeBool)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static Condition Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // RandomWeight
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Condition", 0, EnumType.NewType, enumType);
                        var inner = d.DeserializeF32();
                        return Condition.RandomWeight(inner);
                    }

                case 1: // PlayerRange
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Condition", 1, EnumType.NewType, enumType);
                        var inner = d.DeserializeF32();
                        return Condition.PlayerRange(inner);
                    }

                case 2: // AnimationLod
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Condition", 2, EnumType.NewType, enumType);
                        var inner = d.DeserializeU32();
                        return Condition.AnimationLod(inner);
                    }

                case 3: // NodeUndercover
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Condition", 3, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.NodeUndercover.Converter)();
                        return Condition.NodeUndercover(inner);
                    }

                case 4: // HwRender
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Condition", 4, EnumType.NewType, enumType);
                        var inner = d.DeserializeBool();
                        return Condition.HwRender(inner);
                    }

                case 5: // PlayerFirstPerson
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Condition", 5, EnumType.NewType, enumType);
                        var inner = d.DeserializeBool();
                        return Condition.PlayerFirstPerson(inner);
                    }

                default:
                    throw new UnknownVariantException("Condition", variantIndex);
            }
        }
    }
}
