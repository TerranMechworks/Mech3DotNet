using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Cs
{
    public sealed class NodeCs
    {
        public static readonly TypeConverter<NodeCs> Converter = new TypeConverter<NodeCs>(Deserialize, Serialize);

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

        private NodeCs(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static NodeCs Camera(Mech3DotNet.Types.Nodes.Cs.Camera value) => new NodeCs(Variants.Camera, value);

        public static NodeCs Display(Mech3DotNet.Types.Nodes.Display value) => new NodeCs(Variants.Display, value);

        public static NodeCs Light(Mech3DotNet.Types.Nodes.Cs.Light value) => new NodeCs(Variants.Light, value);

        public static NodeCs Lod(Mech3DotNet.Types.Nodes.Cs.Lod value) => new NodeCs(Variants.Lod, value);

        public static NodeCs Object3d(Mech3DotNet.Types.Nodes.Cs.Object3d value) => new NodeCs(Variants.Object3d, value);

        public static NodeCs Window(Mech3DotNet.Types.Nodes.Cs.Window value) => new NodeCs(Variants.Window, value);

        public static NodeCs World(Mech3DotNet.Types.Nodes.Cs.World value) => new NodeCs(Variants.World, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsCamera() => Variant == Variants.Camera;
        public Mech3DotNet.Types.Nodes.Cs.Camera AsCamera() => (Mech3DotNet.Types.Nodes.Cs.Camera)Value;
        public bool IsDisplay() => Variant == Variants.Display;
        public Mech3DotNet.Types.Nodes.Display AsDisplay() => (Mech3DotNet.Types.Nodes.Display)Value;
        public bool IsLight() => Variant == Variants.Light;
        public Mech3DotNet.Types.Nodes.Cs.Light AsLight() => (Mech3DotNet.Types.Nodes.Cs.Light)Value;
        public bool IsLod() => Variant == Variants.Lod;
        public Mech3DotNet.Types.Nodes.Cs.Lod AsLod() => (Mech3DotNet.Types.Nodes.Cs.Lod)Value;
        public bool IsObject3d() => Variant == Variants.Object3d;
        public Mech3DotNet.Types.Nodes.Cs.Object3d AsObject3d() => (Mech3DotNet.Types.Nodes.Cs.Object3d)Value;
        public bool IsWindow() => Variant == Variants.Window;
        public Mech3DotNet.Types.Nodes.Cs.Window AsWindow() => (Mech3DotNet.Types.Nodes.Cs.Window)Value;
        public bool IsWorld() => Variant == Variants.World;
        public Mech3DotNet.Types.Nodes.Cs.World AsWorld() => (Mech3DotNet.Types.Nodes.Cs.World)Value;

        private static void Serialize(NodeCs v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Camera: // 0
                    {
                        var inner = v.AsCamera();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Nodes.Cs.Camera.Converter)(inner);
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
                        s.Serialize(Mech3DotNet.Types.Nodes.Cs.Light.Converter)(inner);
                        break;
                    }

                case Variants.Lod: // 3
                    {
                        var inner = v.AsLod();
                        s.SerializeNewTypeVariant(3);
                        s.Serialize(Mech3DotNet.Types.Nodes.Cs.Lod.Converter)(inner);
                        break;
                    }

                case Variants.Object3d: // 4
                    {
                        var inner = v.AsObject3d();
                        s.SerializeNewTypeVariant(4);
                        s.Serialize(Mech3DotNet.Types.Nodes.Cs.Object3d.Converter)(inner);
                        break;
                    }

                case Variants.Window: // 5
                    {
                        var inner = v.AsWindow();
                        s.SerializeNewTypeVariant(5);
                        s.Serialize(Mech3DotNet.Types.Nodes.Cs.Window.Converter)(inner);
                        break;
                    }

                case Variants.World: // 6
                    {
                        var inner = v.AsWorld();
                        s.SerializeNewTypeVariant(6);
                        s.Serialize(Mech3DotNet.Types.Nodes.Cs.World.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static NodeCs Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Camera
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeCs", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Cs.Camera.Converter)();
                        return NodeCs.Camera(inner);
                    }

                case 1: // Display
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeCs", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Display.Converter)();
                        return NodeCs.Display(inner);
                    }

                case 2: // Light
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeCs", 2, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Cs.Light.Converter)();
                        return NodeCs.Light(inner);
                    }

                case 3: // Lod
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeCs", 3, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Cs.Lod.Converter)();
                        return NodeCs.Lod(inner);
                    }

                case 4: // Object3d
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeCs", 4, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Cs.Object3d.Converter)();
                        return NodeCs.Object3d(inner);
                    }

                case 5: // Window
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeCs", 5, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Cs.Window.Converter)();
                        return NodeCs.Window(inner);
                    }

                case 6: // World
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeCs", 6, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Nodes.Cs.World.Converter)();
                        return NodeCs.World(inner);
                    }

                default:
                    throw new UnknownVariantException("NodeCs", variantIndex);
            }
        }
    }
}
