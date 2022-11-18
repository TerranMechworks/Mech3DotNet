using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(PolygonNgConverter))]
    public class PolygonNg
    {
        public PolygonFlags flags;
        public List<uint> vertexIndices;
        public List<Color> vertexColors;
        public List<uint>? normalIndices;
        public List<PolygonTextureNg> textures;
        public int unk04;
        public uint verticesPtr;
        public uint normalsPtr;
        public uint uvsPtr;
        public uint colorsPtr;
        public uint unk28;
        public uint unk32;
        public uint unk36;

        public PolygonNg(PolygonFlags flags, List<uint> vertexIndices, List<Color> vertexColors, List<uint>? normalIndices, List<PolygonTextureNg> textures, int unk04, uint verticesPtr, uint normalsPtr, uint uvsPtr, uint colorsPtr, uint unk28, uint unk32, uint unk36)
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
