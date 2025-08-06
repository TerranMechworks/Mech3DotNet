using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ForwardRotation
    {
        public static readonly TypeConverter<ForwardRotation> Converter = new TypeConverter<ForwardRotation>(Deserialize, Serialize);

        public enum Variants
        {
            Time,
            Distance,
        }

        private ForwardRotation(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static ForwardRotation Time(Mech3DotNet.Types.Anim.Events.ForwardRotationTime value) => new ForwardRotation(Variants.Time, value);

        public static ForwardRotation Distance(Mech3DotNet.Types.Anim.Events.ForwardRotationDistance value) => new ForwardRotation(Variants.Distance, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsTime() => Variant == Variants.Time;
        public Mech3DotNet.Types.Anim.Events.ForwardRotationTime AsTime() => (Mech3DotNet.Types.Anim.Events.ForwardRotationTime)Value;
        public bool IsDistance() => Variant == Variants.Distance;
        public Mech3DotNet.Types.Anim.Events.ForwardRotationDistance AsDistance() => (Mech3DotNet.Types.Anim.Events.ForwardRotationDistance)Value;

        #region "Serialize/Deserialize logic"

        private static void Serialize(ForwardRotation v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Time: // 0
                    {
                        var inner = v.AsTime();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ForwardRotationTime.Converter)(inner);
                        break;
                    }

                case Variants.Distance: // 1
                    {
                        var inner = v.AsDistance();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ForwardRotationDistance.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static ForwardRotation Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Time
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ForwardRotation", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ForwardRotationTime.Converter)();
                        return ForwardRotation.Time(inner);
                    }

                case 1: // Distance
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("ForwardRotation", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ForwardRotationDistance.Converter)();
                        return ForwardRotation.Distance(inner);
                    }

                default:
                    throw new UnknownVariantException("ForwardRotation", variantIndex);
            }
        }

        #endregion
    }
}
