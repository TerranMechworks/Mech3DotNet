using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mesh.Ng
{
    public sealed class MeshMaterialInfo
    {
        public static readonly TypeConverter<MeshMaterialInfo> Converter = new TypeConverter<MeshMaterialInfo>(Deserialize, Serialize);
        public uint materialIndex;
        public uint polygonUsageCount;
        public uint unkPtr;

        public MeshMaterialInfo(uint materialIndex, uint polygonUsageCount, uint unkPtr)
        {
            this.materialIndex = materialIndex;
            this.polygonUsageCount = polygonUsageCount;
            this.unkPtr = unkPtr;
        }

        private struct Fields
        {
            public Field<uint> materialIndex;
            public Field<uint> polygonUsageCount;
            public Field<uint> unkPtr;
        }

        public static void Serialize(MeshMaterialInfo v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("material_index");
            ((Action<uint>)s.SerializeU32)(v.materialIndex);
            s.SerializeFieldName("polygon_usage_count");
            ((Action<uint>)s.SerializeU32)(v.polygonUsageCount);
            s.SerializeFieldName("unk_ptr");
            ((Action<uint>)s.SerializeU32)(v.unkPtr);
        }

        public static MeshMaterialInfo Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                materialIndex = new Field<uint>(),
                polygonUsageCount = new Field<uint>(),
                unkPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "material_index":
                        fields.materialIndex.Value = d.DeserializeU32();
                        break;
                    case "polygon_usage_count":
                        fields.polygonUsageCount.Value = d.DeserializeU32();
                        break;
                    case "unk_ptr":
                        fields.unkPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("MeshMaterialInfo", fieldName);
                }
            }
            return new MeshMaterialInfo(

                fields.materialIndex.Unwrap("MeshMaterialInfo", "materialIndex"),

                fields.polygonUsageCount.Unwrap("MeshMaterialInfo", "polygonUsageCount"),

                fields.unkPtr.Unwrap("MeshMaterialInfo", "unkPtr")

            );
        }
    }
}
