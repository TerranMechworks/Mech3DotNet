namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.IntervalTypeConverter))]
    public enum IntervalType
    {
        Unset,
        Time,
        Distance,
    }
}
