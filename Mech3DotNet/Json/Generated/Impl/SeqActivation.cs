namespace Mech3DotNet.Json.Anim
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Converters.SeqActivationConverter))]
    public enum SeqActivation
    {
        Initial,
        OnCall,
    }
}
