using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Image
{
    public sealed class TextureManifest
    {
        public System.Collections.Generic.List<Mech3DotNet.Types.Image.TextureInfo> textureInfos;
        public System.Collections.Generic.List<Mech3DotNet.Types.Image.PaletteData> globalPalettes;

        public TextureManifest(System.Collections.Generic.List<Mech3DotNet.Types.Image.TextureInfo> textureInfos, System.Collections.Generic.List<Mech3DotNet.Types.Image.PaletteData> globalPalettes)
        {
            this.textureInfos = textureInfos;
            this.globalPalettes = globalPalettes;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<TextureManifest> Converter = new TypeConverter<TextureManifest>(Deserialize, Serialize);

        public static void Serialize(TextureManifest v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("texture_infos");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Image.TextureInfo.Converter))(v.textureInfos);
            s.SerializeFieldName("global_palettes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Image.PaletteData.Converter))(v.globalPalettes);
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Image.TextureInfo>> textureInfos;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Image.PaletteData>> globalPalettes;
        }

        public static TextureManifest Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textureInfos = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Image.TextureInfo>>(),
                globalPalettes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Image.PaletteData>>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "texture_infos":
                        fields.textureInfos.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Image.TextureInfo.Converter))();
                        break;
                    case "global_palettes":
                        fields.globalPalettes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Image.PaletteData.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("TextureManifest", fieldName);
                }
            }
            return new TextureManifest(

                fields.textureInfos.Unwrap("TextureManifest", "textureInfos"),

                fields.globalPalettes.Unwrap("TextureManifest", "globalPalettes")

            );
        }

        #endregion
    }
}
