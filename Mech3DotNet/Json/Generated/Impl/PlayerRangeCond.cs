namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.PlayerRangeCondConverter))]
    public struct PlayerRangeCond
    {
        public float value;

        public PlayerRangeCond(float value)
        {
            this.value = value;
        }
    }
}
