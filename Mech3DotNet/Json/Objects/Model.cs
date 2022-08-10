using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class Model
    {
        [JsonProperty("root", Required = Required.Always)]
        public ResolvedNode root;
        [JsonProperty("meshes", Required = Required.Always)]
        public List<Mesh> meshes;
        [JsonProperty("mesh_ptrs", Required = Required.Always)]
        public List<int> meshPtrs;

        public Model(ResolvedNode root, List<Mesh> meshes, List<int> meshPtrs)
        {
            this.root = root;
            this.meshes = meshes;
            this.meshPtrs = meshPtrs;
        }

        [JsonConstructor]
        private Model() { }
    }
}
