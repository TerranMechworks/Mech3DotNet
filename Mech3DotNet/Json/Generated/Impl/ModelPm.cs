namespace Mech3DotNet.Json.Gamez.Mechlib
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Mechlib.Converters.ModelPmConverter))]
    public class ModelPm
    {
        public System.Collections.Generic.List<Mech3DotNet.Json.Nodes.Pm.NodePm> nodes;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Ng.MeshNg> meshes;
        public System.Collections.Generic.List<int> meshPtrs;

        public ModelPm(System.Collections.Generic.List<Mech3DotNet.Json.Nodes.Pm.NodePm> nodes, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Ng.MeshNg> meshes, System.Collections.Generic.List<int> meshPtrs)
        {
            this.nodes = nodes;
            this.meshes = meshes;
            this.meshPtrs = meshPtrs;
        }
    }
}
