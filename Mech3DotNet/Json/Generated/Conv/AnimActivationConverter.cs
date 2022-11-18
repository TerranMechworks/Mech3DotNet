namespace Mech3DotNet.Json.Anim.Converters
{
    public class AnimActivationConverter : Mech3DotNet.Json.Converters.EnumConverter<Mech3DotNet.Json.Anim.AnimActivation>
    {
        public override Mech3DotNet.Json.Anim.AnimActivation ReadVariant(string? name) => name switch
        {
            "WeaponHit" => Mech3DotNet.Json.Anim.AnimActivation.WeaponHit,
            "CollideHit" => Mech3DotNet.Json.Anim.AnimActivation.CollideHit,
            "WeaponOrCollideHit" => Mech3DotNet.Json.Anim.AnimActivation.WeaponOrCollideHit,
            "OnCall" => Mech3DotNet.Json.Anim.AnimActivation.OnCall,
            "OnStartup" => Mech3DotNet.Json.Anim.AnimActivation.OnStartup,
            null => DebugAndThrow("Variant cannot be null for 'AnimActivation'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'AnimActivation'"),
        };

        public override string WriteVariant(Mech3DotNet.Json.Anim.AnimActivation value) => value switch
        {
            Mech3DotNet.Json.Anim.AnimActivation.WeaponHit => "WeaponHit",
            Mech3DotNet.Json.Anim.AnimActivation.CollideHit => "CollideHit",
            Mech3DotNet.Json.Anim.AnimActivation.WeaponOrCollideHit => "WeaponOrCollideHit",
            Mech3DotNet.Json.Anim.AnimActivation.OnCall => "OnCall",
            Mech3DotNet.Json.Anim.AnimActivation.OnStartup => "OnStartup",
            _ => throw new System.ArgumentOutOfRangeException("AnimActivation"),
        };
    }
}
