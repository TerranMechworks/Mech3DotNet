using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CallAnimationParameters
    {
        public static readonly TypeConverter<CallAnimationParameters> Converter = new TypeConverter<CallAnimationParameters>(Deserialize, Serialize);

        public enum Variants
        {
            AtNode,
            WithNode,
        }

        private CallAnimationParameters(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static CallAnimationParameters AtNode(Mech3DotNet.Types.Anim.Events.CallAnimationAtNode value) => new CallAnimationParameters(Variants.AtNode, value);

        public static CallAnimationParameters WithNode(Mech3DotNet.Types.Anim.Events.CallAnimationWithNode value) => new CallAnimationParameters(Variants.WithNode, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsAtNode() => Variant == Variants.AtNode;
        public Mech3DotNet.Types.Anim.Events.CallAnimationAtNode AsAtNode() => (Mech3DotNet.Types.Anim.Events.CallAnimationAtNode)Value;
        public bool IsWithNode() => Variant == Variants.WithNode;
        public Mech3DotNet.Types.Anim.Events.CallAnimationWithNode AsWithNode() => (Mech3DotNet.Types.Anim.Events.CallAnimationWithNode)Value;

        private static void Serialize(CallAnimationParameters v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.AtNode: // 0
                    {
                        var inner = v.AsAtNode();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.CallAnimationAtNode.Converter)(inner);
                        break;
                    }

                case Variants.WithNode: // 1
                    {
                        var inner = v.AsWithNode();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.CallAnimationWithNode.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static CallAnimationParameters Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // AtNode
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("CallAnimationParameters", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.CallAnimationAtNode.Converter)();
                        return CallAnimationParameters.AtNode(inner);
                    }

                case 1: // WithNode
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("CallAnimationParameters", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.CallAnimationWithNode.Converter)();
                        return CallAnimationParameters.WithNode(inner);
                    }

                default:
                    throw new UnknownVariantException("CallAnimationParameters", variantIndex);
            }
        }
    }
}
