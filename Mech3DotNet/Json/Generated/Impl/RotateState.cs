using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    public enum RotateStateVariant
    {
        Absolute,
        AtNodeXYZ,
        AtNodeMatrix,
    }

    [JsonConverter(typeof(RotateStateConverter))]
    public class RotateState : IDiscriminatedUnion<RotateStateVariant>
    {
        public sealed class AtNodeXYZ
        {
            public AtNodeXYZ() { }
        }

        public sealed class AtNodeMatrix
        {
            public AtNodeMatrix() { }
        }

        public RotateState(Vec3 value)
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
