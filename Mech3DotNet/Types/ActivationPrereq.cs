using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public sealed class ActivationPrereq
    {
        public static readonly TypeConverter<ActivationPrereq> Converter = new TypeConverter<ActivationPrereq>(Deserialize, Serialize);

        public enum Variants
        {
            Animation,
            Parent,
            Object,
        }

        private ActivationPrereq(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static ActivationPrereq Animation(Mech3DotNet.Types.Anim.PrereqAnimation value) => new ActivationPrereq(Variants.Animation, value);

        public static ActivationPrereq Parent(Mech3DotNet.Types.Anim.PrereqParent value) => new ActivationPrereq(Variants.Parent, value);

        public static ActivationPrereq Object(Mech3DotNet.Types.Anim.PrereqObject value) => new ActivationPrereq(Variants.Object, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsAnimation() => Variant == Variants.Animation;
        public Mech3DotNet.Types.Anim.PrereqAnimation AsAnimation() => (Mech3DotNet.Types.Anim.PrereqAnimation)Value;
        public bool IsParent() => Variant == Variants.Parent;
        public Mech3DotNet.Types.Anim.PrereqParent AsParent() => (Mech3DotNet.Types.Anim.PrereqParent)Value;
        public bool IsObject() => Variant == Variants.Object;
        public Mech3DotNet.Types.Anim.PrereqObject AsObject() => (Mech3DotNet.Types.Anim.PrereqObject)Value;

        private static void Serialize(ActivationPrereq v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Animation: // 0
                    {
                        var inner = v.AsAnimation();
                        s.SerializeNewTypeVariant("ActivationPrereq", 0);
                        s.Serialize(Mech3DotNet.Types.Anim.PrereqAnimationConverter.Converter)(inner);
                        break;
                    }

                case Variants.Parent: // 1
                    {
                        var inner = v.AsParent();
                        s.SerializeNewTypeVariant("ActivationPrereq", 1);
                        s.Serialize(Mech3DotNet.Types.Anim.PrereqParentConverter.Converter)(inner);
                        break;
                    }

                case Variants.Object: // 2
                    {
                        var inner = v.AsObject();
                        s.SerializeNewTypeVariant("ActivationPrereq", 2);
                        s.Serialize(Mech3DotNet.Types.Anim.PrereqObjectConverter.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static ActivationPrereq Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum("ActivationPrereq");
            switch (variantIndex)
            {
                case 0: // Animation
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ActivationPrereq", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.PrereqAnimationConverter.Converter)();
                        return ActivationPrereq.Animation(inner);
                    }

                case 1: // Parent
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ActivationPrereq", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.PrereqParentConverter.Converter)();
                        return ActivationPrereq.Parent(inner);
                    }

                case 2: // Object
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ActivationPrereq", 2, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.PrereqObjectConverter.Converter)();
                        return ActivationPrereq.Object(inner);
                    }

                default:
                    throw new UnknownVariantException("ActivationPrereq", variantIndex);
            }
        }
    }
}
