using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TupleConverter<Range>))]
    public class Range
    {
        public float near;
        public float far;

        public Range(float near, float far)
        {
            this.near = near;
            this.far = far;
        }

        public override bool Equals(object obj)
        {
            return obj is Range range &&
                   near == range.near &&
                   far == range.far;
        }

        public override int GetHashCode()
        {
            int hashCode = -1227618731;
            hashCode = hashCode * -1521134295 + near.GetHashCode();
            hashCode = hashCode * -1521134295 + far.GetHashCode();
            return hashCode;
        }
    }
}
