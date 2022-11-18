namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.GameZCsDataConverter))]
    public class GameZCsData
    {
        public System.Collections.Generic.List<string> textures;
        public System.Collections.Generic.List<Material> materials;
        public System.Collections.Generic.List<MeshNg?> meshes;
        public byte[] nodes;
        public GameZCsMetadata metadata;

        public GameZCsData(System.Collections.Generic.List<string> textures, System.Collections.Generic.List<Material> materials, System.Collections.Generic.List<MeshNg?> meshes, byte[] nodes, GameZCsMetadata metadata)
        {
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
            this.metadata = metadata;
        }
    }
}
