using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(GameZDataConverter))]
    public class GameZData
    {
        public GameZMetadata metadata;
        public List<string> textures;
        public List<Material> materials;
        public List<Mesh> meshes;
        public List<Node> nodes;

        public GameZData(GameZMetadata metadata, List<string> textures, List<Material> materials, List<Mesh> meshes, List<Node> nodes)
        {
            this.metadata = metadata;
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
        }
    }
}
