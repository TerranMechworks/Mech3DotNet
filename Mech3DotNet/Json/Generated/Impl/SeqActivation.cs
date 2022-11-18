namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.SeqActivationConverter))]
    public enum SeqActivation
    {
        Initial,
        OnCall,
    }
}
