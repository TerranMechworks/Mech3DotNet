using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    public enum ForwardRotationVariant
    {
        Time,
        Distance,
    }

    [JsonConverter(typeof(ForwardRotationConverter))]
    public class ForwardRotation : IDiscriminatedUnion<ForwardRotationVariant>
    {
        public ForwardRotation(ForwardRotationTime value)
        {
            this.value = value;
            Variant = ForwardRotationVariant.Time;
        }

        public ForwardRotation(ForwardRotationDistance value)
        {
            this.value = value;
            Variant = ForwardRotationVariant.Distance;
        }

        protected object value;
        public ForwardRotationVariant Variant { get; protected set; }
        public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() { return (T)value; }
        public object GetValue() { return value; }
    }
}
