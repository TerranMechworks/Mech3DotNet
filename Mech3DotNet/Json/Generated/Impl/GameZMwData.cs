using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(GameZMwDataConverter))]
    public class GameZMwData
    {
        public List<string> textures;
        public List<Material> materials;
        public List<MeshMw> meshes;
        public List<NodeMw> nodes;
        public GameZMwMetadata metadata;

        public GameZMwData(List<string> textures, List<Material> materials, List<MeshMw> meshes, List<NodeMw> nodes, GameZMwMetadata metadata)
        {
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
            this.metadata = metadata;
        }
    }
}
