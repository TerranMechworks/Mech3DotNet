using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mesh.Ng
{
    public sealed class MeshNg
    {
        public static readonly TypeConverter<MeshNg> Converter = new TypeConverter<MeshNg>(Deserialize, Serialize);
        public System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> vertices;
        public System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> normals;
        public System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> morphs;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.MeshLight> lights;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonNg> polygons;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshMaterialInfo> materialInfos;
        public uint polygonsPtr;
        public uint verticesPtr;
        public uint normalsPtr;
        public uint lightsPtr;
        public uint morphsPtr;
        public uint materialsPtr;
        public bool filePtr;
        public uint unk04;
        public uint unk08;
        public uint parentCount;
        public float unk40;
        public float unk44;
        public float unk72;
        public float unk76;
        public float unk80;
        public float unk84;

        public MeshNg(System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> vertices, System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> normals, System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> morphs, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.MeshLight> lights, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonNg> polygons, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshMaterialInfo> materialInfos, uint polygonsPtr, uint verticesPtr, uint normalsPtr, uint lightsPtr, uint morphsPtr, uint materialsPtr, bool filePtr, uint unk04, uint unk08, uint parentCount, float unk40, float unk44, float unk72, float unk76, float unk80, float unk84)
        {
            this.vertices = vertices;
            this.normals = normals;
            this.morphs = morphs;
            this.lights = lights;
            this.polygons = polygons;
            this.materialInfos = materialInfos;
            this.polygonsPtr = polygonsPtr;
            this.verticesPtr = verticesPtr;
            this.normalsPtr = normalsPtr;
            this.lightsPtr = lightsPtr;
            this.morphsPtr = morphsPtr;
            this.materialsPtr = materialsPtr;
            this.filePtr = filePtr;
            this.unk04 = unk04;
            this.unk08 = unk08;
            this.parentCount = parentCount;
            this.unk40 = unk40;
            this.unk44 = unk44;
            this.unk72 = unk72;
            this.unk76 = unk76;
            this.unk80 = unk80;
            this.unk84 = unk84;
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>> vertices;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>> normals;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>> morphs;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.MeshLight>> lights;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonNg>> polygons;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshMaterialInfo>> materialInfos;
            public Field<uint> polygonsPtr;
            public Field<uint> verticesPtr;
            public Field<uint> normalsPtr;
            public Field<uint> lightsPtr;
            public Field<uint> morphsPtr;
            public Field<uint> materialsPtr;
            public Field<bool> filePtr;
            public Field<uint> unk04;
            public Field<uint> unk08;
            public Field<uint> parentCount;
            public Field<float> unk40;
            public Field<float> unk44;
            public Field<float> unk72;
            public Field<float> unk76;
            public Field<float> unk80;
            public Field<float> unk84;
        }

        public static void Serialize(MeshNg v, Serializer s)
        {
            s.SerializeStruct(22);
            s.SerializeFieldName("vertices");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))(v.vertices);
            s.SerializeFieldName("normals");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))(v.normals);
            s.SerializeFieldName("morphs");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))(v.morphs);
            s.SerializeFieldName("lights");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.MeshLight.Converter))(v.lights);
            s.SerializeFieldName("polygons");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonNg.Converter))(v.polygons);
            s.SerializeFieldName("material_infos");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Ng.MeshMaterialInfo.Converter))(v.materialInfos);
            s.SerializeFieldName("polygons_ptr");
            ((Action<uint>)s.SerializeU32)(v.polygonsPtr);
            s.SerializeFieldName("vertices_ptr");
            ((Action<uint>)s.SerializeU32)(v.verticesPtr);
            s.SerializeFieldName("normals_ptr");
            ((Action<uint>)s.SerializeU32)(v.normalsPtr);
            s.SerializeFieldName("lights_ptr");
            ((Action<uint>)s.SerializeU32)(v.lightsPtr);
            s.SerializeFieldName("morphs_ptr");
            ((Action<uint>)s.SerializeU32)(v.morphsPtr);
            s.SerializeFieldName("materials_ptr");
            ((Action<uint>)s.SerializeU32)(v.materialsPtr);
            s.SerializeFieldName("file_ptr");
            ((Action<bool>)s.SerializeBool)(v.filePtr);
            s.SerializeFieldName("unk04");
            ((Action<uint>)s.SerializeU32)(v.unk04);
            s.SerializeFieldName("unk08");
            ((Action<uint>)s.SerializeU32)(v.unk08);
            s.SerializeFieldName("parent_count");
            ((Action<uint>)s.SerializeU32)(v.parentCount);
            s.SerializeFieldName("unk40");
            ((Action<float>)s.SerializeF32)(v.unk40);
            s.SerializeFieldName("unk44");
            ((Action<float>)s.SerializeF32)(v.unk44);
            s.SerializeFieldName("unk72");
            ((Action<float>)s.SerializeF32)(v.unk72);
            s.SerializeFieldName("unk76");
            ((Action<float>)s.SerializeF32)(v.unk76);
            s.SerializeFieldName("unk80");
            ((Action<float>)s.SerializeF32)(v.unk80);
            s.SerializeFieldName("unk84");
            ((Action<float>)s.SerializeF32)(v.unk84);
        }

        public static MeshNg Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                vertices = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>>(),
                normals = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>>(),
                morphs = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>>(),
                lights = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.MeshLight>>(),
                polygons = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonNg>>(),
                materialInfos = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshMaterialInfo>>(),
                polygonsPtr = new Field<uint>(),
                verticesPtr = new Field<uint>(),
                normalsPtr = new Field<uint>(),
                lightsPtr = new Field<uint>(),
                morphsPtr = new Field<uint>(),
                materialsPtr = new Field<uint>(),
                filePtr = new Field<bool>(),
                unk04 = new Field<uint>(),
                unk08 = new Field<uint>(),
                parentCount = new Field<uint>(),
                unk40 = new Field<float>(),
                unk44 = new Field<float>(),
                unk72 = new Field<float>(),
                unk76 = new Field<float>(),
                unk80 = new Field<float>(),
                unk84 = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "vertices":
                        fields.vertices.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))();
                        break;
                    case "normals":
                        fields.normals.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))();
                        break;
                    case "morphs":
                        fields.morphs.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))();
                        break;
                    case "lights":
                        fields.lights.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.MeshLight.Converter))();
                        break;
                    case "polygons":
                        fields.polygons.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.Ng.PolygonNg.Converter))();
                        break;
                    case "material_infos":
                        fields.materialInfos.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.Ng.MeshMaterialInfo.Converter))();
                        break;
                    case "polygons_ptr":
                        fields.polygonsPtr.Value = d.DeserializeU32();
                        break;
                    case "vertices_ptr":
                        fields.verticesPtr.Value = d.DeserializeU32();
                        break;
                    case "normals_ptr":
                        fields.normalsPtr.Value = d.DeserializeU32();
                        break;
                    case "lights_ptr":
                        fields.lightsPtr.Value = d.DeserializeU32();
                        break;
                    case "morphs_ptr":
                        fields.morphsPtr.Value = d.DeserializeU32();
                        break;
                    case "materials_ptr":
                        fields.materialsPtr.Value = d.DeserializeU32();
                        break;
                    case "file_ptr":
                        fields.filePtr.Value = d.DeserializeBool();
                        break;
                    case "unk04":
                        fields.unk04.Value = d.DeserializeU32();
                        break;
                    case "unk08":
                        fields.unk08.Value = d.DeserializeU32();
                        break;
                    case "parent_count":
                        fields.parentCount.Value = d.DeserializeU32();
                        break;
                    case "unk40":
                        fields.unk40.Value = d.DeserializeF32();
                        break;
                    case "unk44":
                        fields.unk44.Value = d.DeserializeF32();
                        break;
                    case "unk72":
                        fields.unk72.Value = d.DeserializeF32();
                        break;
                    case "unk76":
                        fields.unk76.Value = d.DeserializeF32();
                        break;
                    case "unk80":
                        fields.unk80.Value = d.DeserializeF32();
                        break;
                    case "unk84":
                        fields.unk84.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("MeshNg", fieldName);
                }
            }
            return new MeshNg(

                fields.vertices.Unwrap("MeshNg", "vertices"),

                fields.normals.Unwrap("MeshNg", "normals"),

                fields.morphs.Unwrap("MeshNg", "morphs"),

                fields.lights.Unwrap("MeshNg", "lights"),

                fields.polygons.Unwrap("MeshNg", "polygons"),

                fields.materialInfos.Unwrap("MeshNg", "materialInfos"),

                fields.polygonsPtr.Unwrap("MeshNg", "polygonsPtr"),

                fields.verticesPtr.Unwrap("MeshNg", "verticesPtr"),

                fields.normalsPtr.Unwrap("MeshNg", "normalsPtr"),

                fields.lightsPtr.Unwrap("MeshNg", "lightsPtr"),

                fields.morphsPtr.Unwrap("MeshNg", "morphsPtr"),

                fields.materialsPtr.Unwrap("MeshNg", "materialsPtr"),

                fields.filePtr.Unwrap("MeshNg", "filePtr"),

                fields.unk04.Unwrap("MeshNg", "unk04"),

                fields.unk08.Unwrap("MeshNg", "unk08"),

                fields.parentCount.Unwrap("MeshNg", "parentCount"),

                fields.unk40.Unwrap("MeshNg", "unk40"),

                fields.unk44.Unwrap("MeshNg", "unk44"),

                fields.unk72.Unwrap("MeshNg", "unk72"),

                fields.unk76.Unwrap("MeshNg", "unk76"),

                fields.unk80.Unwrap("MeshNg", "unk80"),

                fields.unk84.Unwrap("MeshNg", "unk84")

            );
        }
    }
}
