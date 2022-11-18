namespace Mech3DotNet.Json.Types
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Types.Converters.RangeConverter))]
    public struct Range
    {
        public float min;
        public float max;

        public Range(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    }
}
