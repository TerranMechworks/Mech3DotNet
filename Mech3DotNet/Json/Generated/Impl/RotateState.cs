namespace Mech3DotNet.Json.Anim.Events
{
    public enum RotateStateVariant
    {
        Absolute,
        AtNodeXYZ,
        AtNodeMatrix,
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.RotateStateConverter))]
    public class RotateState : Mech3DotNet.Json.Converters.IDiscriminatedUnion<RotateStateVariant>
    {
        public sealed class AtNodeXYZ
        {
            public AtNodeXYZ() { }
        }

        public sealed class AtNodeMatrix
        {
            public AtNodeMatrix() { }
        }

        public RotateState(Mech3DotNet.Json.Types.Vec3 value)
        {
            this.value = value;
            Variant = RotateStateVariant.Absolute;
        }

        public RotateState(AtNodeXYZ value)
        {
            this.value = value;
            Variant = RotateStateVariant.AtNodeXYZ;
        }

        public RotateState(AtNodeMatrix value)
        {
            this.value = value;
            Variant = RotateStateVariant.AtNodeMatrix;
        }

        protected object value;
        public RotateStateVariant Variant { get; protected set; }
        public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() { return (T)value; }
        public object GetValue() { return value; }
    }
}
