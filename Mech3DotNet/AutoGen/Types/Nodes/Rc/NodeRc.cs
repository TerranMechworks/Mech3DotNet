using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Rc
{
    public sealed class NodeRc
    {
        public static readonly TypeConverter<NodeRc> Converter = new TypeConverter<NodeRc>(Deserialize, Serialize);

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

        private NodeRc(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static NodeRc Camera(Mech3DotNet.Types.Nodes.Camera value) => new NodeRc(Variants.Camera, value);

        public static NodeRc Display(Mech3DotNet.Types.Nodes.Display value) => new NodeRc(Variants.Display, value);

        public static NodeRc Empty(Mech3DotNet.Types.Nodes.Rc.Empty value) => new NodeRc(Variants.Empty, value);

        public static NodeRc Light(Mech3DotNet.Types.Nodes.Rc.Light value) => new NodeRc(Variants.Light, value);

        public static NodeRc Lod(Mech3DotNet.Types.Nodes.Rc.Lod value) => new NodeRc(Variants.Lod, value);

        public static NodeRc Object3d(Mech3DotNet.Types.Nodes.Rc.Object3d value) => new NodeRc(Variants.Object3d, value);

        public static NodeRc Window(Mech3DotNet.Types.Nodes.Window value) => new NodeRc(Variants.Window, value);

        public static NodeRc World(Mech3DotNet.Types.Nodes.Rc.World value) => new NodeRc(Variants.World, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsCamera() => Variant == Variants.Camera;
        public Mech3DotNet.Types.Nodes.Camera AsCamera() => (Mech3DotNet.Types.Nodes.Camera)Value;
        public bool IsDisplay() => Variant == Variants.Display;
        public Mech3DotNet.Types.Nodes.Display AsDisplay() => (Mech3DotNet.Types.Nodes.Display)Value;
        public bool IsEmpty() => Variant == Variants.Empty;
        public Mech3DotNet.Types.Nodes.Rc.Empty AsEmpty() => (Mech3DotNet.Types.Nodes.Rc.Empty)Value;
        public bool IsLight() => Variant == Variants.Light;
        public Mech3DotNet.Types.Nodes.Rc.Light AsLight() => (Mech3DotNet.Types.Nodes.Rc.Light)Value;
        public bool IsLod() => Variant == Variants.Lod;
        public Mech3DotNet.Types.Nodes.Rc.Lod AsLod() => (Mech3DotNet.Types.Nodes.Rc.Lod)Value;
        public bool IsObject3d() => Variant == Variants.Object3d;
        public Mech3DotNet.Types.Nodes.Rc.Object3d AsObject3d() => (Mech3DotNet.Types.Nodes.Rc.Object3d)Value;
        public bool IsWindow() => Variant == Variants.Window;
        public Mech3DotNet.Types.Nodes.Window AsWindow() => (Mech3DotNet.Types.Nodes.Window)Value;
        public bool IsWorld() => Variant == Variants.World;
        public Mech3DotNet.Types.Nodes.Rc.World AsWorld() => (Mech3DotNet.Types.Nodes.Rc.World)Value;

        private static void Serialize(NodeRc v, Serializer s)
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
                        s.Serialize(Mech3DotNet.Types.Nodes.Rc.Empty.Converter)(inner);
                        break;
                    }

                case Variants.Light: // 3
                    {
                        var inner = v.AsLight();
                        s.SerializeNewTypeVariant(3);
                        s.Serialize(Mech3DotNet.Types.Nodes.Rc.Light.Converter)(inner);
                        break;
                    }

                case Variants.Lod: // 4
                    {
                        var inner = v.AsLod();
                        s.SerializeNewTypeVariant(4);
                        s.Serialize(Mech3DotNet.Types.Nodes.Rc.Lod.Converter)(inner);
                        break;
                    }

                case Variants.Object3d: // 5
                    {
                        var inner = v.AsObject3d();
                        s.SerializeNewTypeVariant(5);
                        s.Serialize(Mech3DotNet.Types.Nodes.Rc.Object3d.Converter)(inner);
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
                        s.Serialize(Mech3DotNet.Types.Nodes.Rc.World.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static NodeRc Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Camera
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeRc", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Camera.Converter)();
                        return NodeRc.Camera(inner);
                    }

                case 1: // Display
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeRc", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Display.Converter)();
                        return NodeRc.Display(inner);
                    }

                case 2: // Empty
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeRc", 2, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Rc.Empty.Converter)();
                        return NodeRc.Empty(inner);
                    }

                case 3: // Light
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeRc", 3, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Rc.Light.Converter)();
                        return NodeRc.Light(inner);
                    }

                case 4: // Lod
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeRc", 4, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Rc.Lod.Converter)();
                        return NodeRc.Lod(inner);
                    }

                case 5: // Object3d
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeRc", 5, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Rc.Object3d.Converter)();
                        return NodeRc.Object3d(inner);
                    }

                case 6: // Window
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeRc", 6, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Window.Converter)();
                        return NodeRc.Window(inner);
                    }

                case 7: // World
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeRc", 7, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Rc.World.Converter)();
                        return NodeRc.World(inner);
                    }

                default:
                    throw new UnknownVariantException("NodeRc", variantIndex);
            }
        }
    }
}
