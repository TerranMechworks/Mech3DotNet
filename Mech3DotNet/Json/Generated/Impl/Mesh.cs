using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(MeshConverter))]
    public class Mesh
    {
        public List<Vec3> vertices;
        public List<Vec3> normals;
        public List<Vec3> morphs;
        public List<MeshLight> lights;
        public List<Polygon> polygons;
        public uint polygonsPtr;
        public uint verticesPtr;
        public uint normalsPtr;
        public uint lightsPtr;
        public uint morphsPtr;
        public bool filePtr;
        public bool unk04;
        public uint unk08;
        public uint parentCount;
        public float unk40;
        public float unk44;
        public float unk72;
        public float unk76;
        public float unk80;
        public float unk84;

        public Mesh(List<Vec3> vertices, List<Vec3> normals, List<Vec3> morphs, List<MeshLight> lights, List<Polygon> polygons, uint polygonsPtr, uint verticesPtr, uint normalsPtr, uint lightsPtr, uint morphsPtr, bool filePtr, bool unk04, uint unk08, uint parentCount, float unk40, float unk44, float unk72, float unk76, float unk80, float unk84)
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
            this.unk08 = unk08;
            this.parentCount = parentCount;
            this.unk40 = unk40;
            this.unk44 = unk44;
            this.unk72 = unk72;
            this.unk76 = unk76;
            this.unk80 = unk80;
            this.unk84 = unk84;
        }
    }
}
