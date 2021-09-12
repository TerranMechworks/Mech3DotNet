using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TupleConverter<AreaPartition>))]
    public class AreaPartition
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
