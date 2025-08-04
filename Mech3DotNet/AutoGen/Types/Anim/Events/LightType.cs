using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public enum LightType
    {
        Directed,
        PointSource,
    }

    public static class LightTypeConverter
    {
        public static readonly TypeConverter<LightType> Converter = new TypeConverter<LightType>(Deserialize, Serialize);

        private static void Serialize(LightType v, Serializer s)
        {
            uint variantIndex = v switch
            {
                LightType.Directed => 0,
                LightType.PointSource => 1,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static LightType Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("LightType");
            return variantIndex switch
            {
                0 => LightType.Directed,
                1 => LightType.PointSource,
                _ => throw new UnknownVariantException("LightType", variantIndex),
            };
        }
    }
}
