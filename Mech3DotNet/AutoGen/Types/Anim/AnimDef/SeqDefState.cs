using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.AnimDef
{
    public enum SeqDefState
    {
        Initial,
        OnCall,
    }

    public static class SeqDefStateConverter
    {
        public static readonly TypeConverter<SeqDefState> Converter = new TypeConverter<SeqDefState>(Deserialize, Serialize);

        private static void Serialize(SeqDefState v, Serializer s)
        {
            uint variantIndex = v switch
            {
                SeqDefState.Initial => 0,
                SeqDefState.OnCall => 3,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static SeqDefState Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("SeqDefState");
            return variantIndex switch
            {
                0 => SeqDefState.Initial,
                3 => SeqDefState.OnCall,
                _ => throw new UnknownVariantException("SeqDefState", variantIndex),
            };
        }
    }
}
