using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Model
{
    public enum ModelType
    {
        Default,
        Facade,
        Points,
    }

    public static class ModelTypeConverter
    {
        public static readonly TypeConverter<ModelType> Converter = new TypeConverter<ModelType>(Deserialize, Serialize);

        private static void Serialize(ModelType v, Serializer s)
        {
            uint variantIndex = v switch
            {
                ModelType.Default => 0,
                ModelType.Facade => 1,
                ModelType.Points => 2,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static ModelType Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("ModelType");
            return variantIndex switch
            {
                0 => ModelType.Default,
                1 => ModelType.Facade,
                2 => ModelType.Points,
                _ => throw new UnknownVariantException("ModelType", variantIndex),
            };
        }
    }
}
