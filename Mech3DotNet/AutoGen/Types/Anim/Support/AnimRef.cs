using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Support
{
    public sealed class AnimRef
    {
        public static readonly TypeConverter<AnimRef> Converter = new TypeConverter<AnimRef>(Deserialize, Serialize);

        public enum Variants
        {
            CallAnimation,
            CallObjectConnector,
        }

        private AnimRef(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static AnimRef CallAnimation(Mech3DotNet.Types.Anim.Support.AnimRefCallAnimation value) => new AnimRef(Variants.CallAnimation, value);

        public static AnimRef CallObjectConnector(Mech3DotNet.Types.Anim.Support.AnimRefCallObjectConnector value) => new AnimRef(Variants.CallObjectConnector, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsCallAnimation() => Variant == Variants.CallAnimation;
        public Mech3DotNet.Types.Anim.Support.AnimRefCallAnimation AsCallAnimation() => (Mech3DotNet.Types.Anim.Support.AnimRefCallAnimation)Value;
        public bool IsCallObjectConnector() => Variant == Variants.CallObjectConnector;
        public Mech3DotNet.Types.Anim.Support.AnimRefCallObjectConnector AsCallObjectConnector() => (Mech3DotNet.Types.Anim.Support.AnimRefCallObjectConnector)Value;

        private static void Serialize(AnimRef v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.CallAnimation: // 0
                    {
                        var inner = v.AsCallAnimation();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Anim.Support.AnimRefCallAnimation.Converter)(inner);
                        break;
                    }

                case Variants.CallObjectConnector: // 1
                    {
                        var inner = v.AsCallObjectConnector();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Anim.Support.AnimRefCallObjectConnector.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static AnimRef Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // CallAnimation
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("AnimRef", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Support.AnimRefCallAnimation.Converter)();
                        return AnimRef.CallAnimation(inner);
                    }

                case 1: // CallObjectConnector
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("AnimRef", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Support.AnimRefCallObjectConnector.Converter)();
                        return AnimRef.CallObjectConnector(inner);
                    }

                default:
                    throw new UnknownVariantException("AnimRef", variantIndex);
            }
        }
    }
}
