using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(GameZPmDataConverter))]
    public class GameZPmData
    {
        public List<string> textures;
        public List<Material> materials;
        public List<MeshNg> meshes;
        public byte[] nodes;
        public GameZPmMetadata metadata;

        public GameZPmData(List<string> textures, List<Material> materials, List<MeshNg> meshes, byte[] nodes, GameZPmMetadata metadata)
        {
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
            this.metadata = metadata;
        }
    }
}
