using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(PolygonMwConverter))]
    public class PolygonMw
    {
        public List<uint> vertexIndices;
        public List<Color> vertexColors;
        public List<uint>? normalIndices;
        public List<UvCoord>? uvCoords;
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

        public PolygonMw(List<uint> vertexIndices, List<Color> vertexColors, List<uint>? normalIndices, List<UvCoord>? uvCoords, uint textureIndex, uint textureInfo, int unk04, bool unkBit, bool vtxBit, uint verticesPtr, uint normalsPtr, uint uvsPtr, uint colorsPtr, uint unkPtr)
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
