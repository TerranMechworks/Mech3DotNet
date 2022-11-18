namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class StartOffsetConverter : Mech3DotNet.Json.Converters.EnumConverter<Mech3DotNet.Json.Anim.Events.StartOffset>
    {
        public override Mech3DotNet.Json.Anim.Events.StartOffset ReadVariant(string? name) => name switch
        {
            "Animation" => Mech3DotNet.Json.Anim.Events.StartOffset.Animation,
            "Sequence" => Mech3DotNet.Json.Anim.Events.StartOffset.Sequence,
            "Event" => Mech3DotNet.Json.Anim.Events.StartOffset.Event,
            null => DebugAndThrow("Variant cannot be null for 'StartOffset'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'StartOffset'"),
        };

        public override string WriteVariant(Mech3DotNet.Json.Anim.Events.StartOffset value) => value switch
        {
            Mech3DotNet.Json.Anim.Events.StartOffset.Animation => "Animation",
            Mech3DotNet.Json.Anim.Events.StartOffset.Sequence => "Sequence",
            Mech3DotNet.Json.Anim.Events.StartOffset.Event => "Event",
            _ => throw new System.ArgumentOutOfRangeException("StartOffset"),
        };
    }
}
