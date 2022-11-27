using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mesh.Ng
{
    public sealed class MeshTexture
    {
        public static readonly TypeConverter<MeshTexture> Converter = new TypeConverter<MeshTexture>(Deserialize, Serialize);
        public uint textureIndex;
        public uint polygonUsageCount;
        public uint unkPtr;

        public MeshTexture(uint textureIndex, uint polygonUsageCount, uint unkPtr)
        {
            this.textureIndex = textureIndex;
            this.polygonUsageCount = polygonUsageCount;
            this.unkPtr = unkPtr;
        }

        private struct Fields
        {
            public Field<uint> textureIndex;
            public Field<uint> polygonUsageCount;
            public Field<uint> unkPtr;
        }

        public static void Serialize(Mech3DotNet.Types.Gamez.Mesh.Ng.MeshTexture v, Serializer s)
        {
            s.SerializeStruct("MeshTexture", 3);
            s.SerializeFieldName("texture_index");
            ((Action<uint>)s.SerializeU32)(v.textureIndex);
            s.SerializeFieldName("polygon_usage_count");
            ((Action<uint>)s.SerializeU32)(v.polygonUsageCount);
            s.SerializeFieldName("unk_ptr");
            ((Action<uint>)s.SerializeU32)(v.unkPtr);
        }

        public static Mech3DotNet.Types.Gamez.Mesh.Ng.MeshTexture Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textureIndex = new Field<uint>(),
                polygonUsageCount = new Field<uint>(),
                unkPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("MeshTexture"))
            {
                switch (fieldName)
                {
                    case "texture_index":
                        fields.textureIndex.Value = d.DeserializeU32();
                        break;
                    case "polygon_usage_count":
                        fields.polygonUsageCount.Value = d.DeserializeU32();
                        break;
                    case "unk_ptr":
                        fields.unkPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("MeshTexture", fieldName);
                }
            }
            return new MeshTexture(

                fields.textureIndex.Unwrap("MeshTexture", "textureIndex"),

                fields.polygonUsageCount.Unwrap("MeshTexture", "polygonUsageCount"),

                fields.unkPtr.Unwrap("MeshTexture", "unkPtr")

            );
        }
    }
}
