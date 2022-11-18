namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.FloatFromToConverter))]
    public class FloatFromTo
    {
        public float from;
        public float to;
        public float delta;

        public FloatFromTo(float from, float to, float delta)
        {
            this.from = from;
            this.to = to;
            this.delta = delta;
        }
    }
}
