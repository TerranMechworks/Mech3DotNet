using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ModelPmConverter))]
    public class ModelPm
    {
        public List<NodePm> nodes;
        public List<MeshNg> meshes;
        public List<int> meshPtrs;

        public ModelPm(List<NodePm> nodes, List<MeshNg> meshes, List<int> meshPtrs)
        {
            this.nodes = nodes;
            this.meshes = meshes;
            this.meshPtrs = meshPtrs;
        }
    }
}
