namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.GameZPmDataConverter))]
    public class GameZPmData
    {
        public System.Collections.Generic.List<string> textures;
        public System.Collections.Generic.List<Material> materials;
        public System.Collections.Generic.List<MeshNg> meshes;
        public byte[] nodes;
        public GameZPmMetadata metadata;

        public GameZPmData(System.Collections.Generic.List<string> textures, System.Collections.Generic.List<Material> materials, System.Collections.Generic.List<MeshNg> meshes, byte[] nodes, GameZPmMetadata metadata)
        {
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
            this.metadata = metadata;
        }
    }
}
