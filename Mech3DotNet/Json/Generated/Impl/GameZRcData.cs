namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.GameZRcDataConverter))]
    public class GameZRcData
    {
        public System.Collections.Generic.List<string> textures;
        public System.Collections.Generic.List<Material> materials;
        public System.Collections.Generic.List<MeshRc> meshes;
        public byte[] nodes;
        public GameZRcMetadata metadata;

        public GameZRcData(System.Collections.Generic.List<string> textures, System.Collections.Generic.List<Material> materials, System.Collections.Generic.List<MeshRc> meshes, byte[] nodes, GameZRcMetadata metadata)
        {
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
            this.metadata = metadata;
        }
    }
}
