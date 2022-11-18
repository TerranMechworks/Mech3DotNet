namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.PlayerRangeCondConverter))]
    public struct PlayerRangeCond
    {
        public float value;

        public PlayerRangeCond(float value)
        {
            this.value = value;
        }
    }
}
