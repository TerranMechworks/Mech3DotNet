namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.GravityModeConverter))]
    public enum GravityMode
    {
        Local,
        Complex,
        NoAltitude,
    }
}
