using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class GameZData<V2, V3, Color>
    {
        [JsonProperty("metadata", Required = Required.Always)]
        public GameZMetadata metadata;
        [JsonProperty("textures", Required = Required.Always)]
        public List<string> textures;
        [JsonProperty("materials", Required = Required.Always)]
        public List<Material> materials;
        [JsonProperty("meshes", Required = Required.Always)]
        public List<Mesh<V2, V3, Color>> meshes;
        [JsonProperty("nodes", Required = Required.Always)]
        public List<IndexedNode> nodes;

        public GameZData(GameZMetadata metadata, List<string> textures, List<Material> materials, List<Mesh<V2, V3, Color>> meshes, List<IndexedNode> nodes)
        {
            this.metadata = metadata;
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
        }

        [JsonConstructor]
        private GameZData() { }
    }
}
