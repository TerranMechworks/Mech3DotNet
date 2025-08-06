using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Translate
    {
        public static readonly TypeConverter<Translate> Converter = new TypeConverter<Translate>(Deserialize, Serialize);

        public enum Variants
        {
            Absolute,
            AtNode,
        }

        private Translate(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static Translate Absolute(Mech3DotNet.Types.Common.Vec3 value) => new Translate(Variants.Absolute, value);

        public static Translate AtNode(Mech3DotNet.Types.Anim.Events.AtNode value) => new Translate(Variants.AtNode, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsAbsolute() => Variant == Variants.Absolute;
        public Mech3DotNet.Types.Common.Vec3 AsAbsolute() => (Mech3DotNet.Types.Common.Vec3)Value;
        public bool IsAtNode() => Variant == Variants.AtNode;
        public Mech3DotNet.Types.Anim.Events.AtNode AsAtNode() => (Mech3DotNet.Types.Anim.Events.AtNode)Value;

        #region "Serialize/Deserialize logic"

        private static void Serialize(Translate v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Absolute: // 0
                    {
                        var inner = v.AsAbsolute();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(inner);
                        break;
                    }

                case Variants.AtNode: // 1
                    {
                        var inner = v.AsAtNode();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static Translate Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Absolute
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Translate", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        return Translate.Absolute(inner);
                    }

                case 1: // AtNode
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("Translate", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter)();
                        return Translate.AtNode(inner);
                    }

                default:
                    throw new UnknownVariantException("Translate", variantIndex);
            }
        }

        #endregion
    }
}
