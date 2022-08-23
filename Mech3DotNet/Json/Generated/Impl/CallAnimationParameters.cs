using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    public enum CallAnimationParametersVariant
    {
        AtNode,
        WithNode,
        TargetNode,
        None,
    }

    [JsonConverter(typeof(CallAnimationParametersConverter))]
    public class CallAnimationParameters : IDiscriminatedUnion<CallAnimationParametersVariant>
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
