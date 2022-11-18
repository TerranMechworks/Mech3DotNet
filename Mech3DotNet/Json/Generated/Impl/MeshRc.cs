using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(MeshRcConverter))]
    public class MeshRc
    {
        public List<Vec3> vertices;
        public List<Vec3> normals;
        public List<Vec3> morphs;
        public List<MeshLight> lights;
        public List<PolygonRc> polygons;
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

        public MeshRc(List<Vec3> vertices, List<Vec3> normals, List<Vec3> morphs, List<MeshLight> lights, List<PolygonRc> polygons, uint polygonsPtr, uint verticesPtr, uint normalsPtr, uint lightsPtr, uint morphsPtr, bool filePtr, uint unk04, uint parentCount, float unk68, float unk72, float unk76, float unk80)
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
    }
}
