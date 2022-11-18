namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.GameZMwMetadataConverter))]
    public class GameZMwMetadata
    {
        public short materialArraySize;
        public int meshesArraySize;
        public uint nodeArraySize;
        public uint nodeDataCount;

        public GameZMwMetadata(short materialArraySize, int meshesArraySize, uint nodeArraySize, uint nodeDataCount)
        {
            this.materialArraySize = materialArraySize;
            this.meshesArraySize = meshesArraySize;
            this.nodeArraySize = nodeArraySize;
            this.nodeDataCount = nodeDataCount;
        }
    }
}
