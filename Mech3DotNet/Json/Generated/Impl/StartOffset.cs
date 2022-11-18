namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.StartOffsetConverter))]
    public enum StartOffset
    {
        Animation,
        Sequence,
        Event,
    }
}
