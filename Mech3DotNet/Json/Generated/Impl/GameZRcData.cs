namespace Mech3DotNet.Json.Gamez
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Converters.GameZRcDataConverter))]
    public class GameZRcData
    {
        public System.Collections.Generic.List<string> textures;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Materials.Material> materials;
        public System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Rc.MeshRc> meshes;
        public byte[] nodes;
        public Mech3DotNet.Json.Gamez.GameZRcMetadata metadata;

        public GameZRcData(System.Collections.Generic.List<string> textures, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Materials.Material> materials, System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Rc.MeshRc> meshes, byte[] nodes, Mech3DotNet.Json.Gamez.GameZRcMetadata metadata)
        {
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
            this.metadata = metadata;
        }
    }
}
