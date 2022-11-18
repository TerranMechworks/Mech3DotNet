namespace Mech3DotNet.Json.Converters
{
    public class SeqActivationConverter : Mech3DotNet.Json.Converters.EnumConverter<SeqActivation>
    {
        public override SeqActivation ReadVariant(string? name) => name switch
        {
            "Initial" => SeqActivation.Initial,
            "OnCall" => SeqActivation.OnCall,
            null => DebugAndThrow("Variant cannot be null for 'SeqActivation'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'SeqActivation'"),
        };

        public override string WriteVariant(SeqActivation value) => value switch
        {
            SeqActivation.Initial => "Initial",
            SeqActivation.OnCall => "OnCall",
            _ => throw new System.ArgumentOutOfRangeException("SeqActivation"),
        };
    }
}
