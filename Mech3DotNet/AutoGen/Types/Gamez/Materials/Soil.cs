using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Materials
{
    public enum Soil
    {
        Default,
        Water,
        Seafloor,
        Quicksand,
        Lava,
        Fire,
        Dirt,
        Mud,
        Grass,
        Concrete,
        Snow,
        Mech,
        Silt,
        NoSlip,
    }

    public static class SoilConverter
    {
        public static readonly TypeConverter<Soil> Converter = new TypeConverter<Soil>(Deserialize, Serialize);

        private static void Serialize(Soil v, Serializer s)
        {
            uint variantIndex = v switch
            {
                Soil.Default => 0,
                Soil.Water => 1,
                Soil.Seafloor => 2,
                Soil.Quicksand => 3,
                Soil.Lava => 4,
                Soil.Fire => 5,
                Soil.Dirt => 6,
                Soil.Mud => 7,
                Soil.Grass => 8,
                Soil.Concrete => 9,
                Soil.Snow => 10,
                Soil.Mech => 11,
                Soil.Silt => 12,
                Soil.NoSlip => 13,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static Soil Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("Soil");
            return variantIndex switch
            {
                0 => Soil.Default,
                1 => Soil.Water,
                2 => Soil.Seafloor,
                3 => Soil.Quicksand,
                4 => Soil.Lava,
                5 => Soil.Fire,
                6 => Soil.Dirt,
                7 => Soil.Mud,
                8 => Soil.Grass,
                9 => Soil.Concrete,
                10 => Soil.Snow,
                11 => Soil.Mech,
                12 => Soil.Silt,
                13 => Soil.NoSlip,
                _ => throw new UnknownVariantException("Soil", variantIndex),
            };
        }
    }
}
