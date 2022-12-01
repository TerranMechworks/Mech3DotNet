using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public enum GravityMode
    {
        Local,
        Complex,
        NoAltitude,
    }

    public static class GravityModeConverter
    {
        public static readonly TypeConverter<GravityMode> Converter = new TypeConverter<GravityMode>(Deserialize, Serialize);

        private static void Serialize(GravityMode v, Serializer s)
        {
            uint variantIndex = v switch
            {
                GravityMode.Local => 0,
                GravityMode.Complex => 1,
                GravityMode.NoAltitude => 2,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static GravityMode Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("GravityMode");
            return variantIndex switch
            {
                0 => GravityMode.Local,
                1 => GravityMode.Complex,
                2 => GravityMode.NoAltitude,
                _ => throw new UnknownVariantException("GravityMode", variantIndex),
            };
        }
    }
}
