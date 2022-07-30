using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TupleConverter<Range>))]
    public struct Range
    {
        public float near;
        public float far;

        public Range(float near, float far)
        {
            this.near = near;
            this.far = far;
        }
    }
}
