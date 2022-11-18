namespace Mech3DotNet.Json
{
    public enum NodePmVariant
    {
        Lod,
        Object3d,
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.NodePmConverter))]
    public class NodePm : Mech3DotNet.Json.Converters.IDiscriminatedUnion<NodePmVariant>
    {
        public NodePm(LodPm value)
        {
            this.value = value;
            Variant = NodePmVariant.Lod;
        }

        public NodePm(Object3dPm value)
        {
            this.value = value;
            Variant = NodePmVariant.Object3d;
        }

        protected object value;
        public NodePmVariant Variant { get; protected set; }
        public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() { return (T)value; }
        public object GetValue() { return value; }
    }
}
