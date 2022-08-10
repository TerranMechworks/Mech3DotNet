using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ModelConverter))]
    public class Model
    {
        public List<Object3d> nodes;
        public List<Mesh> meshes;
        public List<int> meshPtrs;

        public Model(List<Object3d> nodes, List<Mesh> meshes, List<int> meshPtrs)
        {
            this.nodes = nodes;
            this.meshes = meshes;
            this.meshPtrs = meshPtrs;
        }
    }
}
