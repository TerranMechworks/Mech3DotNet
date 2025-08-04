using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Model
{
    public enum FacadeMode
    {
        CylindricalY,
        SphericalY,
        CylindricalX,
        CylindricalZ,
    }

    public static class FacadeModeConverter
    {
        public static readonly TypeConverter<FacadeMode> Converter = new TypeConverter<FacadeMode>(Deserialize, Serialize);

        private static void Serialize(FacadeMode v, Serializer s)
        {
            uint variantIndex = v switch
            {
                FacadeMode.CylindricalY => 0,
                FacadeMode.SphericalY => 1,
                FacadeMode.CylindricalX => 2,
                FacadeMode.CylindricalZ => 3,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static FacadeMode Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("FacadeMode");
            return variantIndex switch
            {
                0 => FacadeMode.CylindricalY,
                1 => FacadeMode.SphericalY,
                2 => FacadeMode.CylindricalX,
                3 => FacadeMode.CylindricalZ,
                _ => throw new UnknownVariantException("FacadeMode", variantIndex),
            };
        }
    }
}
