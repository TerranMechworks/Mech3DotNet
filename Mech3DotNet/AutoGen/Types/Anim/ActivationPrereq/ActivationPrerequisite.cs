using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.ActivationPrereq
{
    public sealed class ActivationPrerequisite
    {
        public static readonly TypeConverter<ActivationPrerequisite> Converter = new TypeConverter<ActivationPrerequisite>(Deserialize, Serialize);

        public enum Variants
        {
            Animation,
            Parent,
            Object,
        }

        private ActivationPrerequisite(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static ActivationPrerequisite Animation(Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteAnimation value) => new ActivationPrerequisite(Variants.Animation, value);

        public static ActivationPrerequisite Parent(Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteParent value) => new ActivationPrerequisite(Variants.Parent, value);

        public static ActivationPrerequisite Object(Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteObject value) => new ActivationPrerequisite(Variants.Object, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsAnimation() => Variant == Variants.Animation;
        public Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteAnimation AsAnimation() => (Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteAnimation)Value;
        public bool IsParent() => Variant == Variants.Parent;
        public Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteParent AsParent() => (Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteParent)Value;
        public bool IsObject() => Variant == Variants.Object;
        public Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteObject AsObject() => (Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteObject)Value;

        #region "Serialize/Deserialize logic"

        private static void Serialize(ActivationPrerequisite v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Animation: // 0
                    {
                        var inner = v.AsAnimation();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteAnimation.Converter)(inner);
                        break;
                    }

                case Variants.Parent: // 1
                    {
                        var inner = v.AsParent();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteParent.Converter)(inner);
                        break;
                    }

                case Variants.Object: // 2
                    {
                        var inner = v.AsObject();
                        s.SerializeNewTypeVariant(2);
                        s.Serialize(Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteObject.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static ActivationPrerequisite Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Animation
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ActivationPrerequisite", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteAnimation.Converter)();
                        return ActivationPrerequisite.Animation(inner);
                    }

                case 1: // Parent
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ActivationPrerequisite", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteParent.Converter)();
                        return ActivationPrerequisite.Parent(inner);
                    }

                case 2: // Object
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ActivationPrerequisite", 2, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.ActivationPrereq.PrerequisiteObject.Converter)();
                        return ActivationPrerequisite.Object(inner);
                    }

                default:
                    throw new UnknownVariantException("ActivationPrerequisite", variantIndex);
            }
        }

        #endregion
    }
}
