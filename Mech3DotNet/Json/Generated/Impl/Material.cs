namespace Mech3DotNet.Json
{
    public enum MaterialVariant
    {
        Textured,
        Colored,
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.MaterialConverter))]
    public class Material : Mech3DotNet.Json.Converters.IDiscriminatedUnion<MaterialVariant>
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
