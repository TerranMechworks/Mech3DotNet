using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class SeqActivationConverter : EnumConverter<SeqActivation>
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
            _ => throw new ArgumentOutOfRangeException("SeqActivation"),
        };
    }
}
