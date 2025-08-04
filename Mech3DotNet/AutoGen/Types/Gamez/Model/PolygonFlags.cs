using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Model
{
    [System.Flags]
    public enum PolygonFlags : uint
    {
        None = 0u,
        ShowBackface = 1u << 0,
        TriStrip = 1u << 1,
        Unk3 = 1u << 2,
        InOut = 1u << 3,
    }

    public static class PolygonFlagsConverter
    {
        public static readonly TypeConverter<PolygonFlags> Converter = new TypeConverter<PolygonFlags>(Deserialize, Serialize);

        private const PolygonFlags VALID = (PolygonFlags)(0u | 1u << 0 | 1u << 1 | 1u << 2 | 1u << 3);

        private static void Serialize(PolygonFlags v, Serializer s)
        {
            if ((v & ~VALID) != 0)
                throw new System.ArgumentOutOfRangeException();
            s.SerializeU32((uint)v);
        }

        private static PolygonFlags Deserialize(Deserializer d)
        {
            return (PolygonFlags)d.DeserializeU32();
        }
    }
}
