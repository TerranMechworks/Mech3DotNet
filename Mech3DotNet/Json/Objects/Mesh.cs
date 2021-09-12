using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class Mesh<V2, V3, Color>
    {
        [JsonProperty("vertices", Required = Required.Always)]
        public List<V3> vertices;
        [JsonProperty("normals", Required = Required.Always)]
        public List<V3> normals;
        [JsonProperty("morphs", Required = Required.Always)]
        public List<V3> morphs;
        [JsonProperty("lights", Required = Required.Always)]
        public List<Light<V3>> lights;
        [JsonProperty("polygons", Required = Required.Always)]
        public List<Polygon<V2, Color>> polygons;
        [JsonProperty("polygons_ptr", Required = Required.Always)]
        public uint polygonsPtr;
        [JsonProperty("vertices_ptr", Required = Required.Always)]
        public uint verticesPtr;
        [JsonProperty("normals_ptr", Required = Required.Always)]
        public uint normalsPtr;
        [JsonProperty("lights_ptr", Required = Required.Always)]
        public uint lightsPtr;
        [JsonProperty("morphs_ptr", Required = Required.Always)]
        public uint morphsPtr;
        [JsonProperty("file_ptr", Required = Required.Always)]
        public bool filePtr;
        [JsonProperty("unk04", Required = Required.Always)]
        public bool unk04;
        [JsonProperty("unk08", Required = Required.Always)]
        public uint unk08;
        [JsonProperty("parent_count", Required = Required.Always)]
        public uint parentCount;
        [JsonProperty("unk40", Required = Required.Always)]
        public float unk40;
        [JsonProperty("unk44", Required = Required.Always)]
        public float unk44;
        [JsonProperty("unk72", Required = Required.Always)]
        public float unk72;
        [JsonProperty("unk76", Required = Required.Always)]
        public float unk76;
        [JsonProperty("unk80", Required = Required.Always)]
        public float unk80;
        [JsonProperty("unk84", Required = Required.Always)]
        public float unk84;

        public Mesh(List<V3> vertices, List<V3> normals, List<V3> morphs, List<Light<V3>> lights, List<Polygon<V2, Color>> polygons, uint polygonsPtr, uint verticesPtr, uint normalsPtr, uint lightsPtr, uint morphsPtr, bool filePtr, bool unk04, uint unk08, uint parentCount, float unk40, float unk44, float unk72, float unk76, float unk80, float unk84)
        {
            this.vertices = vertices ?? throw new ArgumentNullException(nameof(vertices));
            this.normals = normals ?? throw new ArgumentNullException(nameof(normals));
            this.morphs = morphs ?? throw new ArgumentNullException(nameof(morphs));
            this.lights = lights ?? throw new ArgumentNullException(nameof(lights));
            this.polygons = polygons ?? throw new ArgumentNullException(nameof(polygons));
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

        [JsonConstructor]
        private Mesh() { }

    }
}
