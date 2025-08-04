using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Model
{
    public sealed class PolygonMaterial
    {
        public static readonly TypeConverter<PolygonMaterial> Converter = new TypeConverter<PolygonMaterial>(Deserialize, Serialize);
        public short materialIndex;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.UvCoord>? uvCoords;

        public PolygonMaterial(short materialIndex, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.UvCoord>? uvCoords)
        {
            this.materialIndex = materialIndex;
            this.uvCoords = uvCoords;
        }

        private struct Fields
        {
            public Field<short> materialIndex;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.UvCoord>?> uvCoords;
        }

        public static void Serialize(PolygonMaterial v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("material_index");
            ((Action<short>)s.SerializeI16)(v.materialIndex);
            s.SerializeFieldName("uv_coords");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Model.UvCoordConverter.Converter)))(v.uvCoords);
        }

        public static PolygonMaterial Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                materialIndex = new Field<short>(),
                uvCoords = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.UvCoord>?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "material_index":
                        fields.materialIndex.Value = d.DeserializeI16();
                        break;
                    case "uv_coords":
                        fields.uvCoords.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Model.UvCoordConverter.Converter)))();
                        break;
                    default:
                        throw new UnknownFieldException("PolygonMaterial", fieldName);
                }
            }
            return new PolygonMaterial(

                fields.materialIndex.Unwrap("PolygonMaterial", "materialIndex"),

                fields.uvCoords.Unwrap("PolygonMaterial", "uvCoords")

            );
        }
    }
}
