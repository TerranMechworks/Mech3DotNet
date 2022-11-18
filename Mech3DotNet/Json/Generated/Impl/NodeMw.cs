using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    public enum NodeMwVariant
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

    [JsonConverter(typeof(NodeMwConverter))]
    public class NodeMw : IDiscriminatedUnion<NodeMwVariant>
    {
        public NodeMw(Camera value)
        {
            this.value = value;
            Variant = NodeMwVariant.Camera;
        }

        public NodeMw(Display value)
        {
            this.value = value;
            Variant = NodeMwVariant.Display;
        }

        public NodeMw(Empty value)
        {
            this.value = value;
            Variant = NodeMwVariant.Empty;
        }

        public NodeMw(Light value)
        {
            this.value = value;
            Variant = NodeMwVariant.Light;
        }

        public NodeMw(Lod value)
        {
            this.value = value;
            Variant = NodeMwVariant.Lod;
        }

        public NodeMw(Object3d value)
        {
            this.value = value;
            Variant = NodeMwVariant.Object3d;
        }

        public NodeMw(Window value)
        {
            this.value = value;
            Variant = NodeMwVariant.Window;
        }

        public NodeMw(World value)
        {
            this.value = value;
            Variant = NodeMwVariant.World;
        }

        protected object value;
        public NodeMwVariant Variant { get; protected set; }
        public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() { return (T)value; }
        public object GetValue() { return value; }
    }
}
