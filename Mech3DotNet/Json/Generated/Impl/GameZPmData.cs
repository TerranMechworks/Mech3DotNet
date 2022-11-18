namespace Mech3DotNet.Json.Gamez
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Converters.GameZPmDataConverter))]
    public class GameZPmData
    {
        public System.Collections.Generic.List<string> textures;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Materials.Material> materials;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Ng.MeshNg> meshes;
        public byte[] nodes;
        public Mech3DotNet.Json.Gamez.GameZPmMetadata metadata;

        public GameZPmData(System.Collections.Generic.List<string> textures, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Materials.Material> materials, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Ng.MeshNg> meshes, byte[] nodes, Mech3DotNet.Json.Gamez.GameZPmMetadata metadata)
        {
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
            this.metadata = metadata;
        }
    }
}
