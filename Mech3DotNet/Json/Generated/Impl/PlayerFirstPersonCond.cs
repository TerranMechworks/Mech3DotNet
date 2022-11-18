namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.PlayerFirstPersonCondConverter))]
    public struct PlayerFirstPersonCond
    {
        public bool value;

        public PlayerFirstPersonCond(bool value)
        {
            this.value = value;
        }
    }
}
