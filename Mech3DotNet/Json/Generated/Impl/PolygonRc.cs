using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(PolygonRcConverter))]
    public class PolygonRc
    {
        public List<uint> vertexIndices;
        public List<uint>? normalIndices;
        public List<UvCoord>? uvCoords;
        public uint textureIndex;
        public bool unk0Flag;
        public int unk04;
        public uint unk24;
        public uint verticesPtr;
        public uint normalsPtr;
        public uint uvsPtr;

        public PolygonRc(List<uint> vertexIndices, List<uint>? normalIndices, List<UvCoord>? uvCoords, uint textureIndex, bool unk0Flag, int unk04, uint unk24, uint verticesPtr, uint normalsPtr, uint uvsPtr)
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
