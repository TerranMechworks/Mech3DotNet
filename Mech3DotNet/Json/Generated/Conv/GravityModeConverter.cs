using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class GravityModeConverter : EnumConverter<GravityMode>
    {
        public override GravityMode ReadVariant(string? name) => name switch
        {
            "Local" => GravityMode.Local,
            "Complex" => GravityMode.Complex,
            "NoAltitude" => GravityMode.NoAltitude,
            null => DebugAndThrow("Variant cannot be null for 'GravityMode'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'GravityMode'"),
        };

        public override string WriteVariant(GravityMode value) => value switch
        {
            GravityMode.Local => "Local",
            GravityMode.Complex => "Complex",
            GravityMode.NoAltitude => "NoAltitude",
            _ => throw new ArgumentOutOfRangeException("GravityMode"),
        };
    }
}
