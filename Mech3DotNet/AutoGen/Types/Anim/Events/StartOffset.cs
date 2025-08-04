using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public enum StartOffset
    {
        Animation,
        Sequence,
        Event,
    }

    public static class StartOffsetConverter
    {
        public static readonly TypeConverter<StartOffset> Converter = new TypeConverter<StartOffset>(Deserialize, Serialize);

        private static void Serialize(StartOffset v, Serializer s)
        {
            uint variantIndex = v switch
            {
                StartOffset.Animation => 1,
                StartOffset.Sequence => 2,
                StartOffset.Event => 3,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static StartOffset Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("StartOffset");
            return variantIndex switch
            {
                1 => StartOffset.Animation,
                2 => StartOffset.Sequence,
                3 => StartOffset.Event,
                _ => throw new UnknownVariantException("StartOffset", variantIndex),
            };
        }
    }
}
