namespace Mech3DotNet.Json
{
    public enum CallAnimationParametersVariant
    {
        AtNode,
        WithNode,
        TargetNode,
        None,
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.CallAnimationParametersConverter))]
    public class CallAnimationParameters : Mech3DotNet.Json.Converters.IDiscriminatedUnion<CallAnimationParametersVariant>
    {
        public sealed class None
        {
            public None() { }
        }

        public CallAnimationParameters(CallAnimationAtNode value)
        {
            this.value = value;
            Variant = CallAnimationParametersVariant.AtNode;
        }

        public CallAnimationParameters(CallAnimationWithNode value)
        {
            this.value = value;
            Variant = CallAnimationParametersVariant.WithNode;
        }

        public CallAnimationParameters(CallAnimationTargetNode value)
        {
            this.value = value;
            Variant = CallAnimationParametersVariant.TargetNode;
        }

        public CallAnimationParameters(None value)
        {
            this.value = value;
            Variant = CallAnimationParametersVariant.None;
        }

        protected object value;
        public CallAnimationParametersVariant Variant { get; protected set; }
        public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() { return (T)value; }
        public object GetValue() { return value; }
    }
}
