namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.FogTypeConverter))]
    public enum FogType
    {
        Off,
        Linear,
        Exponential,
    }
}
