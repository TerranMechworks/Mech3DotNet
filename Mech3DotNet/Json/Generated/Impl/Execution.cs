namespace Mech3DotNet.Json
{
    public enum ExecutionVariant
    {
        ByRange,
        ByZone,
        None,
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ExecutionConverter))]
    public class Execution : Mech3DotNet.Json.Converters.IDiscriminatedUnion<ExecutionVariant>
    {
        public sealed class ByZone
        {
            public ByZone() { }
        }

        public sealed class None
        {
            public None() { }
        }

        public Execution(Range value)
        {
            this.value = value;
            Variant = ExecutionVariant.ByRange;
        }

        public Execution(ByZone value)
        {
            this.value = value;
            Variant = ExecutionVariant.ByZone;
        }

        public Execution(None value)
        {
            this.value = value;
            Variant = ExecutionVariant.None;
        }

        protected object value;
        public ExecutionVariant Variant { get; protected set; }
        public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() { return (T)value; }
        public object GetValue() { return value; }
    }
}
