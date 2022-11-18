namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.GravityModeConverter))]
    public enum GravityMode
    {
        Local,
        Complex,
        NoAltitude,
    }
}
