using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    [System.Flags]
    public enum NodeFlags : uint
    {
        None = 0u,
        Active = 1u << 2,
        AltitudeSurface = 1u << 3,
        IntersectSurface = 1u << 4,
        IntersectBbox = 1u << 5,
        Proximity = 1u << 6,
        Landmark = 1u << 7,
        BboxNode = 1u << 8,
        BboxModel = 1u << 9,
        BboxChild = 1u << 10,
        Terrain = 1u << 15,
        CanModify = 1u << 16,
        ClipTo = 1u << 17,
        TreeValid = 1u << 19,
        Override = 1u << 23,
        IdZoneCheck = 1u << 24,
        Unk25 = 1u << 25,
        Unk28 = 1u << 28,
    }

    public static class NodeFlagsConverter
    {
        public static readonly TypeConverter<NodeFlags> Converter = new TypeConverter<NodeFlags>(Deserialize, Serialize);

        private const NodeFlags VALID = (NodeFlags)(0u | 1u << 2 | 1u << 3 | 1u << 4 | 1u << 5 | 1u << 6 | 1u << 7 | 1u << 8 | 1u << 9 | 1u << 10 | 1u << 15 | 1u << 16 | 1u << 17 | 1u << 19 | 1u << 23 | 1u << 24 | 1u << 25 | 1u << 28);

        private static void Serialize(NodeFlags v, Serializer s)
        {
            if ((v & ~VALID) != 0)
                throw new System.ArgumentOutOfRangeException();
            s.SerializeU32((uint)v);
        }

        private static NodeFlags Deserialize(Deserializer d)
        {
            return (NodeFlags)d.DeserializeU32();
        }
    }
}
