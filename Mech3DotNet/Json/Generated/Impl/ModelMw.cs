using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ModelMwConverter))]
    public class ModelMw
    {
        public List<NodeMw> nodes;
        public List<MeshMw> meshes;
        public List<int> meshPtrs;

        public ModelMw(List<NodeMw> nodes, List<MeshMw> meshes, List<int> meshPtrs)
        {
            this.nodes = nodes;
            this.meshes = meshes;
            this.meshPtrs = meshPtrs;
        }
    }
}
