namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.PlayerFirstPersonCondConverter))]
    public struct PlayerFirstPersonCond
    {
        public bool value;

        public PlayerFirstPersonCond(bool value)
        {
            this.value = value;
        }
    }
}
