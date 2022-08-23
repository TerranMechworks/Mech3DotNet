using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class FogTypeConverter : EnumConverter<FogType>
    {
        public override FogType ReadVariant(string? name) => name switch
        {
            "Off" => FogType.Off,
            "Linear" => FogType.Linear,
            "Exponential" => FogType.Exponential,
            null => DebugAndThrow("Variant cannot be null for 'FogType'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'FogType'"),
        };

        public override string WriteVariant(FogType value) => value switch
        {
            FogType.Off => "Off",
            FogType.Linear => "Linear",
            FogType.Exponential => "Exponential",
            _ => throw new ArgumentOutOfRangeException("FogType"),
        };
    }
}
