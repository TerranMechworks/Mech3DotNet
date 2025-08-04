using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Model
{
    public sealed class Model
    {
        public static readonly TypeConverter<Model> Converter = new TypeConverter<Model>(Deserialize, Serialize);
        public Mech3DotNet.Types.Gamez.Model.ModelType modelType;
        public Mech3DotNet.Types.Gamez.Model.FacadeMode facadeMode;
        public Mech3DotNet.Types.Gamez.Model.ModelFlags flags;
        public uint parentCount;
        public System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3> vertices;
        public System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3> normals;
        public System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3> morphs;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.PointLight> lights;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.Polygon> polygons;
        public Mech3DotNet.Types.Gamez.Model.UvCoord textureScroll;
        public Mech3DotNet.Types.Common.Vec3 bboxMid;
        public float bboxDiag;
        public uint polygonsPtr;
        public uint verticesPtr;
        public uint normalsPtr;
        public uint lightsPtr;
        public uint morphsPtr;
        public uint materialRefsPtr;

        public Model(Mech3DotNet.Types.Gamez.Model.ModelType modelType, Mech3DotNet.Types.Gamez.Model.FacadeMode facadeMode, Mech3DotNet.Types.Gamez.Model.ModelFlags flags, uint parentCount, System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3> vertices, System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3> normals, System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3> morphs, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.PointLight> lights, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.Polygon> polygons, Mech3DotNet.Types.Gamez.Model.UvCoord textureScroll, Mech3DotNet.Types.Common.Vec3 bboxMid, float bboxDiag, uint polygonsPtr, uint verticesPtr, uint normalsPtr, uint lightsPtr, uint morphsPtr, uint materialRefsPtr)
        {
            this.modelType = modelType;
            this.facadeMode = facadeMode;
            this.flags = flags;
            this.parentCount = parentCount;
            this.vertices = vertices;
            this.normals = normals;
            this.morphs = morphs;
            this.lights = lights;
            this.polygons = polygons;
            this.textureScroll = textureScroll;
            this.bboxMid = bboxMid;
            this.bboxDiag = bboxDiag;
            this.polygonsPtr = polygonsPtr;
            this.verticesPtr = verticesPtr;
            this.normalsPtr = normalsPtr;
            this.lightsPtr = lightsPtr;
            this.morphsPtr = morphsPtr;
            this.materialRefsPtr = materialRefsPtr;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Gamez.Model.ModelType> modelType;
            public Field<Mech3DotNet.Types.Gamez.Model.FacadeMode> facadeMode;
            public Field<Mech3DotNet.Types.Gamez.Model.ModelFlags> flags;
            public Field<uint> parentCount;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3>> vertices;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3>> normals;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3>> morphs;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.PointLight>> lights;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.Polygon>> polygons;
            public Field<Mech3DotNet.Types.Gamez.Model.UvCoord> textureScroll;
            public Field<Mech3DotNet.Types.Common.Vec3> bboxMid;
            public Field<float> bboxDiag;
            public Field<uint> polygonsPtr;
            public Field<uint> verticesPtr;
            public Field<uint> normalsPtr;
            public Field<uint> lightsPtr;
            public Field<uint> morphsPtr;
            public Field<uint> materialRefsPtr;
        }

        public static void Serialize(Model v, Serializer s)
        {
            s.SerializeStruct(18);
            s.SerializeFieldName("model_type");
            s.Serialize(Mech3DotNet.Types.Gamez.Model.ModelTypeConverter.Converter)(v.modelType);
            s.SerializeFieldName("facade_mode");
            s.Serialize(Mech3DotNet.Types.Gamez.Model.FacadeModeConverter.Converter)(v.facadeMode);
            s.SerializeFieldName("flags");
            s.Serialize(Mech3DotNet.Types.Gamez.Model.ModelFlagsConverter.Converter)(v.flags);
            s.SerializeFieldName("parent_count");
            ((Action<uint>)s.SerializeU32)(v.parentCount);
            s.SerializeFieldName("vertices");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.vertices);
            s.SerializeFieldName("normals");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.normals);
            s.SerializeFieldName("morphs");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.morphs);
            s.SerializeFieldName("lights");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Model.PointLight.Converter))(v.lights);
            s.SerializeFieldName("polygons");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Model.Polygon.Converter))(v.polygons);
            s.SerializeFieldName("texture_scroll");
            s.Serialize(Mech3DotNet.Types.Gamez.Model.UvCoordConverter.Converter)(v.textureScroll);
            s.SerializeFieldName("bbox_mid");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.bboxMid);
            s.SerializeFieldName("bbox_diag");
            ((Action<float>)s.SerializeF32)(v.bboxDiag);
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
            s.SerializeFieldName("material_refs_ptr");
            ((Action<uint>)s.SerializeU32)(v.materialRefsPtr);
        }

        public static Model Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                modelType = new Field<Mech3DotNet.Types.Gamez.Model.ModelType>(),
                facadeMode = new Field<Mech3DotNet.Types.Gamez.Model.FacadeMode>(),
                flags = new Field<Mech3DotNet.Types.Gamez.Model.ModelFlags>(),
                parentCount = new Field<uint>(),
                vertices = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3>>(),
                normals = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3>>(),
                morphs = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3>>(),
                lights = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.PointLight>>(),
                polygons = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.Polygon>>(),
                textureScroll = new Field<Mech3DotNet.Types.Gamez.Model.UvCoord>(),
                bboxMid = new Field<Mech3DotNet.Types.Common.Vec3>(),
                bboxDiag = new Field<float>(),
                polygonsPtr = new Field<uint>(),
                verticesPtr = new Field<uint>(),
                normalsPtr = new Field<uint>(),
                lightsPtr = new Field<uint>(),
                morphsPtr = new Field<uint>(),
                materialRefsPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "model_type":
                        fields.modelType.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Model.ModelTypeConverter.Converter)();
                        break;
                    case "facade_mode":
                        fields.facadeMode.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Model.FacadeModeConverter.Converter)();
                        break;
                    case "flags":
                        fields.flags.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Model.ModelFlagsConverter.Converter)();
                        break;
                    case "parent_count":
                        fields.parentCount.Value = d.DeserializeU32();
                        break;
                    case "vertices":
                        fields.vertices.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "normals":
                        fields.normals.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "morphs":
                        fields.morphs.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "lights":
                        fields.lights.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Model.PointLight.Converter))();
                        break;
                    case "polygons":
                        fields.polygons.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Model.Polygon.Converter))();
                        break;
                    case "texture_scroll":
                        fields.textureScroll.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Model.UvCoordConverter.Converter)();
                        break;
                    case "bbox_mid":
                        fields.bboxMid.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "bbox_diag":
                        fields.bboxDiag.Value = d.DeserializeF32();
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
                    case "material_refs_ptr":
                        fields.materialRefsPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Model", fieldName);
                }
            }
            return new Model(

                fields.modelType.Unwrap("Model", "modelType"),

                fields.facadeMode.Unwrap("Model", "facadeMode"),

                fields.flags.Unwrap("Model", "flags"),

                fields.parentCount.Unwrap("Model", "parentCount"),

                fields.vertices.Unwrap("Model", "vertices"),

                fields.normals.Unwrap("Model", "normals"),

                fields.morphs.Unwrap("Model", "morphs"),

                fields.lights.Unwrap("Model", "lights"),

                fields.polygons.Unwrap("Model", "polygons"),

                fields.textureScroll.Unwrap("Model", "textureScroll"),

                fields.bboxMid.Unwrap("Model", "bboxMid"),

                fields.bboxDiag.Unwrap("Model", "bboxDiag"),

                fields.polygonsPtr.Unwrap("Model", "polygonsPtr"),

                fields.verticesPtr.Unwrap("Model", "verticesPtr"),

                fields.normalsPtr.Unwrap("Model", "normalsPtr"),

                fields.lightsPtr.Unwrap("Model", "lightsPtr"),

                fields.morphsPtr.Unwrap("Model", "morphsPtr"),

                fields.materialRefsPtr.Unwrap("Model", "materialRefsPtr")

            );
        }
    }
}
