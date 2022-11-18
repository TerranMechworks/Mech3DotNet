namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.StartOffsetConverter))]
    public enum StartOffset
    {
        Animation,
        Sequence,
        Event,
    }
}
