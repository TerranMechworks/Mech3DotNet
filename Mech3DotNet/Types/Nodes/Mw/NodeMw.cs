using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Mw
{
    public sealed class NodeMw
    {
        public static readonly TypeConverter<NodeMw> Converter = new TypeConverter<NodeMw>(Deserialize, Serialize);

        public enum Variants
        {
            Camera,
            Display,
            Empty,
            Light,
            Lod,
            Object3d,
            Window,
            World,
        }

        private NodeMw(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static NodeMw Camera(Mech3DotNet.Types.Nodes.Camera value) => new NodeMw(Variants.Camera, value);

        public static NodeMw Display(Mech3DotNet.Types.Nodes.Display value) => new NodeMw(Variants.Display, value);

        public static NodeMw Empty(Mech3DotNet.Types.Nodes.Mw.Empty value) => new NodeMw(Variants.Empty, value);

        public static NodeMw Light(Mech3DotNet.Types.Nodes.Mw.Light value) => new NodeMw(Variants.Light, value);

        public static NodeMw Lod(Mech3DotNet.Types.Nodes.Mw.Lod value) => new NodeMw(Variants.Lod, value);

        public static NodeMw Object3d(Mech3DotNet.Types.Nodes.Mw.Object3d value) => new NodeMw(Variants.Object3d, value);

        public static NodeMw Window(Mech3DotNet.Types.Nodes.Window value) => new NodeMw(Variants.Window, value);

        public static NodeMw World(Mech3DotNet.Types.Nodes.Mw.World value) => new NodeMw(Variants.World, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsCamera() => Variant == Variants.Camera;
        public Mech3DotNet.Types.Nodes.Camera AsCamera() => (Mech3DotNet.Types.Nodes.Camera)Value;
        public bool IsDisplay() => Variant == Variants.Display;
        public Mech3DotNet.Types.Nodes.Display AsDisplay() => (Mech3DotNet.Types.Nodes.Display)Value;
        public bool IsEmpty() => Variant == Variants.Empty;
        public Mech3DotNet.Types.Nodes.Mw.Empty AsEmpty() => (Mech3DotNet.Types.Nodes.Mw.Empty)Value;
        public bool IsLight() => Variant == Variants.Light;
        public Mech3DotNet.Types.Nodes.Mw.Light AsLight() => (Mech3DotNet.Types.Nodes.Mw.Light)Value;
        public bool IsLod() => Variant == Variants.Lod;
        public Mech3DotNet.Types.Nodes.Mw.Lod AsLod() => (Mech3DotNet.Types.Nodes.Mw.Lod)Value;
        public bool IsObject3d() => Variant == Variants.Object3d;
        public Mech3DotNet.Types.Nodes.Mw.Object3d AsObject3d() => (Mech3DotNet.Types.Nodes.Mw.Object3d)Value;
        public bool IsWindow() => Variant == Variants.Window;
        public Mech3DotNet.Types.Nodes.Window AsWindow() => (Mech3DotNet.Types.Nodes.Window)Value;
        public bool IsWorld() => Variant == Variants.World;
        public Mech3DotNet.Types.Nodes.Mw.World AsWorld() => (Mech3DotNet.Types.Nodes.Mw.World)Value;

        private static void Serialize(NodeMw v, Serializer s)
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

                case Variants.Empty: // 2
                    {
                        var inner = v.AsEmpty();
                        s.SerializeNewTypeVariant(2);
                        s.Serialize(Mech3DotNet.Types.Nodes.Mw.Empty.Converter)(inner);
                        break;
                    }

                case Variants.Light: // 3
                    {
                        var inner = v.AsLight();
                        s.SerializeNewTypeVariant(3);
                        s.Serialize(Mech3DotNet.Types.Nodes.Mw.Light.Converter)(inner);
                        break;
                    }

                case Variants.Lod: // 4
                    {
                        var inner = v.AsLod();
                        s.SerializeNewTypeVariant(4);
                        s.Serialize(Mech3DotNet.Types.Nodes.Mw.Lod.Converter)(inner);
                        break;
                    }

                case Variants.Object3d: // 5
                    {
                        var inner = v.AsObject3d();
                        s.SerializeNewTypeVariant(5);
                        s.Serialize(Mech3DotNet.Types.Nodes.Mw.Object3d.Converter)(inner);
                        break;
                    }

                case Variants.Window: // 6
                    {
                        var inner = v.AsWindow();
                        s.SerializeNewTypeVariant(6);
                        s.Serialize(Mech3DotNet.Types.Nodes.Window.Converter)(inner);
                        break;
                    }

                case Variants.World: // 7
                    {
                        var inner = v.AsWorld();
                        s.SerializeNewTypeVariant(7);
                        s.Serialize(Mech3DotNet.Types.Nodes.Mw.World.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static NodeMw Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Camera
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeMw", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Camera.Converter)();
                        return NodeMw.Camera(inner);
                    }

                case 1: // Display
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeMw", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Display.Converter)();
                        return NodeMw.Display(inner);
                    }

                case 2: // Empty
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeMw", 2, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Mw.Empty.Converter)();
                        return NodeMw.Empty(inner);
                    }

                case 3: // Light
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeMw", 3, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Mw.Light.Converter)();
                        return NodeMw.Light(inner);
                    }

                case 4: // Lod
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeMw", 4, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Mw.Lod.Converter)();
                        return NodeMw.Lod(inner);
                    }

                case 5: // Object3d
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeMw", 5, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Mw.Object3d.Converter)();
                        return NodeMw.Object3d(inner);
                    }

                case 6: // Window
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeMw", 6, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Window.Converter)();
                        return NodeMw.Window(inner);
                    }

                case 7: // World
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeMw", 7, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Mw.World.Converter)();
                        return NodeMw.World(inner);
                    }

                default:
                    throw new UnknownVariantException("NodeMw", variantIndex);
            }
        }
    }
}
