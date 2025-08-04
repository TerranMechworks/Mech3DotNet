using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public enum ActiveBoundingBox
    {
        Node,
        Model,
        Child,
    }

    public static class ActiveBoundingBoxConverter
    {
        public static readonly TypeConverter<ActiveBoundingBox> Converter = new TypeConverter<ActiveBoundingBox>(Deserialize, Serialize);

        private static void Serialize(ActiveBoundingBox v, Serializer s)
        {
            uint variantIndex = v switch
            {
                ActiveBoundingBox.Node => 0,
                ActiveBoundingBox.Model => 1,
                ActiveBoundingBox.Child => 2,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static ActiveBoundingBox Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("ActiveBoundingBox");
            return variantIndex switch
            {
                0 => ActiveBoundingBox.Node,
                1 => ActiveBoundingBox.Model,
                2 => ActiveBoundingBox.Child,
                _ => throw new UnknownVariantException("ActiveBoundingBox", variantIndex),
            };
        }
    }
}
