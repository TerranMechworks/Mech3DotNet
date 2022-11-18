namespace Mech3DotNet.Json.Gamez.Materials
{
    public enum MaterialVariant
    {
        Textured,
        Colored,
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Materials.Converters.MaterialConverter))]
    public class Material : Mech3DotNet.Json.Converters.IDiscriminatedUnion<MaterialVariant>
    {
        public Material(Mech3DotNet.Json.Gamez.Materials.TexturedMaterial value)
        {
            this.value = value;
            Variant = MaterialVariant.Textured;
        }

        public Material(Mech3DotNet.Json.Gamez.Materials.ColoredMaterial value)
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
