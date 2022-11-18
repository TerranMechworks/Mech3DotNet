namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class GravityModeConverter : Mech3DotNet.Json.Converters.EnumConverter<Mech3DotNet.Json.Anim.Events.GravityMode>
    {
        public override Mech3DotNet.Json.Anim.Events.GravityMode ReadVariant(string? name) => name switch
        {
            "Local" => Mech3DotNet.Json.Anim.Events.GravityMode.Local,
            "Complex" => Mech3DotNet.Json.Anim.Events.GravityMode.Complex,
            "NoAltitude" => Mech3DotNet.Json.Anim.Events.GravityMode.NoAltitude,
            null => DebugAndThrow("Variant cannot be null for 'GravityMode'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'GravityMode'"),
        };

        public override string WriteVariant(Mech3DotNet.Json.Anim.Events.GravityMode value) => value switch
        {
            Mech3DotNet.Json.Anim.Events.GravityMode.Local => "Local",
            Mech3DotNet.Json.Anim.Events.GravityMode.Complex => "Complex",
            Mech3DotNet.Json.Anim.Events.GravityMode.NoAltitude => "NoAltitude",
            _ => throw new System.ArgumentOutOfRangeException("GravityMode"),
        };
    }
}
