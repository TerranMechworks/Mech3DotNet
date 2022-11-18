namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class FogTypeConverter : Mech3DotNet.Json.Converters.EnumConverter<Mech3DotNet.Json.Anim.Events.FogType>
    {
        public override Mech3DotNet.Json.Anim.Events.FogType ReadVariant(string? name) => name switch
        {
            "Off" => Mech3DotNet.Json.Anim.Events.FogType.Off,
            "Linear" => Mech3DotNet.Json.Anim.Events.FogType.Linear,
            "Exponential" => Mech3DotNet.Json.Anim.Events.FogType.Exponential,
            null => DebugAndThrow("Variant cannot be null for 'FogType'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'FogType'"),
        };

        public override string WriteVariant(Mech3DotNet.Json.Anim.Events.FogType value) => value switch
        {
            Mech3DotNet.Json.Anim.Events.FogType.Off => "Off",
            Mech3DotNet.Json.Anim.Events.FogType.Linear => "Linear",
            Mech3DotNet.Json.Anim.Events.FogType.Exponential => "Exponential",
            _ => throw new System.ArgumentOutOfRangeException("FogType"),
        };
    }
}
