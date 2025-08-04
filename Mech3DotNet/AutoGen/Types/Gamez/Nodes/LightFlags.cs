using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    [System.Flags]
    public enum LightFlags : uint
    {
        None = 0u,
        Recalc = 1u << 0,
        Unk1 = 1u << 1,
        Directional = 1u << 2,
        DirectedSource = 1u << 3,
        PointSource = 1u << 4,
        Saturated = 1u << 5,
        Subdivide = 1u << 6,
        Static = 1u << 7,
        Color = 1u << 8,
        Unk9 = 1u << 9,
        LightMap = 1u << 10,
        Bicolored = 1u << 11,
    }

    public static class LightFlagsConverter
    {
        public static readonly TypeConverter<LightFlags> Converter = new TypeConverter<LightFlags>(Deserialize, Serialize);

        private const LightFlags VALID = (LightFlags)(0u | 1u << 0 | 1u << 1 | 1u << 2 | 1u << 3 | 1u << 4 | 1u << 5 | 1u << 6 | 1u << 7 | 1u << 8 | 1u << 9 | 1u << 10 | 1u << 11);

        private static void Serialize(LightFlags v, Serializer s)
        {
            if ((v & ~VALID) != 0)
                throw new System.ArgumentOutOfRangeException();
            s.SerializeU32((uint)v);
        }

        private static LightFlags Deserialize(Deserializer d)
        {
            return (LightFlags)d.DeserializeU32();
        }
    }
}
