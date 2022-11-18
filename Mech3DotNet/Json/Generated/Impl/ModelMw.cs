namespace Mech3DotNet.Json.Gamez.Mechlib
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Mechlib.Converters.ModelMwConverter))]
    public class ModelMw
    {
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Nodes.NodeMw> nodes;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Mw.MeshMw> meshes;
        public System.Collections.Generic.List<int> meshPtrs;

        public ModelMw(System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Nodes.NodeMw> nodes, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Mw.MeshMw> meshes, System.Collections.Generic.List<int> meshPtrs)
        {
            this.nodes = nodes;
            this.meshes = meshes;
            this.meshPtrs = meshPtrs;
        }
    }
}
