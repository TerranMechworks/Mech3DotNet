using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class AnimActivationConverter : EnumConverter<AnimActivation>
    {
        public override AnimActivation ReadVariant(string? name) => name switch
        {
            "WeaponHit" => AnimActivation.WeaponHit,
            "CollideHit" => AnimActivation.CollideHit,
            "WeaponOrCollideHit" => AnimActivation.WeaponOrCollideHit,
            "OnCall" => AnimActivation.OnCall,
            "OnStartup" => AnimActivation.OnStartup,
            null => DebugAndThrow("Variant cannot be null for 'AnimActivation'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'AnimActivation'"),
        };

        public override string WriteVariant(AnimActivation value) => value switch
        {
            AnimActivation.WeaponHit => "WeaponHit",
            AnimActivation.CollideHit => "CollideHit",
            AnimActivation.WeaponOrCollideHit => "WeaponOrCollideHit",
            AnimActivation.OnCall => "OnCall",
            AnimActivation.OnStartup => "OnStartup",
            _ => throw new ArgumentOutOfRangeException("AnimActivation"),
        };
    }
}
