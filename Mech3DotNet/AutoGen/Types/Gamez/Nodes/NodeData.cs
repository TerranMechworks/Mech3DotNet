using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class NodeData
    {
        public static readonly TypeConverter<NodeData> Converter = new TypeConverter<NodeData>(Deserialize, Serialize);

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

        private NodeData(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static NodeData Camera(Mech3DotNet.Types.Gamez.Nodes.Camera value) => new NodeData(Variants.Camera, value);

        public static NodeData Display(Mech3DotNet.Types.Gamez.Nodes.Display value) => new NodeData(Variants.Display, value);

        public static readonly NodeData Empty = new NodeData(Variants.Empty, new object());

        public static NodeData Light(Mech3DotNet.Types.Gamez.Nodes.Light value) => new NodeData(Variants.Light, value);

        public static NodeData Lod(Mech3DotNet.Types.Gamez.Nodes.Lod value) => new NodeData(Variants.Lod, value);

        public static NodeData Object3d(Mech3DotNet.Types.Gamez.Nodes.Object3d value) => new NodeData(Variants.Object3d, value);

        public static NodeData Window(Mech3DotNet.Types.Gamez.Nodes.Window value) => new NodeData(Variants.Window, value);

        public static NodeData World(Mech3DotNet.Types.Gamez.Nodes.World value) => new NodeData(Variants.World, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsCamera() => Variant == Variants.Camera;
        public Mech3DotNet.Types.Gamez.Nodes.Camera AsCamera() => (Mech3DotNet.Types.Gamez.Nodes.Camera)Value;
        public bool IsDisplay() => Variant == Variants.Display;
        public Mech3DotNet.Types.Gamez.Nodes.Display AsDisplay() => (Mech3DotNet.Types.Gamez.Nodes.Display)Value;
        public bool IsEmpty() => Variant == Variants.Empty;
        public bool IsLight() => Variant == Variants.Light;
        public Mech3DotNet.Types.Gamez.Nodes.Light AsLight() => (Mech3DotNet.Types.Gamez.Nodes.Light)Value;
        public bool IsLod() => Variant == Variants.Lod;
        public Mech3DotNet.Types.Gamez.Nodes.Lod AsLod() => (Mech3DotNet.Types.Gamez.Nodes.Lod)Value;
        public bool IsObject3d() => Variant == Variants.Object3d;
        public Mech3DotNet.Types.Gamez.Nodes.Object3d AsObject3d() => (Mech3DotNet.Types.Gamez.Nodes.Object3d)Value;
        public bool IsWindow() => Variant == Variants.Window;
        public Mech3DotNet.Types.Gamez.Nodes.Window AsWindow() => (Mech3DotNet.Types.Gamez.Nodes.Window)Value;
        public bool IsWorld() => Variant == Variants.World;
        public Mech3DotNet.Types.Gamez.Nodes.World AsWorld() => (Mech3DotNet.Types.Gamez.Nodes.World)Value;

        private static void Serialize(NodeData v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Camera: // 0
                    {
                        var inner = v.AsCamera();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Gamez.Nodes.Camera.Converter)(inner);
                        break;
                    }

                case Variants.Display: // 1
                    {
                        var inner = v.AsDisplay();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Gamez.Nodes.Display.Converter)(inner);
                        break;
                    }

                case Variants.Empty: // 2
                    {
                        s.SerializeUnitVariant(2);
                        break;
                    }

                case Variants.Light: // 3
                    {
                        var inner = v.AsLight();
                        s.SerializeNewTypeVariant(3);
                        s.Serialize(Mech3DotNet.Types.Gamez.Nodes.Light.Converter)(inner);
                        break;
                    }

                case Variants.Lod: // 4
                    {
                        var inner = v.AsLod();
                        s.SerializeNewTypeVariant(4);
                        s.Serialize(Mech3DotNet.Types.Gamez.Nodes.Lod.Converter)(inner);
                        break;
                    }

                case Variants.Object3d: // 5
                    {
                        var inner = v.AsObject3d();
                        s.SerializeNewTypeVariant(5);
                        s.Serialize(Mech3DotNet.Types.Gamez.Nodes.Object3d.Converter)(inner);
                        break;
                    }

                case Variants.Window: // 6
                    {
                        var inner = v.AsWindow();
                        s.SerializeNewTypeVariant(6);
                        s.Serialize(Mech3DotNet.Types.Gamez.Nodes.Window.Converter)(inner);
                        break;
                    }

                case Variants.World: // 7
                    {
                        var inner = v.AsWorld();
                        s.SerializeNewTypeVariant(7);
                        s.Serialize(Mech3DotNet.Types.Gamez.Nodes.World.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static NodeData Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Camera
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeData", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.Camera.Converter)();
                        return NodeData.Camera(inner);
                    }

                case 1: // Display
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeData", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.Display.Converter)();
                        return NodeData.Display(inner);
                    }

                case 2: // Empty
                    {
                        if (enumType != EnumType.Unit)
                            throw new InvalidVariantException("NodeData", 2, EnumType.Unit, enumType);
                        return NodeData.Empty;
                    }

                case 3: // Light
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeData", 3, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.Light.Converter)();
                        return NodeData.Light(inner);
                    }

                case 4: // Lod
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeData", 4, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.Lod.Converter)();
                        return NodeData.Lod(inner);
                    }

                case 5: // Object3d
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeData", 5, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.Object3d.Converter)();
                        return NodeData.Object3d(inner);
                    }

                case 6: // Window
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeData", 6, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.Window.Converter)();
                        return NodeData.Window(inner);
                    }

                case 7: // World
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("NodeData", 7, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.World.Converter)();
                        return NodeData.World(inner);
                    }

                default:
                    throw new UnknownVariantException("NodeData", variantIndex);
            }
        }
    }
}
