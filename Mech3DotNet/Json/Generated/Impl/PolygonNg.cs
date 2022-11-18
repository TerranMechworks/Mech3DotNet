namespace Mech3DotNet.Json.Gamez.Mesh.Ng
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Mesh.Ng.Converters.PolygonNgConverter))]
    public class PolygonNg
    {
        public Mech3DotNet.Json.Gamez.Mesh.Ng.PolygonFlags flags;
        public System.Collections.Generic.List<uint> vertexIndices;
        public System.Collections.Generic.List<Mech3DotNet.Json.Types.Color> vertexColors;
        public System.Collections.Generic.List<uint>? normalIndices;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Ng.PolygonTextureNg> textures;
        public int unk04;
        public uint verticesPtr;
        public uint normalsPtr;
        public uint uvsPtr;
        public uint colorsPtr;
        public uint unk28;
        public uint unk32;
        public uint unk36;

        public PolygonNg(Mech3DotNet.Json.Gamez.Mesh.Ng.PolygonFlags flags, System.Collections.Generic.List<uint> vertexIndices, System.Collections.Generic.List<Mech3DotNet.Json.Types.Color> vertexColors, System.Collections.Generic.List<uint>? normalIndices, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Ng.PolygonTextureNg> textures, int unk04, uint verticesPtr, uint normalsPtr, uint uvsPtr, uint colorsPtr, uint unk28, uint unk32, uint unk36)
        {
            this.flags = flags;
            this.vertexIndices = vertexIndices;
            this.vertexColors = vertexColors;
            this.normalIndices = normalIndices;
            this.textures = textures;
            this.unk04 = unk04;
            this.verticesPtr = verticesPtr;
            this.normalsPtr = normalsPtr;
            this.uvsPtr = uvsPtr;
            this.colorsPtr = colorsPtr;
            this.unk28 = unk28;
            this.unk32 = unk32;
            this.unk36 = unk36;
        }
    }
}
