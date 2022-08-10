using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class GameZMetadata
    {
        [JsonProperty("material_array_size", Required = Required.Always)]
        public short materialArraySize;
        [JsonProperty("meshes_array_size", Required = Required.Always)]
        public int meshesArraySize;
        [JsonProperty("node_array_size", Required = Required.Always)]
        public uint nodeArraySize;
        [JsonProperty("node_data_count", Required = Required.Always)]
        public uint nodeDataCount;

        public GameZMetadata(short materialArraySize, int meshesArraySize, uint nodeArraySize, uint nodeDataCount)
        {
            this.materialArraySize = materialArraySize;
            this.meshesArraySize = meshesArraySize;
            this.nodeArraySize = nodeArraySize;
            this.nodeDataCount = nodeDataCount;
        }

        [JsonConstructor]
        private GameZMetadata() { }
    }
}
