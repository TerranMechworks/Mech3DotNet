namespace Mech3DotNet.Json.Nodes.Mw
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

    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Nodes.Mw.Converters.NodeMwConverter))]
    public class NodeMw : Mech3DotNet.Json.Converters.IDiscriminatedUnion<NodeMwVariant>
    {
        public NodeMw(Mech3DotNet.Json.Nodes.Mw.Camera value)
        {
            this.value = value;
            Variant = NodeMwVariant.Camera;
        }

        public NodeMw(Mech3DotNet.Json.Nodes.Mw.Display value)
        {
            this.value = value;
            Variant = NodeMwVariant.Display;
        }

        public NodeMw(Mech3DotNet.Json.Nodes.Mw.Empty value)
        {
            this.value = value;
            Variant = NodeMwVariant.Empty;
        }

        public NodeMw(Mech3DotNet.Json.Nodes.Mw.Light value)
        {
            this.value = value;
            Variant = NodeMwVariant.Light;
        }

        public NodeMw(Mech3DotNet.Json.Nodes.Mw.Lod value)
        {
            this.value = value;
            Variant = NodeMwVariant.Lod;
        }

        public NodeMw(Mech3DotNet.Json.Nodes.Mw.Object3d value)
        {
            this.value = value;
            Variant = NodeMwVariant.Object3d;
        }

        public NodeMw(Mech3DotNet.Json.Nodes.Mw.Window value)
        {
            this.value = value;
            Variant = NodeMwVariant.Window;
        }

        public NodeMw(Mech3DotNet.Json.Nodes.Mw.World value)
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
