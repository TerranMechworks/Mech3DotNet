using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class IntervalTypeConverter : EnumConverter<IntervalType>
    {
        public override IntervalType ReadVariant(string? name) => name switch
        {
            "Unset" => IntervalType.Unset,
            "Time" => IntervalType.Time,
            "Distance" => IntervalType.Distance,
            null => DebugAndThrow("Variant cannot be null for 'IntervalType'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'IntervalType'"),
        };

        public override string WriteVariant(IntervalType value) => value switch
        {
            IntervalType.Unset => "Unset",
            IntervalType.Time => "Time",
            IntervalType.Distance => "Distance",
            _ => throw new ArgumentOutOfRangeException("IntervalType"),
        };
    }
}
