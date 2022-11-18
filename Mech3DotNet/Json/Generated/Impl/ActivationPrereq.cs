namespace Mech3DotNet.Json.Anim
{
    public enum ActivationPrereqVariant
    {
        Animation,
        Parent,
        Object,
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Converters.ActivationPrereqConverter))]
    public class ActivationPrereq : Mech3DotNet.Json.Converters.IDiscriminatedUnion<ActivationPrereqVariant>
    {
        public ActivationPrereq(Mech3DotNet.Json.Anim.PrereqAnimation value)
        {
            this.value = value;
            Variant = ActivationPrereqVariant.Animation;
        }

        public ActivationPrereq(Mech3DotNet.Json.Anim.PrereqParent value)
        {
            this.value = value;
            Variant = ActivationPrereqVariant.Parent;
        }

        public ActivationPrereq(Mech3DotNet.Json.Anim.PrereqObject value)
        {
            this.value = value;
            Variant = ActivationPrereqVariant.Object;
        }

        protected object value;
        public ActivationPrereqVariant Variant { get; protected set; }
        public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() { return (T)value; }
        public object GetValue() { return value; }
    }
}
