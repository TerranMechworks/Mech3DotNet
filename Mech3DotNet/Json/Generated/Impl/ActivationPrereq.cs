namespace Mech3DotNet.Json
{
    public enum ActivationPrereqVariant
    {
        Animation,
        Parent,
        Object,
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ActivationPrereqConverter))]
    public class ActivationPrereq : Mech3DotNet.Json.Converters.IDiscriminatedUnion<ActivationPrereqVariant>
    {
        public ActivationPrereq(PrereqAnimation value)
        {
            this.value = value;
            Variant = ActivationPrereqVariant.Animation;
        }

        public ActivationPrereq(PrereqParent value)
        {
            this.value = value;
            Variant = ActivationPrereqVariant.Parent;
        }

        public ActivationPrereq(PrereqObject value)
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
