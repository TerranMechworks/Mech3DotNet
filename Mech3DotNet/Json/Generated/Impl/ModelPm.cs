namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ModelPmConverter))]
    public class ModelPm
    {
        public System.Collections.Generic.List<NodePm> nodes;
        public System.Collections.Generic.List<MeshNg> meshes;
        public System.Collections.Generic.List<int> meshPtrs;

        public ModelPm(System.Collections.Generic.List<NodePm> nodes, System.Collections.Generic.List<MeshNg> meshes, System.Collections.Generic.List<int> meshPtrs)
        {
            this.nodes = nodes;
            this.meshes = meshes;
            this.meshPtrs = meshPtrs;
        }
    }
}
