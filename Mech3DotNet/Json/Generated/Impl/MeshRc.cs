namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.MeshRcConverter))]
    public class MeshRc
    {
        public System.Collections.Generic.List<Vec3> vertices;
        public System.Collections.Generic.List<Vec3> normals;
        public System.Collections.Generic.List<Vec3> morphs;
        public System.Collections.Generic.List<MeshLight> lights;
        public System.Collections.Generic.List<PolygonRc> polygons;
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

        public MeshRc(System.Collections.Generic.List<Vec3> vertices, System.Collections.Generic.List<Vec3> normals, System.Collections.Generic.List<Vec3> morphs, System.Collections.Generic.List<MeshLight> lights, System.Collections.Generic.List<PolygonRc> polygons, uint polygonsPtr, uint verticesPtr, uint normalsPtr, uint lightsPtr, uint morphsPtr, bool filePtr, uint unk04, uint parentCount, float unk68, float unk72, float unk76, float unk80)
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
