using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public enum SeqActivation
    {
        Initial,
        OnCall,
    }

    public static class SeqActivationConverter
    {
        public static readonly TypeConverter<SeqActivation> Converter = new TypeConverter<SeqActivation>(Deserialize, Serialize);

        private static void Serialize(SeqActivation v, Serializer s)
        {
            uint variantIndex = v switch
            {
                SeqActivation.Initial => 0,
                SeqActivation.OnCall => 1,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static SeqActivation Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("SeqActivation");
            return variantIndex switch
            {
                0 => SeqActivation.Initial,
                1 => SeqActivation.OnCall,
                _ => throw new UnknownVariantException("SeqActivation", variantIndex),
            };
        }
    }
}
