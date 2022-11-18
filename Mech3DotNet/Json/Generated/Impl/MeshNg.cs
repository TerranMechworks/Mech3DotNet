namespace Mech3DotNet.Json.Gamez.Mesh.Ng
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Mesh.Ng.Converters.MeshNgConverter))]
    public class MeshNg
    {
        public System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3> vertices;
        public System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3> normals;
        public System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3> morphs;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.MeshLight> lights;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Ng.PolygonNg> polygons;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Ng.MeshTexture> textures;
        public uint polygonsPtr;
        public uint verticesPtr;
        public uint normalsPtr;
        public uint lightsPtr;
        public uint morphsPtr;
        public uint texturePtr;
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

        public MeshNg(System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3> vertices, System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3> normals, System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3> morphs, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.MeshLight> lights, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Ng.PolygonNg> polygons, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Ng.MeshTexture> textures, uint polygonsPtr, uint verticesPtr, uint normalsPtr, uint lightsPtr, uint morphsPtr, uint texturePtr, bool filePtr, uint unk04, uint unk08, uint parentCount, float unk40, float unk44, float unk72, float unk76, float unk80, float unk84)
        {
            this.vertices = vertices;
            this.normals = normals;
            this.morphs = morphs;
            this.lights = lights;
            this.polygons = polygons;
            this.textures = textures;
            this.polygonsPtr = polygonsPtr;
            this.verticesPtr = verticesPtr;
            this.normalsPtr = normalsPtr;
            this.lightsPtr = lightsPtr;
            this.morphsPtr = morphsPtr;
            this.texturePtr = texturePtr;
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
