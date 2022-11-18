namespace Mech3DotNet.Json.Image.Converters
{
    public class TextureAlphaConverter : Mech3DotNet.Json.Converters.EnumConverter<Mech3DotNet.Json.Image.TextureAlpha>
    {
        public override Mech3DotNet.Json.Image.TextureAlpha ReadVariant(string? name) => name switch
        {
            "None" => Mech3DotNet.Json.Image.TextureAlpha.None,
            "Simple" => Mech3DotNet.Json.Image.TextureAlpha.Simple,
            "Full" => Mech3DotNet.Json.Image.TextureAlpha.Full,
            null => DebugAndThrow("Variant cannot be null for 'TextureAlpha'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'TextureAlpha'"),
        };

        public override string WriteVariant(Mech3DotNet.Json.Image.TextureAlpha value) => value switch
        {
            Mech3DotNet.Json.Image.TextureAlpha.None => "None",
            Mech3DotNet.Json.Image.TextureAlpha.Simple => "Simple",
            Mech3DotNet.Json.Image.TextureAlpha.Full => "Full",
            _ => throw new System.ArgumentOutOfRangeException("TextureAlpha"),
        };
    }
}
