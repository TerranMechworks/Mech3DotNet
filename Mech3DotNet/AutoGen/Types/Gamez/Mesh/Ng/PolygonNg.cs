using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mesh.Ng
{
    public sealed class PolygonNg
    {
        public static readonly TypeConverter<PolygonNg> Converter = new TypeConverter<PolygonNg>(Deserialize, Serialize);
        public Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonFlags flags;
        public System.Collections.Generic.List<uint> vertexIndices;
        public System.Collections.Generic.List<Mech3DotNet.Types.Color> vertexColors;
        public System.Collections.Generic.List<uint>? normalIndices;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonMaterialNg> materials;
        public int unk04;
        public uint verticesPtr;
        public uint normalsPtr;
        public uint uvsPtr;
        public uint colorsPtr;
        public uint unk28;
        public uint unk32;
        public uint unk36;

        public PolygonNg(Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonFlags flags, System.Collections.Generic.List<uint> vertexIndices, System.Collections.Generic.List<Mech3DotNet.Types.Color> vertexColors, System.Collections.Generic.List<uint>? normalIndices, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonMaterialNg> materials, int unk04, uint verticesPtr, uint normalsPtr, uint uvsPtr, uint colorsPtr, uint unk28, uint unk32, uint unk36)
        {
            this.flags = flags;
            this.vertexIndices = vertexIndices;
            this.vertexColors = vertexColors;
            this.normalIndices = normalIndices;
            this.materials = materials;
            this.unk04 = unk04;
            this.verticesPtr = verticesPtr;
            this.normalsPtr = normalsPtr;
            this.uvsPtr = uvsPtr;
            this.colorsPtr = colorsPtr;
            this.unk28 = unk28;
            this.unk32 = unk32;
            this.unk36 = unk36;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonFlags> flags;
            public Field<System.Collections.Generic.List<uint>> vertexIndices;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Color>> vertexColors;
            public Field<System.Collections.Generic.List<uint>?> normalIndices;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonMaterialNg>> materials;
            public Field<int> unk04;
            public Field<uint> verticesPtr;
            public Field<uint> normalsPtr;
            public Field<uint> uvsPtr;
            public Field<uint> colorsPtr;
            public Field<uint> unk28;
            public Field<uint> unk32;
            public Field<uint> unk36;
        }

        public static void Serialize(PolygonNg v, Serializer s)
        {
            s.SerializeStruct(13);
            s.SerializeFieldName("flags");
            s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonFlags.Converter)(v.flags);
            s.SerializeFieldName("vertex_indices");
            s.SerializeVec(((Action<uint>)s.SerializeU32))(v.vertexIndices);
            s.SerializeFieldName("vertex_colors");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.ColorConverter.Converter))(v.vertexColors);
            s.SerializeFieldName("normal_indices");
            s.SerializeRefOption(s.SerializeVec(((Action<uint>)s.SerializeU32)))(v.normalIndices);
            s.SerializeFieldName("materials");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonMaterialNg.Converter))(v.materials);
            s.SerializeFieldName("unk04");
            ((Action<int>)s.SerializeI32)(v.unk04);
            s.SerializeFieldName("vertices_ptr");
            ((Action<uint>)s.SerializeU32)(v.verticesPtr);
            s.SerializeFieldName("normals_ptr");
            ((Action<uint>)s.SerializeU32)(v.normalsPtr);
            s.SerializeFieldName("uvs_ptr");
            ((Action<uint>)s.SerializeU32)(v.uvsPtr);
            s.SerializeFieldName("colors_ptr");
            ((Action<uint>)s.SerializeU32)(v.colorsPtr);
            s.SerializeFieldName("unk28");
            ((Action<uint>)s.SerializeU32)(v.unk28);
            s.SerializeFieldName("unk32");
            ((Action<uint>)s.SerializeU32)(v.unk32);
            s.SerializeFieldName("unk36");
            ((Action<uint>)s.SerializeU32)(v.unk36);
        }

        public static PolygonNg Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                flags = new Field<Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonFlags>(),
                vertexIndices = new Field<System.Collections.Generic.List<uint>>(),
                vertexColors = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Color>>(),
                normalIndices = new Field<System.Collections.Generic.List<uint>?>(),
                materials = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonMaterialNg>>(),
                unk04 = new Field<int>(),
                verticesPtr = new Field<uint>(),
                normalsPtr = new Field<uint>(),
                uvsPtr = new Field<uint>(),
                colorsPtr = new Field<uint>(),
                unk28 = new Field<uint>(),
                unk32 = new Field<uint>(),
                unk36 = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "flags":
                        fields.flags.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonFlags.Converter)();
                        break;
                    case "vertex_indices":
                        fields.vertexIndices.Value = d.DeserializeVec(d.DeserializeU32)();
                        break;
                    case "vertex_colors":
                        fields.vertexColors.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.ColorConverter.Converter))();
                        break;
                    case "normal_indices":
                        fields.normalIndices.Value = d.DeserializeRefOption(d.DeserializeVec(d.DeserializeU32))();
                        break;
                    case "materials":
                        fields.materials.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonMaterialNg.Converter))();
                        break;
                    case "unk04":
                        fields.unk04.Value = d.DeserializeI32();
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
                    case "unk28":
                        fields.unk28.Value = d.DeserializeU32();
                        break;
                    case "unk32":
                        fields.unk32.Value = d.DeserializeU32();
                        break;
                    case "unk36":
                        fields.unk36.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("PolygonNg", fieldName);
                }
            }
            return new PolygonNg(

                fields.flags.Unwrap("PolygonNg", "flags"),

                fields.vertexIndices.Unwrap("PolygonNg", "vertexIndices"),

                fields.vertexColors.Unwrap("PolygonNg", "vertexColors"),

                fields.normalIndices.Unwrap("PolygonNg", "normalIndices"),

                fields.materials.Unwrap("PolygonNg", "materials"),

                fields.unk04.Unwrap("PolygonNg", "unk04"),

                fields.verticesPtr.Unwrap("PolygonNg", "verticesPtr"),

                fields.normalsPtr.Unwrap("PolygonNg", "normalsPtr"),

                fields.uvsPtr.Unwrap("PolygonNg", "uvsPtr"),

                fields.colorsPtr.Unwrap("PolygonNg", "colorsPtr"),

                fields.unk28.Unwrap("PolygonNg", "unk28"),

                fields.unk32.Unwrap("PolygonNg", "unk32"),

                fields.unk36.Unwrap("PolygonNg", "unk36")

            );
        }
    }
}
