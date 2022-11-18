using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(GameZRcDataConverter))]
    public class GameZRcData
    {
        public List<string> textures;
        public List<Material> materials;
        public List<MeshRc> meshes;
        public byte[] nodes;
        public GameZRcMetadata metadata;

        public GameZRcData(List<string> textures, List<Material> materials, List<MeshRc> meshes, byte[] nodes, GameZRcMetadata metadata)
        {
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
            this.metadata = metadata;
        }
    }
}
