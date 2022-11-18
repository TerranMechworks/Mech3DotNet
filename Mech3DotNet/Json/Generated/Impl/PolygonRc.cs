namespace Mech3DotNet.Json.Gamez.Mesh.Rc
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Mesh.Rc.Converters.PolygonRcConverter))]
    public class PolygonRc
    {
        public System.Collections.Generic.List<uint> vertexIndices;
        public System.Collections.Generic.List<uint>? normalIndices;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.UvCoord>? uvCoords;
        public uint textureIndex;
        public bool unk0Flag;
        public int unk04;
        public uint unk24;
        public uint verticesPtr;
        public uint normalsPtr;
        public uint uvsPtr;

        public PolygonRc(System.Collections.Generic.List<uint> vertexIndices, System.Collections.Generic.List<uint>? normalIndices, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.UvCoord>? uvCoords, uint textureIndex, bool unk0Flag, int unk04, uint unk24, uint verticesPtr, uint normalsPtr, uint uvsPtr)
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
    }
}
