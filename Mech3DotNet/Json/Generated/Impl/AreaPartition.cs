namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.AreaPartitionConverter))]
    public struct AreaPartition
    {
        public int x;
        public int y;

        public AreaPartition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
