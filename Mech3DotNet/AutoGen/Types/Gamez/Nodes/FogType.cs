using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public enum FogType
    {
        Off,
        Linear,
        Exponential,
    }

    public static class FogTypeConverter
    {
        public static readonly TypeConverter<FogType> Converter = new TypeConverter<FogType>(Deserialize, Serialize);

        private static void Serialize(FogType v, Serializer s)
        {
            uint variantIndex = v switch
            {
                FogType.Off => 0,
                FogType.Linear => 1,
                FogType.Exponential => 2,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static FogType Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("FogType");
            return variantIndex switch
            {
                0 => FogType.Off,
                1 => FogType.Linear,
                2 => FogType.Exponential,
                _ => throw new UnknownVariantException("FogType", variantIndex),
            };
        }
    }
}
