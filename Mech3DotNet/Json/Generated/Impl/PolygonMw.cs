namespace Mech3DotNet.Json.Gamez.Mesh.Mw
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Mesh.Mw.Converters.PolygonMwConverter))]
    public class PolygonMw
    {
        public System.Collections.Generic.List<uint> vertexIndices;
        public System.Collections.Generic.List<Mech3DotNet.Json.Types.Color> vertexColors;
        public System.Collections.Generic.List<uint>? normalIndices;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.UvCoord>? uvCoords;
        public uint textureIndex;
        public uint textureInfo;
        public int unk04;
        public bool unkBit;
        public bool vtxBit;
        public uint verticesPtr;
        public uint normalsPtr;
        public uint uvsPtr;
        public uint colorsPtr;
        public uint unkPtr;

        public PolygonMw(System.Collections.Generic.List<uint> vertexIndices, System.Collections.Generic.List<Mech3DotNet.Json.Types.Color> vertexColors, System.Collections.Generic.List<uint>? normalIndices, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.UvCoord>? uvCoords, uint textureIndex, uint textureInfo, int unk04, bool unkBit, bool vtxBit, uint verticesPtr, uint normalsPtr, uint uvsPtr, uint colorsPtr, uint unkPtr)
        {
            this.vertexIndices = vertexIndices;
            this.vertexColors = vertexColors;
            this.normalIndices = normalIndices;
            this.uvCoords = uvCoords;
            this.textureIndex = textureIndex;
            this.textureInfo = textureInfo;
            this.unk04 = unk04;
            this.unkBit = unkBit;
            this.vtxBit = vtxBit;
            this.verticesPtr = verticesPtr;
            this.normalsPtr = normalsPtr;
            this.uvsPtr = uvsPtr;
            this.colorsPtr = colorsPtr;
            this.unkPtr = unkPtr;
        }
    }
}
