using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    public enum NodeVariant
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

    [JsonConverter(typeof(NodeConverter))]
    public class Node : IDiscriminatedUnion<NodeVariant>
    {
        public Node(Camera value)
        {
            this.value = value;
            Variant = NodeVariant.Camera;
        }

        public Node(Display value)
        {
            this.value = value;
            Variant = NodeVariant.Display;
        }

        public Node(Empty value)
        {
            this.value = value;
            Variant = NodeVariant.Empty;
        }

        public Node(Light value)
        {
            this.value = value;
            Variant = NodeVariant.Light;
        }

        public Node(Lod value)
        {
            this.value = value;
            Variant = NodeVariant.Lod;
        }

        public Node(Object3d value)
        {
            this.value = value;
            Variant = NodeVariant.Object3d;
        }

        public Node(Window value)
        {
            this.value = value;
            Variant = NodeVariant.Window;
        }

        public Node(World value)
        {
            this.value = value;
            Variant = NodeVariant.World;
        }

        protected object value;
        public NodeVariant Variant { get; protected set; }
        public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() { return (T)value; }
        public object GetValue() { return value; }
    }
}
