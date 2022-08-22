using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    public enum MaterialVariant
    {
        Textured,
        Colored,
    }

    [JsonConverter(typeof(MaterialConverter))]
    public class Material : IDiscriminatedUnion<MaterialVariant>
    {
        public Material(TexturedMaterial value)
        {
            this.value = value;
            Variant = MaterialVariant.Textured;
        }

        public Material(ColoredMaterial value)
        {
            this.value = value;
            Variant = MaterialVariant.Colored;
        }

        protected object value;
        public MaterialVariant Variant { get; protected set; }
        public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() { return (T)value; }
        public object GetValue() { return value; }
    }
}
