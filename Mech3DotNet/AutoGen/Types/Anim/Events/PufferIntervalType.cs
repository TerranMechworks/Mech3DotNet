using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public enum PufferIntervalType
    {
        Time,
        Distance,
    }

    public static class PufferIntervalTypeConverter
    {
        public static readonly TypeConverter<PufferIntervalType> Converter = new TypeConverter<PufferIntervalType>(Deserialize, Serialize);

        private static void Serialize(PufferIntervalType v, Serializer s)
        {
            uint variantIndex = v switch
            {
                PufferIntervalType.Time => 1,
                PufferIntervalType.Distance => 2,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static PufferIntervalType Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("PufferIntervalType");
            return variantIndex switch
            {
                1 => PufferIntervalType.Time,
                2 => PufferIntervalType.Distance,
                _ => throw new UnknownVariantException("PufferIntervalType", variantIndex),
            };
        }
    }
}
