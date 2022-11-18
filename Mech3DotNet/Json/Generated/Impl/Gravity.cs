namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.GravityConverter))]
    public struct Gravity
    {
        public GravityMode mode;
        public float value;

        public Gravity(GravityMode mode, float value)
        {
            this.mode = mode;
            this.value = value;
        }
    }
}
