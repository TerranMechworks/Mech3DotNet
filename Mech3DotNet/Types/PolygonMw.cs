using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mesh.Mw
{
    public sealed class PolygonMw
    {
        public static readonly TypeConverter<PolygonMw> Converter = new TypeConverter<PolygonMw>(Deserialize, Serialize);
        public System.Collections.Generic.List<uint> vertexIndices;
        public System.Collections.Generic.List<Mech3DotNet.Types.Types.Color> vertexColors;
        public System.Collections.Generic.List<uint>? normalIndices;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord>? uvCoords;
        public uint textureIndex;
        public uint textureInfo;
        public int unk04;
        public bool unkBit;
        public bool vtxBit;
        public uint verticesPtr;
        public uint normalsPtr;
        public uint uvsPtr;
        public uint colorsPtr;
        public uint unkPtr;

        public PolygonMw(System.Collections.Generic.List<uint> vertexIndices, System.Collections.Generic.List<Mech3DotNet.Types.Types.Color> vertexColors, System.Collections.Generic.List<uint>? normalIndices, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord>? uvCoords, uint textureIndex, uint textureInfo, int unk04, bool unkBit, bool vtxBit, uint verticesPtr, uint normalsPtr, uint uvsPtr, uint colorsPtr, uint unkPtr)
        {
            this.vertexIndices = vertexIndices;
            this.vertexColors = vertexColors;
            this.normalIndices = normalIndices;
            this.uvCoords = uvCoords;
            this.textureIndex = textureIndex;
            this.textureInfo = textureInfo;
            this.unk04 = unk04;
            this.unkBit = unkBit;
            this.vtxBit = vtxBit;
            this.verticesPtr = verticesPtr;
            this.normalsPtr = normalsPtr;
            this.uvsPtr = uvsPtr;
            this.colorsPtr = colorsPtr;
            this.unkPtr = unkPtr;
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<uint>> vertexIndices;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Color>> vertexColors;
            public Field<System.Collections.Generic.List<uint>?> normalIndices;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord>?> uvCoords;
            public Field<uint> textureIndex;
            public Field<uint> textureInfo;
            public Field<int> unk04;
            public Field<bool> unkBit;
            public Field<bool> vtxBit;
            public Field<uint> verticesPtr;
            public Field<uint> normalsPtr;
            public Field<uint> uvsPtr;
            public Field<uint> colorsPtr;
            public Field<uint> unkPtr;
        }

        public static void Serialize(PolygonMw v, Serializer s)
        {
            s.SerializeStruct("PolygonMw", 14);
            s.SerializeFieldName("vertex_indices");
            s.SerializeVec(((Action<uint>)s.SerializeU32))(v.vertexIndices);
            s.SerializeFieldName("vertex_colors");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Types.ColorConverter.Converter))(v.vertexColors);
            s.SerializeFieldName("normal_indices");
            s.SerializeRefOption(s.SerializeVec(((Action<uint>)s.SerializeU32)))(v.normalIndices);
            s.SerializeFieldName("uv_coords");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.UvCoordConverter.Converter)))(v.uvCoords);
            s.SerializeFieldName("texture_index");
            ((Action<uint>)s.SerializeU32)(v.textureIndex);
            s.SerializeFieldName("texture_info");
            ((Action<uint>)s.SerializeU32)(v.textureInfo);
            s.SerializeFieldName("unk04");
            ((Action<int>)s.SerializeI32)(v.unk04);
            s.SerializeFieldName("unk_bit");
            ((Action<bool>)s.SerializeBool)(v.unkBit);
            s.SerializeFieldName("vtx_bit");
            ((Action<bool>)s.SerializeBool)(v.vtxBit);
            s.SerializeFieldName("vertices_ptr");
            ((Action<uint>)s.SerializeU32)(v.verticesPtr);
            s.SerializeFieldName("normals_ptr");
            ((Action<uint>)s.SerializeU32)(v.normalsPtr);
            s.SerializeFieldName("uvs_ptr");
            ((Action<uint>)s.SerializeU32)(v.uvsPtr);
            s.SerializeFieldName("colors_ptr");
            ((Action<uint>)s.SerializeU32)(v.colorsPtr);
            s.SerializeFieldName("unk_ptr");
            ((Action<uint>)s.SerializeU32)(v.unkPtr);
        }

        public static PolygonMw Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                vertexIndices = new Field<System.Collections.Generic.List<uint>>(),
                vertexColors = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Color>>(),
                normalIndices = new Field<System.Collections.Generic.List<uint>?>(),
                uvCoords = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord>?>(),
                textureIndex = new Field<uint>(),
                textureInfo = new Field<uint>(),
                unk04 = new Field<int>(),
                unkBit = new Field<bool>(),
                vtxBit = new Field<bool>(),
                verticesPtr = new Field<uint>(),
                normalsPtr = new Field<uint>(),
                uvsPtr = new Field<uint>(),
                colorsPtr = new Field<uint>(),
                unkPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("PolygonMw"))
            {
                switch (fieldName)
                {
                    case "vertex_indices":
                        fields.vertexIndices.Value = d.DeserializeVec(d.DeserializeU32)();
                        break;
                    case "vertex_colors":
                        fields.vertexColors.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Types.ColorConverter.Converter))();
                        break;
                    case "normal_indices":
                        fields.normalIndices.Value = d.DeserializeRefOption(d.DeserializeVec(d.DeserializeU32))();
                        break;
                    case "uv_coords":
                        fields.uvCoords.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.UvCoordConverter.Converter)))();
                        break;
                    case "texture_index":
                        fields.textureIndex.Value = d.DeserializeU32();
                        break;
                    case "texture_info":
                        fields.textureInfo.Value = d.DeserializeU32();
                        break;
                    case "unk04":
                        fields.unk04.Value = d.DeserializeI32();
                        break;
                    case "unk_bit":
                        fields.unkBit.Value = d.DeserializeBool();
                        break;
                    case "vtx_bit":
                        fields.vtxBit.Value = d.DeserializeBool();
                        break;
                    case "vertices_ptr":
                        fields.verticesPtr.Value = d.DeserializeU32();
                        break;
                    case "normals_ptr":
                        fields.normalsPtr.Value = d.DeserializeU32();
                        break;
                    case "uvs_ptr":
                        fields.uvsPtr.Value = d.DeserializeU32();
                        break;
                    case "colors_ptr":
                        fields.colorsPtr.Value = d.DeserializeU32();
                        break;
                    case "unk_ptr":
                        fields.unkPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("PolygonMw", fieldName);
                }
            }
            return new PolygonMw(

                fields.vertexIndices.Unwrap("PolygonMw", "vertexIndices"),

                fields.vertexColors.Unwrap("PolygonMw", "vertexColors"),

                fields.normalIndices.Unwrap("PolygonMw", "normalIndices"),

                fields.uvCoords.Unwrap("PolygonMw", "uvCoords"),

                fields.textureIndex.Unwrap("PolygonMw", "textureIndex"),

                fields.textureInfo.Unwrap("PolygonMw", "textureInfo"),

                fields.unk04.Unwrap("PolygonMw", "unk04"),

                fields.unkBit.Unwrap("PolygonMw", "unkBit"),

                fields.vtxBit.Unwrap("PolygonMw", "vtxBit"),

                fields.verticesPtr.Unwrap("PolygonMw", "verticesPtr"),

                fields.normalsPtr.Unwrap("PolygonMw", "normalsPtr"),

                fields.uvsPtr.Unwrap("PolygonMw", "uvsPtr"),

                fields.colorsPtr.Unwrap("PolygonMw", "colorsPtr"),

                fields.unkPtr.Unwrap("PolygonMw", "unkPtr")

            );
        }
    }
}
