namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.IntervalTypeConverter))]
    public enum IntervalType
    {
        Unset,
        Time,
        Distance,
    }
}
