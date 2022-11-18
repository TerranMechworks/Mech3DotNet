namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.GravityConverter))]
    public struct Gravity
    {
        public Mech3DotNet.Json.Anim.Events.GravityMode mode;
        public float value;

        public Gravity(Mech3DotNet.Json.Anim.Events.GravityMode mode, float value)
        {
            this.mode = mode;
            this.value = value;
        }
    }
}
