namespace Mech3DotNet.Json.Gamez
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Converters.GameZCsMetadataConverter))]
    public class GameZCsMetadata
    {
        public uint gamezHeaderUnk08;
        public short materialArraySize;
        public uint nodeArraySize;
        public uint nodeDataCount;
        public System.Collections.Generic.List<uint?> texturePtrs;

        public GameZCsMetadata(uint gamezHeaderUnk08, short materialArraySize, uint nodeArraySize, uint nodeDataCount, System.Collections.Generic.List<uint?> texturePtrs)
        {
            this.gamezHeaderUnk08 = gamezHeaderUnk08;
            this.materialArraySize = materialArraySize;
            this.nodeArraySize = nodeArraySize;
            this.nodeDataCount = nodeDataCount;
            this.texturePtrs = texturePtrs;
        }
    }
}
