namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ModelMwConverter))]
    public class ModelMw
    {
        public System.Collections.Generic.List<NodeMw> nodes;
        public System.Collections.Generic.List<MeshMw> meshes;
        public System.Collections.Generic.List<int> meshPtrs;

        public ModelMw(System.Collections.Generic.List<NodeMw> nodes, System.Collections.Generic.List<MeshMw> meshes, System.Collections.Generic.List<int> meshPtrs)
        {
            this.nodes = nodes;
            this.meshes = meshes;
            this.meshPtrs = meshPtrs;
        }
    }
}
