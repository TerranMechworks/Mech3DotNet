using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TupleConverter<Vec3>))]
    public struct Vec3
    {
        public float x;
        public float y;
        public float z;

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
