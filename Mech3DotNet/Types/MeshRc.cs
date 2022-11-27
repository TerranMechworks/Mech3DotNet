using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mesh.Rc
{
    public sealed class MeshRc
    {
        public static readonly TypeConverter<MeshRc> Converter = new TypeConverter<MeshRc>(Deserialize, Serialize);
        public System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> vertices;
        public System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> normals;
        public System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> morphs;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.MeshLight> lights;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Rc.PolygonRc> polygons;
        public uint polygonsPtr;
        public uint verticesPtr;
        public uint normalsPtr;
        public uint lightsPtr;
        public uint morphsPtr;
        public bool filePtr;
        public uint unk04;
        public uint parentCount;
        public float unk68;
        public float unk72;
        public float unk76;
        public float unk80;

        public MeshRc(System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> vertices, System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> normals, System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3> morphs, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.MeshLight> lights, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Rc.PolygonRc> polygons, uint polygonsPtr, uint verticesPtr, uint normalsPtr, uint lightsPtr, uint morphsPtr, bool filePtr, uint unk04, uint parentCount, float unk68, float unk72, float unk76, float unk80)
        {
            this.vertices = vertices;
            this.normals = normals;
            this.morphs = morphs;
            this.lights = lights;
            this.polygons = polygons;
            this.polygonsPtr = polygonsPtr;
            this.verticesPtr = verticesPtr;
            this.normalsPtr = normalsPtr;
            this.lightsPtr = lightsPtr;
            this.morphsPtr = morphsPtr;
            this.filePtr = filePtr;
            this.unk04 = unk04;
            this.parentCount = parentCount;
            this.unk68 = unk68;
            this.unk72 = unk72;
            this.unk76 = unk76;
            this.unk80 = unk80;
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>> vertices;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>> normals;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>> morphs;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.MeshLight>> lights;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Rc.PolygonRc>> polygons;
            public Field<uint> polygonsPtr;
            public Field<uint> verticesPtr;
            public Field<uint> normalsPtr;
            public Field<uint> lightsPtr;
            public Field<uint> morphsPtr;
            public Field<bool> filePtr;
            public Field<uint> unk04;
            public Field<uint> parentCount;
            public Field<float> unk68;
            public Field<float> unk72;
            public Field<float> unk76;
            public Field<float> unk80;
        }

        public static void Serialize(Mech3DotNet.Types.Gamez.Mesh.Rc.MeshRc v, Serializer s)
        {
            s.SerializeStruct("MeshRc", 17);
            s.SerializeFieldName("vertices");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Types.Vec3.Converter))(v.vertices);
            s.SerializeFieldName("normals");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Types.Vec3.Converter))(v.normals);
            s.SerializeFieldName("morphs");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Types.Vec3.Converter))(v.morphs);
            s.SerializeFieldName("lights");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.MeshLight.Converter))(v.lights);
            s.SerializeFieldName("polygons");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Rc.PolygonRc.Converter))(v.polygons);
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
            s.SerializeFieldName("file_ptr");
            ((Action<bool>)s.SerializeBool)(v.filePtr);
            s.SerializeFieldName("unk04");
            ((Action<uint>)s.SerializeU32)(v.unk04);
            s.SerializeFieldName("parent_count");
            ((Action<uint>)s.SerializeU32)(v.parentCount);
            s.SerializeFieldName("unk68");
            ((Action<float>)s.SerializeF32)(v.unk68);
            s.SerializeFieldName("unk72");
            ((Action<float>)s.SerializeF32)(v.unk72);
            s.SerializeFieldName("unk76");
            ((Action<float>)s.SerializeF32)(v.unk76);
            s.SerializeFieldName("unk80");
            ((Action<float>)s.SerializeF32)(v.unk80);
        }

        public static Mech3DotNet.Types.Gamez.Mesh.Rc.MeshRc Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                vertices = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>>(),
                normals = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>>(),
                morphs = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Types.Vec3>>(),
                lights = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.MeshLight>>(),
                polygons = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Rc.PolygonRc>>(),
                polygonsPtr = new Field<uint>(),
                verticesPtr = new Field<uint>(),
                normalsPtr = new Field<uint>(),
                lightsPtr = new Field<uint>(),
                morphsPtr = new Field<uint>(),
                filePtr = new Field<bool>(),
                unk04 = new Field<uint>(),
                parentCount = new Field<uint>(),
                unk68 = new Field<float>(),
                unk72 = new Field<float>(),
                unk76 = new Field<float>(),
                unk80 = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct("MeshRc"))
            {
                switch (fieldName)
                {
                    case "vertices":
                        fields.vertices.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Types.Vec3.Converter))();
                        break;
                    case "normals":
                        fields.normals.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Types.Vec3.Converter))();
                        break;
                    case "morphs":
                        fields.morphs.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Types.Vec3.Converter))();
                        break;
                    case "lights":
                        fields.lights.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.MeshLight.Converter))();
                        break;
                    case "polygons":
                        fields.polygons.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.Rc.PolygonRc.Converter))();
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
                    case "file_ptr":
                        fields.filePtr.Value = d.DeserializeBool();
                        break;
                    case "unk04":
                        fields.unk04.Value = d.DeserializeU32();
                        break;
                    case "parent_count":
                        fields.parentCount.Value = d.DeserializeU32();
                        break;
                    case "unk68":
                        fields.unk68.Value = d.DeserializeF32();
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
                    default:
                        throw new UnknownFieldException("MeshRc", fieldName);
                }
            }
            return new MeshRc(

                fields.vertices.Unwrap("MeshRc", "vertices"),

                fields.normals.Unwrap("MeshRc", "normals"),

                fields.morphs.Unwrap("MeshRc", "morphs"),

                fields.lights.Unwrap("MeshRc", "lights"),

                fields.polygons.Unwrap("MeshRc", "polygons"),

                fields.polygonsPtr.Unwrap("MeshRc", "polygonsPtr"),

                fields.verticesPtr.Unwrap("MeshRc", "verticesPtr"),

                fields.normalsPtr.Unwrap("MeshRc", "normalsPtr"),

                fields.lightsPtr.Unwrap("MeshRc", "lightsPtr"),

                fields.morphsPtr.Unwrap("MeshRc", "morphsPtr"),

                fields.filePtr.Unwrap("MeshRc", "filePtr"),

                fields.unk04.Unwrap("MeshRc", "unk04"),

                fields.parentCount.Unwrap("MeshRc", "parentCount"),

                fields.unk68.Unwrap("MeshRc", "unk68"),

                fields.unk72.Unwrap("MeshRc", "unk72"),

                fields.unk76.Unwrap("MeshRc", "unk76"),

                fields.unk80.Unwrap("MeshRc", "unk80")

            );
        }
    }
}
