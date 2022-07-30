using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TupleConverter<Vec2>))]
    public struct Vec2
    {
        public float x;
        public float y;

        public Vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
