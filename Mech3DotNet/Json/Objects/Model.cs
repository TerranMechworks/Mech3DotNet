using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class Model<V2, V3, Color>
    {
        [JsonProperty("root", Required = Required.Always)]
        public ResolvedNode root;
        [JsonProperty("meshes", Required = Required.Always)]
        public List<Mesh<V2, V3, Color>> meshes;
        [JsonProperty("mesh_ptrs", Required = Required.Always)]
        public List<int> meshPtrs;

        public Model(ResolvedNode root, List<Mesh<V2, V3, Color>> meshes, List<int> meshPtrs)
        {
            this.root = root ?? throw new ArgumentNullException(nameof(root));
            this.meshes = meshes ?? throw new ArgumentNullException(nameof(meshes));
            this.meshPtrs = meshPtrs ?? throw new ArgumentNullException(nameof(meshPtrs));
        }

        [JsonConstructor]
        private Model() { }
    }
}
