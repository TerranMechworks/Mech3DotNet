namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.GameZMwDataConverter))]
    public class GameZMwData
    {
        public System.Collections.Generic.List<string> textures;
        public System.Collections.Generic.List<Material> materials;
        public System.Collections.Generic.List<MeshMw> meshes;
        public System.Collections.Generic.List<NodeMw> nodes;
        public GameZMwMetadata metadata;

        public GameZMwData(System.Collections.Generic.List<string> textures, System.Collections.Generic.List<Material> materials, System.Collections.Generic.List<MeshMw> meshes, System.Collections.Generic.List<NodeMw> nodes, GameZMwMetadata metadata)
        {
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
            this.metadata = metadata;
        }
    }
}
