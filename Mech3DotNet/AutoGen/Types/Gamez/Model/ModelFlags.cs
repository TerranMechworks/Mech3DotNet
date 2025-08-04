using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Model
{
    [System.Flags]
    public enum ModelFlags : uint
    {
        None = 0u,
        Lighting = 1u << 0,
        Fog = 1u << 2,
        TextureRegistered = 1u << 3,
        Morph = 1u << 4,
        TextureScroll = 1u << 5,
        Clouds = 1u << 6,
        FacadeCentroid = 1u << 7,
    }

    public static class ModelFlagsConverter
    {
        public static readonly TypeConverter<ModelFlags> Converter = new TypeConverter<ModelFlags>(Deserialize, Serialize);

        private const ModelFlags VALID = (ModelFlags)(0u | 1u << 0 | 1u << 2 | 1u << 3 | 1u << 4 | 1u << 5 | 1u << 6 | 1u << 7);

        private static void Serialize(ModelFlags v, Serializer s)
        {
            if ((v & ~VALID) != 0)
                throw new System.ArgumentOutOfRangeException();
            s.SerializeU32((uint)v);
        }

        private static ModelFlags Deserialize(Deserializer d)
        {
            return (ModelFlags)d.DeserializeU32();
        }
    }
}
