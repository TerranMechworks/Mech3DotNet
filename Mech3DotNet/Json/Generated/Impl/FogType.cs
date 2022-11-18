namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.FogTypeConverter))]
    public enum FogType
    {
        Off,
        Linear,
        Exponential,
    }
}
