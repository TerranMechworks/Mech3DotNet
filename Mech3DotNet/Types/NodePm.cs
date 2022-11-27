using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Pm
{
    public sealed class NodePm
    {
        public static readonly TypeConverter<NodePm> Converter = new TypeConverter<NodePm>(Deserialize, Serialize);

        public enum Variants
        {
            Lod,
            Object3d,
        }

        private NodePm(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static NodePm Lod(Mech3DotNet.Types.Nodes.Pm.LodPm value) => new NodePm(Variants.Lod, value);

        public static NodePm Object3d(Mech3DotNet.Types.Nodes.Pm.Object3dPm value) => new NodePm(Variants.Object3d, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsLod() => Variant == Variants.Lod;
        public Mech3DotNet.Types.Nodes.Pm.LodPm AsLod() => (Mech3DotNet.Types.Nodes.Pm.LodPm)Value;
        public bool IsObject3d() => Variant == Variants.Object3d;
        public Mech3DotNet.Types.Nodes.Pm.Object3dPm AsObject3d() => (Mech3DotNet.Types.Nodes.Pm.Object3dPm)Value;

        private static void Serialize(NodePm v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Lod: // 0
                    {
                        var inner = v.AsLod();
                        s.SerializeNewTypeVariant("NodePm", 0);
                        s.Serialize(Mech3DotNet.Types.Nodes.Pm.LodPm.Converter)(inner);
                        break;
                    }

                case Variants.Object3d: // 1
                    {
                        var inner = v.AsObject3d();
                        s.SerializeNewTypeVariant("NodePm", 1);
                        s.Serialize(Mech3DotNet.Types.Nodes.Pm.Object3dPm.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static NodePm Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum("NodePm");
            switch (variantIndex)
            {
                case 0: // Lod
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodePm", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Pm.LodPm.Converter)();
                        return NodePm.Lod(inner);
                    }

                case 1: // Object3d
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodePm", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Pm.Object3dPm.Converter)();
                        return NodePm.Object3d(inner);
                    }

                default:
                    throw new UnknownVariantException("NodePm", variantIndex);
            }
        }
    }
}
