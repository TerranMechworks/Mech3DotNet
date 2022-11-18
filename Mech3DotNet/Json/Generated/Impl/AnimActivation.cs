namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.AnimActivationConverter))]
    public enum AnimActivation
    {
        WeaponHit,
        CollideHit,
        WeaponOrCollideHit,
        OnCall,
        OnStartup,
    }
}
