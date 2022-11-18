namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.GameZPmMetadataConverter))]
    public class GameZPmMetadata
    {
        public uint gamezHeaderUnk08;
        public short materialArraySize;
        public int meshesArraySize;
        public uint nodeArraySize;
        public uint nodeDataCount;
        public System.Collections.Generic.List<uint?> texturePtrs;

        public GameZPmMetadata(uint gamezHeaderUnk08, short materialArraySize, int meshesArraySize, uint nodeArraySize, uint nodeDataCount, System.Collections.Generic.List<uint?> texturePtrs)
        {
            this.gamezHeaderUnk08 = gamezHeaderUnk08;
            this.materialArraySize = materialArraySize;
            this.meshesArraySize = meshesArraySize;
            this.nodeArraySize = nodeArraySize;
            this.nodeDataCount = nodeDataCount;
            this.texturePtrs = texturePtrs;
        }
    }
}
