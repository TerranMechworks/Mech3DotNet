using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    public enum TexturePaletteVariant
    {
        None,
        Local,
        Global,
    }

    [JsonConverter(typeof(TexturePaletteConverter))]
    public class TexturePalette : IDiscriminatedUnion<TexturePaletteVariant>
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
        public bool Is<T>() where T : class { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() where T : class { return (T)value; }
        public object GetValue() { return value; }
    }
}
