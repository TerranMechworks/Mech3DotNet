using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class Polygon<V2, Color>
    {
        [JsonProperty("vertex_indices", Required = Required.Always)]
        public List<uint> vertexIndices;
        [JsonProperty("vertex_colors", Required = Required.Always)]
        public List<Color> vertexColors;
        [JsonProperty("normal_indices", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<uint>? normalIndices = null;
        [JsonProperty("uv_coords", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<V2>? uvCoords = null;
        [JsonProperty("texture_index", Required = Required.Always)]
        public uint textureIndex;
        [JsonProperty("texture_info", Required = Required.Always)]
        public uint textureInfo;
        [JsonProperty("unk04", Required = Required.Always)]
        public uint unk04;
        [JsonProperty("unk_bit", Required = Required.Always)]
        public bool unkBit;
        [JsonProperty("vtx_bit", Required = Required.Always)]
        public bool vtxBit;
        [JsonProperty("vertices_ptr", Required = Required.Always)]
        public uint verticesPtr;
        [JsonProperty("normals_ptr", Required = Required.Always)]
        public uint normalsPtr;
        [JsonProperty("uvs_ptr", Required = Required.Always)]
        public uint uvsPtr;
        [JsonProperty("colors_ptr", Required = Required.Always)]
        public uint colorsPtr;
        [JsonProperty("unk_ptr", Required = Required.Always)]
        public uint unkPtr;

        public Polygon(List<uint> vertexIndices, List<Color> vertexColors, List<uint> normalIndices, List<V2> uvCoords, uint textureIndex, uint textureInfo, uint unk04, bool unkBit, bool vtxBit, uint verticesPtr, uint normalsPtr, uint uvsPtr, uint colorsPtr, uint unkPtr)
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

        [JsonConstructor]
        private Polygon() { }
    }
}
