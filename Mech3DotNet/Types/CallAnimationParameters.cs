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
            TargetNode,
            None,
        }

        private CallAnimationParameters(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static CallAnimationParameters AtNode(Mech3DotNet.Types.Anim.Events.CallAnimationAtNode value) => new CallAnimationParameters(Variants.AtNode, value);

        public static CallAnimationParameters WithNode(Mech3DotNet.Types.Anim.Events.CallAnimationWithNode value) => new CallAnimationParameters(Variants.WithNode, value);

        public static CallAnimationParameters TargetNode(Mech3DotNet.Types.Anim.Events.CallAnimationTargetNode value) => new CallAnimationParameters(Variants.TargetNode, value);

        public static readonly CallAnimationParameters None = new CallAnimationParameters(Variants.None, new object());

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsAtNode() => Variant == Variants.AtNode;
        public Mech3DotNet.Types.Anim.Events.CallAnimationAtNode AsAtNode() => (Mech3DotNet.Types.Anim.Events.CallAnimationAtNode)Value;
        public bool IsWithNode() => Variant == Variants.WithNode;
        public Mech3DotNet.Types.Anim.Events.CallAnimationWithNode AsWithNode() => (Mech3DotNet.Types.Anim.Events.CallAnimationWithNode)Value;
        public bool IsTargetNode() => Variant == Variants.TargetNode;
        public Mech3DotNet.Types.Anim.Events.CallAnimationTargetNode AsTargetNode() => (Mech3DotNet.Types.Anim.Events.CallAnimationTargetNode)Value;
        public bool IsNone() => Variant == Variants.None;

        private static void Serialize(CallAnimationParameters v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.AtNode: // 0
                    {
                        var inner = v.AsAtNode();
                        s.SerializeNewTypeVariant("CallAnimationParameters", 0);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.CallAnimationAtNode.Converter)(inner);
                        break;
                    }

                case Variants.WithNode: // 1
                    {
                        var inner = v.AsWithNode();
                        s.SerializeNewTypeVariant("CallAnimationParameters", 1);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.CallAnimationWithNode.Converter)(inner);
                        break;
                    }

                case Variants.TargetNode: // 2
                    {
                        var inner = v.AsTargetNode();
                        s.SerializeNewTypeVariant("CallAnimationParameters", 2);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.CallAnimationTargetNode.Converter)(inner);
                        break;
                    }

                case Variants.None: // 3
                    {
                        s.SerializeUnitVariant("CallAnimationParameters", 3);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static CallAnimationParameters Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum("CallAnimationParameters");
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

                case 2: // TargetNode
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("CallAnimationParameters", 2, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.CallAnimationTargetNode.Converter)();
                        return CallAnimationParameters.TargetNode(inner);
                    }

                case 3: // None
                    {
                        if (enumType != EnumType.Unit)
                            throw new InvalidVariantException("CallAnimationParameters", 3, EnumType.Unit, enumType);
                        return CallAnimationParameters.None;
                    }

                default:
                    throw new UnknownVariantException("CallAnimationParameters", variantIndex);
            }
        }
    }
}
