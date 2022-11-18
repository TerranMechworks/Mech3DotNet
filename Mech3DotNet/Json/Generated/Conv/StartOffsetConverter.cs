namespace Mech3DotNet.Json.Converters
{
    public class StartOffsetConverter : Mech3DotNet.Json.Converters.EnumConverter<StartOffset>
    {
        public override StartOffset ReadVariant(string? name) => name switch
        {
            "Animation" => StartOffset.Animation,
            "Sequence" => StartOffset.Sequence,
            "Event" => StartOffset.Event,
            null => DebugAndThrow("Variant cannot be null for 'StartOffset'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'StartOffset'"),
        };

        public override string WriteVariant(StartOffset value) => value switch
        {
            StartOffset.Animation => "Animation",
            StartOffset.Sequence => "Sequence",
            StartOffset.Event => "Event",
            _ => throw new System.ArgumentOutOfRangeException("StartOffset"),
        };
    }
}
