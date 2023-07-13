using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mesh.Ng
{
    public sealed class PolygonMaterialNg
    {
        public static readonly TypeConverter<PolygonMaterialNg> Converter = new TypeConverter<PolygonMaterialNg>(Deserialize, Serialize);
        public uint materialIndex;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord> uvCoords;

        public PolygonMaterialNg(uint materialIndex, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord> uvCoords)
        {
            this.materialIndex = materialIndex;
            this.uvCoords = uvCoords;
        }

        private struct Fields
        {
            public Field<uint> materialIndex;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord>> uvCoords;
        }

        public static void Serialize(PolygonMaterialNg v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("material_index");
            ((Action<uint>)s.SerializeU32)(v.materialIndex);
            s.SerializeFieldName("uv_coords");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.UvCoordConverter.Converter))(v.uvCoords);
        }

        public static PolygonMaterialNg Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                materialIndex = new Field<uint>(),
                uvCoords = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord>>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "material_index":
                        fields.materialIndex.Value = d.DeserializeU32();
                        break;
                    case "uv_coords":
                        fields.uvCoords.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.UvCoordConverter.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("PolygonMaterialNg", fieldName);
                }
            }
            return new PolygonMaterialNg(

                fields.materialIndex.Unwrap("PolygonMaterialNg", "materialIndex"),

                fields.uvCoords.Unwrap("PolygonMaterialNg", "uvCoords")

            );
        }
    }
}
