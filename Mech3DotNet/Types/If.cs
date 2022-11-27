using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class If
    {
        public static readonly TypeConverter<If> Converter = new TypeConverter<If>(Deserialize, Serialize);

        public enum Variants
        {
            RandomWeight,
            PlayerRange,
            AnimationLod,
            HwRender,
            PlayerFirstPerson,
        }

        private If(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static If RandomWeight(Mech3DotNet.Types.Anim.Events.RandomWeightCond value) => new If(Variants.RandomWeight, value);

        public static If PlayerRange(Mech3DotNet.Types.Anim.Events.PlayerRangeCond value) => new If(Variants.PlayerRange, value);

        public static If AnimationLod(Mech3DotNet.Types.Anim.Events.AnimationLodCond value) => new If(Variants.AnimationLod, value);

        public static If HwRender(Mech3DotNet.Types.Anim.Events.HwRenderCond value) => new If(Variants.HwRender, value);

        public static If PlayerFirstPerson(Mech3DotNet.Types.Anim.Events.PlayerFirstPersonCond value) => new If(Variants.PlayerFirstPerson, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsRandomWeight() => Variant == Variants.RandomWeight;
        public Mech3DotNet.Types.Anim.Events.RandomWeightCond AsRandomWeight() => (Mech3DotNet.Types.Anim.Events.RandomWeightCond)Value;
        public bool IsPlayerRange() => Variant == Variants.PlayerRange;
        public Mech3DotNet.Types.Anim.Events.PlayerRangeCond AsPlayerRange() => (Mech3DotNet.Types.Anim.Events.PlayerRangeCond)Value;
        public bool IsAnimationLod() => Variant == Variants.AnimationLod;
        public Mech3DotNet.Types.Anim.Events.AnimationLodCond AsAnimationLod() => (Mech3DotNet.Types.Anim.Events.AnimationLodCond)Value;
        public bool IsHwRender() => Variant == Variants.HwRender;
        public Mech3DotNet.Types.Anim.Events.HwRenderCond AsHwRender() => (Mech3DotNet.Types.Anim.Events.HwRenderCond)Value;
        public bool IsPlayerFirstPerson() => Variant == Variants.PlayerFirstPerson;
        public Mech3DotNet.Types.Anim.Events.PlayerFirstPersonCond AsPlayerFirstPerson() => (Mech3DotNet.Types.Anim.Events.PlayerFirstPersonCond)Value;

        private static void Serialize(If v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.RandomWeight: // 0
                    {
                        var inner = v.AsRandomWeight();
                        s.SerializeNewTypeVariant("If", 0);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.RandomWeightCond.Converter)(inner);
                        break;
                    }

                case Variants.PlayerRange: // 1
                    {
                        var inner = v.AsPlayerRange();
                        s.SerializeNewTypeVariant("If", 1);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.PlayerRangeCond.Converter)(inner);
                        break;
                    }

                case Variants.AnimationLod: // 2
                    {
                        var inner = v.AsAnimationLod();
                        s.SerializeNewTypeVariant("If", 2);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.AnimationLodCond.Converter)(inner);
                        break;
                    }

                case Variants.HwRender: // 3
                    {
                        var inner = v.AsHwRender();
                        s.SerializeNewTypeVariant("If", 3);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.HwRenderCond.Converter)(inner);
                        break;
                    }

                case Variants.PlayerFirstPerson: // 4
                    {
                        var inner = v.AsPlayerFirstPerson();
                        s.SerializeNewTypeVariant("If", 4);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.PlayerFirstPersonCond.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static If Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum("If");
            switch (variantIndex)
            {
                case 0: // RandomWeight
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("If", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.RandomWeightCond.Converter)();
                        return If.RandomWeight(inner);
                    }

                case 1: // PlayerRange
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("If", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.PlayerRangeCond.Converter)();
                        return If.PlayerRange(inner);
                    }

                case 2: // AnimationLod
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("If", 2, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.AnimationLodCond.Converter)();
                        return If.AnimationLod(inner);
                    }

                case 3: // HwRender
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("If", 3, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.HwRenderCond.Converter)();
                        return If.HwRender(inner);
                    }

                case 4: // PlayerFirstPerson
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("If", 4, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.PlayerFirstPersonCond.Converter)();
                        return If.PlayerFirstPerson(inner);
                    }

                default:
                    throw new UnknownVariantException("If", variantIndex);
            }
        }
    }
}
