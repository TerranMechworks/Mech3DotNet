using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TupleConverter<Resolution>))]
    public struct Resolution
    {
        public uint x;
        public uint y;

        public Resolution(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
