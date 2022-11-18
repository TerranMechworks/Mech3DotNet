namespace Mech3DotNet.Json.Anim.Converters
{
    public class SeqActivationConverter : Mech3DotNet.Json.Converters.EnumConverter<Mech3DotNet.Json.Anim.SeqActivation>
    {
        public override Mech3DotNet.Json.Anim.SeqActivation ReadVariant(string? name) => name switch
        {
            "Initial" => Mech3DotNet.Json.Anim.SeqActivation.Initial,
            "OnCall" => Mech3DotNet.Json.Anim.SeqActivation.OnCall,
            null => DebugAndThrow("Variant cannot be null for 'SeqActivation'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'SeqActivation'"),
        };

        public override string WriteVariant(Mech3DotNet.Json.Anim.SeqActivation value) => value switch
        {
            Mech3DotNet.Json.Anim.SeqActivation.Initial => "Initial",
            Mech3DotNet.Json.Anim.SeqActivation.OnCall => "OnCall",
            _ => throw new System.ArgumentOutOfRangeException("SeqActivation"),
        };
    }
}
