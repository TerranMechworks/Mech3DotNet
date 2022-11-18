namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class IntervalTypeConverter : Mech3DotNet.Json.Converters.EnumConverter<Mech3DotNet.Json.Anim.Events.IntervalType>
    {
        public override Mech3DotNet.Json.Anim.Events.IntervalType ReadVariant(string? name) => name switch
        {
            "Unset" => Mech3DotNet.Json.Anim.Events.IntervalType.Unset,
            "Time" => Mech3DotNet.Json.Anim.Events.IntervalType.Time,
            "Distance" => Mech3DotNet.Json.Anim.Events.IntervalType.Distance,
            null => DebugAndThrow("Variant cannot be null for 'IntervalType'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'IntervalType'"),
        };

        public override string WriteVariant(Mech3DotNet.Json.Anim.Events.IntervalType value) => value switch
        {
            Mech3DotNet.Json.Anim.Events.IntervalType.Unset => "Unset",
            Mech3DotNet.Json.Anim.Events.IntervalType.Time => "Time",
            Mech3DotNet.Json.Anim.Events.IntervalType.Distance => "Distance",
            _ => throw new System.ArgumentOutOfRangeException("IntervalType"),
        };
    }
}
