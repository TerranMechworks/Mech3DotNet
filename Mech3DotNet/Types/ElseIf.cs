using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ElseIf
    {
        public static readonly TypeConverter<ElseIf> Converter = new TypeConverter<ElseIf>(Deserialize, Serialize);

        public enum Variants
        {
            RandomWeight,
            PlayerRange,
            AnimationLod,
            HwRender,
            PlayerFirstPerson,
        }

        private ElseIf(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static ElseIf RandomWeight(Mech3DotNet.Types.Anim.Events.RandomWeightCond value) => new ElseIf(Variants.RandomWeight, value);

        public static ElseIf PlayerRange(Mech3DotNet.Types.Anim.Events.PlayerRangeCond value) => new ElseIf(Variants.PlayerRange, value);

        public static ElseIf AnimationLod(Mech3DotNet.Types.Anim.Events.AnimationLodCond value) => new ElseIf(Variants.AnimationLod, value);

        public static ElseIf HwRender(Mech3DotNet.Types.Anim.Events.HwRenderCond value) => new ElseIf(Variants.HwRender, value);

        public static ElseIf PlayerFirstPerson(Mech3DotNet.Types.Anim.Events.PlayerFirstPersonCond value) => new ElseIf(Variants.PlayerFirstPerson, value);

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

        private static void Serialize(ElseIf v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.RandomWeight: // 0
                    {
                        var inner = v.AsRandomWeight();
                        s.SerializeNewTypeVariant("ElseIf", 0);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.RandomWeightCond.Converter)(inner);
                        break;
                    }

                case Variants.PlayerRange: // 1
                    {
                        var inner = v.AsPlayerRange();
                        s.SerializeNewTypeVariant("ElseIf", 1);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.PlayerRangeCond.Converter)(inner);
                        break;
                    }

                case Variants.AnimationLod: // 2
                    {
                        var inner = v.AsAnimationLod();
                        s.SerializeNewTypeVariant("ElseIf", 2);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.AnimationLodCond.Converter)(inner);
                        break;
                    }

                case Variants.HwRender: // 3
                    {
                        var inner = v.AsHwRender();
                        s.SerializeNewTypeVariant("ElseIf", 3);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.HwRenderCond.Converter)(inner);
                        break;
                    }

                case Variants.PlayerFirstPerson: // 4
                    {
                        var inner = v.AsPlayerFirstPerson();
                        s.SerializeNewTypeVariant("ElseIf", 4);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.PlayerFirstPersonCond.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static ElseIf Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum("ElseIf");
            switch (variantIndex)
            {
                case 0: // RandomWeight
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ElseIf", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.RandomWeightCond.Converter)();
                        return ElseIf.RandomWeight(inner);
                    }

                case 1: // PlayerRange
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ElseIf", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.PlayerRangeCond.Converter)();
                        return ElseIf.PlayerRange(inner);
                    }

                case 2: // AnimationLod
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ElseIf", 2, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.AnimationLodCond.Converter)();
                        return ElseIf.AnimationLod(inner);
                    }

                case 3: // HwRender
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ElseIf", 3, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.HwRenderCond.Converter)();
                        return ElseIf.HwRender(inner);
                    }

                case 4: // PlayerFirstPerson
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ElseIf", 4, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.PlayerFirstPersonCond.Converter)();
                        return ElseIf.PlayerFirstPerson(inner);
                    }

                default:
                    throw new UnknownVariantException("ElseIf", variantIndex);
            }
        }
    }
}
