using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Image
{
    public sealed class TextureInfo
    {
        public static readonly TypeConverter<TextureInfo> Converter = new TypeConverter<TextureInfo>(Deserialize, Serialize);
        public string name;
        public string? rename = null;
        public Mech3DotNet.Types.Image.TextureAlpha alpha;
        public ushort width;
        public ushort height;
        public Mech3DotNet.Types.Image.TextureStretch stretch;
        public bool imageLoaded;
        public bool alphaLoaded;
        public bool paletteLoaded;
        public Mech3DotNet.Types.Image.TexturePalette palette;

        public TextureInfo(string name, string? rename, Mech3DotNet.Types.Image.TextureAlpha alpha, ushort width, ushort height, Mech3DotNet.Types.Image.TextureStretch stretch, bool imageLoaded, bool alphaLoaded, bool paletteLoaded, Mech3DotNet.Types.Image.TexturePalette palette)
        {
            this.name = name;
            this.rename = rename;
            this.alpha = alpha;
            this.width = width;
            this.height = height;
            this.stretch = stretch;
            this.imageLoaded = imageLoaded;
            this.alphaLoaded = alphaLoaded;
            this.paletteLoaded = paletteLoaded;
            this.palette = palette;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<string?> rename;
            public Field<Mech3DotNet.Types.Image.TextureAlpha> alpha;
            public Field<ushort> width;
            public Field<ushort> height;
            public Field<Mech3DotNet.Types.Image.TextureStretch> stretch;
            public Field<bool> imageLoaded;
            public Field<bool> alphaLoaded;
            public Field<bool> paletteLoaded;
            public Field<Mech3DotNet.Types.Image.TexturePalette> palette;
        }

        public static void Serialize(TextureInfo v, Serializer s)
        {
            s.SerializeStruct(10);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("rename");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.rename);
            s.SerializeFieldName("alpha");
            s.Serialize(Mech3DotNet.Types.Image.TextureAlpha.Converter)(v.alpha);
            s.SerializeFieldName("width");
            ((Action<ushort>)s.SerializeU16)(v.width);
            s.SerializeFieldName("height");
            ((Action<ushort>)s.SerializeU16)(v.height);
            s.SerializeFieldName("stretch");
            s.Serialize(Mech3DotNet.Types.Image.TextureStretch.Converter)(v.stretch);
            s.SerializeFieldName("image_loaded");
            ((Action<bool>)s.SerializeBool)(v.imageLoaded);
            s.SerializeFieldName("alpha_loaded");
            ((Action<bool>)s.SerializeBool)(v.alphaLoaded);
            s.SerializeFieldName("palette_loaded");
            ((Action<bool>)s.SerializeBool)(v.paletteLoaded);
            s.SerializeFieldName("palette");
            s.Serialize(Mech3DotNet.Types.Image.TexturePalette.Converter)(v.palette);
        }

        public static TextureInfo Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                rename = new Field<string?>(null),
                alpha = new Field<Mech3DotNet.Types.Image.TextureAlpha>(),
                width = new Field<ushort>(),
                height = new Field<ushort>(),
                stretch = new Field<Mech3DotNet.Types.Image.TextureStretch>(),
                imageLoaded = new Field<bool>(),
                alphaLoaded = new Field<bool>(),
                paletteLoaded = new Field<bool>(),
                palette = new Field<Mech3DotNet.Types.Image.TexturePalette>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "rename":
                        fields.rename.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "alpha":
                        fields.alpha.Value = d.Deserialize(Mech3DotNet.Types.Image.TextureAlpha.Converter)();
                        break;
                    case "width":
                        fields.width.Value = d.DeserializeU16();
                        break;
                    case "height":
                        fields.height.Value = d.DeserializeU16();
                        break;
                    case "stretch":
                        fields.stretch.Value = d.Deserialize(Mech3DotNet.Types.Image.TextureStretch.Converter)();
                        break;
                    case "image_loaded":
                        fields.imageLoaded.Value = d.DeserializeBool();
                        break;
                    case "alpha_loaded":
                        fields.alphaLoaded.Value = d.DeserializeBool();
                        break;
                    case "palette_loaded":
                        fields.paletteLoaded.Value = d.DeserializeBool();
                        break;
                    case "palette":
                        fields.palette.Value = d.Deserialize(Mech3DotNet.Types.Image.TexturePalette.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("TextureInfo", fieldName);
                }
            }
            return new TextureInfo(

                fields.name.Unwrap("TextureInfo", "name"),

                fields.rename.Unwrap("TextureInfo", "rename"),

                fields.alpha.Unwrap("TextureInfo", "alpha"),

                fields.width.Unwrap("TextureInfo", "width"),

                fields.height.Unwrap("TextureInfo", "height"),

                fields.stretch.Unwrap("TextureInfo", "stretch"),

                fields.imageLoaded.Unwrap("TextureInfo", "imageLoaded"),

                fields.alphaLoaded.Unwrap("TextureInfo", "alphaLoaded"),

                fields.paletteLoaded.Unwrap("TextureInfo", "paletteLoaded"),

                fields.palette.Unwrap("TextureInfo", "palette")

            );
        }
    }
}
