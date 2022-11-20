namespace Mech3DotNet.Json.Gamez
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Converters.GameZMwDataConverter))]
    public class GameZMwData
    {
        public System.Collections.Generic.List<string> textures;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Materials.Material> materials;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Mw.MeshMw> meshes;
        public System.Collections.Generic.List<Mech3DotNet.Json.Nodes.Mw.NodeMw> nodes;
        public Mech3DotNet.Json.Gamez.GameZMwMetadata metadata;

        public GameZMwData(System.Collections.Generic.List<string> textures, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Materials.Material> materials, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Mw.MeshMw> meshes, System.Collections.Generic.List<Mech3DotNet.Json.Nodes.Mw.NodeMw> nodes, Mech3DotNet.Json.Gamez.GameZMwMetadata metadata)
        {
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
            this.metadata = metadata;
        }
    }
}
