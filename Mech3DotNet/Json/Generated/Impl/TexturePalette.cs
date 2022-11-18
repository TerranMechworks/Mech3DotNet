namespace Mech3DotNet.Json
{
    public enum TexturePaletteVariant
    {
        None,
        Local,
        Global,
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.TexturePaletteConverter))]
    public class TexturePalette : Mech3DotNet.Json.Converters.IDiscriminatedUnion<TexturePaletteVariant>
    {
        public sealed class None
        {
            public None() { }
        }

        public TexturePalette(None value)
        {
            this.value = value;
            Variant = TexturePaletteVariant.None;
        }

        public TexturePalette(PaletteData value)
        {
            this.value = value;
            Variant = TexturePaletteVariant.Local;
        }

        public TexturePalette(GlobalPalette value)
        {
            this.value = value;
            Variant = TexturePaletteVariant.Global;
        }

        protected object value;
        public TexturePaletteVariant Variant { get; protected set; }
        public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() { return (T)value; }
        public object GetValue() { return value; }
    }
}
