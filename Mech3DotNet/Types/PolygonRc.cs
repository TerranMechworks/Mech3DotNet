using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mesh.Rc
{
    public sealed class PolygonRc
    {
        public static readonly TypeConverter<PolygonRc> Converter = new TypeConverter<PolygonRc>(Deserialize, Serialize);
        public System.Collections.Generic.List<uint> vertexIndices;
        public System.Collections.Generic.List<uint>? normalIndices;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord>? uvCoords;
        public uint textureIndex;
        public bool unk0Flag;
        public int unk04;
        public uint unk24;
        public uint verticesPtr;
        public uint normalsPtr;
        public uint uvsPtr;

        public PolygonRc(System.Collections.Generic.List<uint> vertexIndices, System.Collections.Generic.List<uint>? normalIndices, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord>? uvCoords, uint textureIndex, bool unk0Flag, int unk04, uint unk24, uint verticesPtr, uint normalsPtr, uint uvsPtr)
        {
            this.vertexIndices = vertexIndices;
            this.normalIndices = normalIndices;
            this.uvCoords = uvCoords;
            this.textureIndex = textureIndex;
            this.unk0Flag = unk0Flag;
            this.unk04 = unk04;
            this.unk24 = unk24;
            this.verticesPtr = verticesPtr;
            this.normalsPtr = normalsPtr;
            this.uvsPtr = uvsPtr;
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<uint>> vertexIndices;
            public Field<System.Collections.Generic.List<uint>?> normalIndices;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord>?> uvCoords;
            public Field<uint> textureIndex;
            public Field<bool> unk0Flag;
            public Field<int> unk04;
            public Field<uint> unk24;
            public Field<uint> verticesPtr;
            public Field<uint> normalsPtr;
            public Field<uint> uvsPtr;
        }

        public static void Serialize(Mech3DotNet.Types.Gamez.Mesh.Rc.PolygonRc v, Serializer s)
        {
            s.SerializeStruct("PolygonRc", 10);
            s.SerializeFieldName("vertex_indices");
            s.SerializeVec(((Action<uint>)s.SerializeU32))(v.vertexIndices);
            s.SerializeFieldName("normal_indices");
            s.SerializeRefOption(s.SerializeVec(((Action<uint>)s.SerializeU32)))(v.normalIndices);
            s.SerializeFieldName("uv_coords");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.UvCoord.Converter)))(v.uvCoords);
            s.SerializeFieldName("texture_index");
            ((Action<uint>)s.SerializeU32)(v.textureIndex);
            s.SerializeFieldName("unk0_flag");
            ((Action<bool>)s.SerializeBool)(v.unk0Flag);
            s.SerializeFieldName("unk04");
            ((Action<int>)s.SerializeI32)(v.unk04);
            s.SerializeFieldName("unk24");
            ((Action<uint>)s.SerializeU32)(v.unk24);
            s.SerializeFieldName("vertices_ptr");
            ((Action<uint>)s.SerializeU32)(v.verticesPtr);
            s.SerializeFieldName("normals_ptr");
            ((Action<uint>)s.SerializeU32)(v.normalsPtr);
            s.SerializeFieldName("uvs_ptr");
            ((Action<uint>)s.SerializeU32)(v.uvsPtr);
        }

        public static Mech3DotNet.Types.Gamez.Mesh.Rc.PolygonRc Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                vertexIndices = new Field<System.Collections.Generic.List<uint>>(),
                normalIndices = new Field<System.Collections.Generic.List<uint>?>(),
                uvCoords = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.UvCoord>?>(),
                textureIndex = new Field<uint>(),
                unk0Flag = new Field<bool>(),
                unk04 = new Field<int>(),
                unk24 = new Field<uint>(),
                verticesPtr = new Field<uint>(),
                normalsPtr = new Field<uint>(),
                uvsPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("PolygonRc"))
            {
                switch (fieldName)
                {
                    case "vertex_indices":
                        fields.vertexIndices.Value = d.DeserializeVec(d.DeserializeU32)();
                        break;
                    case "normal_indices":
                        fields.normalIndices.Value = d.DeserializeRefOption(d.DeserializeVec(d.DeserializeU32))();
                        break;
                    case "uv_coords":
                        fields.uvCoords.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.UvCoord.Converter)))();
                        break;
                    case "texture_index":
                        fields.textureIndex.Value = d.DeserializeU32();
                        break;
                    case "unk0_flag":
                        fields.unk0Flag.Value = d.DeserializeBool();
                        break;
                    case "unk04":
                        fields.unk04.Value = d.DeserializeI32();
                        break;
                    case "unk24":
                        fields.unk24.Value = d.DeserializeU32();
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
                    default:
                        throw new UnknownFieldException("PolygonRc", fieldName);
                }
            }
            return new PolygonRc(

                fields.vertexIndices.Unwrap("PolygonRc", "vertexIndices"),

                fields.normalIndices.Unwrap("PolygonRc", "normalIndices"),

                fields.uvCoords.Unwrap("PolygonRc", "uvCoords"),

                fields.textureIndex.Unwrap("PolygonRc", "textureIndex"),

                fields.unk0Flag.Unwrap("PolygonRc", "unk0Flag"),

                fields.unk04.Unwrap("PolygonRc", "unk04"),

                fields.unk24.Unwrap("PolygonRc", "unk24"),

                fields.verticesPtr.Unwrap("PolygonRc", "verticesPtr"),

                fields.normalsPtr.Unwrap("PolygonRc", "normalsPtr"),

                fields.uvsPtr.Unwrap("PolygonRc", "uvsPtr")

            );
        }
    }
}
