using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mesh.Ng
{
    public sealed class PolygonTextureNg
    {
        public static readonly TypeConverter<PolygonTextureNg> Converter = new TypeConverter<PolygonTextureNg>(Deserialize, Serialize);
        public uint textureIndex;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord> uvCoords;

        public PolygonTextureNg(uint textureIndex, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord> uvCoords)
        {
            this.textureIndex = textureIndex;
            this.uvCoords = uvCoords;
        }

        private struct Fields
        {
            public Field<uint> textureIndex;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord>> uvCoords;
        }

        public static void Serialize(Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonTextureNg v, Serializer s)
        {
            s.SerializeStruct("PolygonTextureNg", 2);
            s.SerializeFieldName("texture_index");
            ((Action<uint>)s.SerializeU32)(v.textureIndex);
            s.SerializeFieldName("uv_coords");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.UvCoord.Converter))(v.uvCoords);
        }

        public static Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonTextureNg Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textureIndex = new Field<uint>(),
                uvCoords = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord>>(),
            };
            foreach (var fieldName in d.DeserializeStruct("PolygonTextureNg"))
            {
                switch (fieldName)
                {
                    case "texture_index":
                        fields.textureIndex.Value = d.DeserializeU32();
                        break;
                    case "uv_coords":
                        fields.uvCoords.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.UvCoord.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("PolygonTextureNg", fieldName);
                }
            }
            return new PolygonTextureNg(

                fields.textureIndex.Unwrap("PolygonTextureNg", "textureIndex"),

                fields.uvCoords.Unwrap("PolygonTextureNg", "uvCoords")

            );
        }
    }
}
