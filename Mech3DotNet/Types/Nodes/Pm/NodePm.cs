using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Pm
{
    public sealed class NodePm
    {
        public static readonly TypeConverter<NodePm> Converter = new TypeConverter<NodePm>(Deserialize, Serialize);

        public enum Variants
        {
            Camera,
            Display,
            Light,
            Lod,
            Object3d,
            Window,
            World,
        }

        private NodePm(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static NodePm Camera(Mech3DotNet.Types.Nodes.Camera value) => new NodePm(Variants.Camera, value);

        public static NodePm Display(Mech3DotNet.Types.Nodes.Display value) => new NodePm(Variants.Display, value);

        public static NodePm Light(Mech3DotNet.Types.Nodes.Pm.Light value) => new NodePm(Variants.Light, value);

        public static NodePm Lod(Mech3DotNet.Types.Nodes.Pm.Lod value) => new NodePm(Variants.Lod, value);

        public static NodePm Object3d(Mech3DotNet.Types.Nodes.Pm.Object3d value) => new NodePm(Variants.Object3d, value);

        public static NodePm Window(Mech3DotNet.Types.Nodes.Window value) => new NodePm(Variants.Window, value);

        public static NodePm World(Mech3DotNet.Types.Nodes.Pm.World value) => new NodePm(Variants.World, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsCamera() => Variant == Variants.Camera;
        public Mech3DotNet.Types.Nodes.Camera AsCamera() => (Mech3DotNet.Types.Nodes.Camera)Value;
        public bool IsDisplay() => Variant == Variants.Display;
        public Mech3DotNet.Types.Nodes.Display AsDisplay() => (Mech3DotNet.Types.Nodes.Display)Value;
        public bool IsLight() => Variant == Variants.Light;
        public Mech3DotNet.Types.Nodes.Pm.Light AsLight() => (Mech3DotNet.Types.Nodes.Pm.Light)Value;
        public bool IsLod() => Variant == Variants.Lod;
        public Mech3DotNet.Types.Nodes.Pm.Lod AsLod() => (Mech3DotNet.Types.Nodes.Pm.Lod)Value;
        public bool IsObject3d() => Variant == Variants.Object3d;
        public Mech3DotNet.Types.Nodes.Pm.Object3d AsObject3d() => (Mech3DotNet.Types.Nodes.Pm.Object3d)Value;
        public bool IsWindow() => Variant == Variants.Window;
        public Mech3DotNet.Types.Nodes.Window AsWindow() => (Mech3DotNet.Types.Nodes.Window)Value;
        public bool IsWorld() => Variant == Variants.World;
        public Mech3DotNet.Types.Nodes.Pm.World AsWorld() => (Mech3DotNet.Types.Nodes.Pm.World)Value;

        private static void Serialize(NodePm v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Camera: // 0
                    {
                        var inner = v.AsCamera();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Nodes.Camera.Converter)(inner);
                        break;
                    }

                case Variants.Display: // 1
                    {
                        var inner = v.AsDisplay();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Nodes.Display.Converter)(inner);
                        break;
                    }

                case Variants.Light: // 2
                    {
                        var inner = v.AsLight();
                        s.SerializeNewTypeVariant(2);
                        s.Serialize(Mech3DotNet.Types.Nodes.Pm.Light.Converter)(inner);
                        break;
                    }

                case Variants.Lod: // 3
                    {
                        var inner = v.AsLod();
                        s.SerializeNewTypeVariant(3);
                        s.Serialize(Mech3DotNet.Types.Nodes.Pm.Lod.Converter)(inner);
                        break;
                    }

                case Variants.Object3d: // 4
                    {
                        var inner = v.AsObject3d();
                        s.SerializeNewTypeVariant(4);
                        s.Serialize(Mech3DotNet.Types.Nodes.Pm.Object3d.Converter)(inner);
                        break;
                    }

                case Variants.Window: // 5
                    {
                        var inner = v.AsWindow();
                        s.SerializeNewTypeVariant(5);
                        s.Serialize(Mech3DotNet.Types.Nodes.Window.Converter)(inner);
                        break;
                    }

                case Variants.World: // 6
                    {
                        var inner = v.AsWorld();
                        s.SerializeNewTypeVariant(6);
                        s.Serialize(Mech3DotNet.Types.Nodes.Pm.World.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static NodePm Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Camera
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodePm", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Camera.Converter)();
                        return NodePm.Camera(inner);
                    }

                case 1: // Display
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodePm", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Display.Converter)();
                        return NodePm.Display(inner);
                    }

                case 2: // Light
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodePm", 2, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Pm.Light.Converter)();
                        return NodePm.Light(inner);
                    }

                case 3: // Lod
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodePm", 3, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Pm.Lod.Converter)();
                        return NodePm.Lod(inner);
                    }

                case 4: // Object3d
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodePm", 4, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Pm.Object3d.Converter)();
                        return NodePm.Object3d(inner);
                    }

                case 5: // Window
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodePm", 5, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Window.Converter)();
                        return NodePm.Window(inner);
                    }

                case 6: // World
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodePm", 6, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Pm.World.Converter)();
                        return NodePm.World(inner);
                    }

                default:
                    throw new UnknownVariantException("NodePm", variantIndex);
            }
        }
    }
}
