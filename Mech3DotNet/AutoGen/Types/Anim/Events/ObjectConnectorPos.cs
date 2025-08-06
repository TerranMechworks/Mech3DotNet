using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectConnectorPos
    {
        public static readonly TypeConverter<ObjectConnectorPos> Converter = new TypeConverter<ObjectConnectorPos>(Deserialize, Serialize);

        public enum Variants
        {
            Pos,
            Input,
        }

        private ObjectConnectorPos(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static ObjectConnectorPos Pos(Mech3DotNet.Types.Common.Vec3 value) => new ObjectConnectorPos(Variants.Pos, value);

        public static readonly ObjectConnectorPos Input = new ObjectConnectorPos(Variants.Input, new object());

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsPos() => Variant == Variants.Pos;
        public Mech3DotNet.Types.Common.Vec3 AsPos() => (Mech3DotNet.Types.Common.Vec3)Value;
        public bool IsInput() => Variant == Variants.Input;

        #region "Serialize/Deserialize logic"

        private static void Serialize(ObjectConnectorPos v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Pos: // 0
                    {
                        var inner = v.AsPos();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(inner);
                        break;
                    }

                case Variants.Input: // 1
                    {
                        s.SerializeUnitVariant(1);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static ObjectConnectorPos Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Pos
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ObjectConnectorPos", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        return ObjectConnectorPos.Pos(inner);
                    }

                case 1: // Input
                    {
                        if (enumType != EnumType.Unit)
                            throw new InvalidVariantException("ObjectConnectorPos", 1, EnumType.Unit, enumType);
                        return ObjectConnectorPos.Input;
                    }

                default:
                    throw new UnknownVariantException("ObjectConnectorPos", variantIndex);
            }
        }

        #endregion
    }
}
