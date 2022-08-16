using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class TextureAlphaConverter : EnumConverter<TextureAlpha>
    {
        public override TextureAlpha ReadVariant(string? name) => name switch
        {
            "None" => TextureAlpha.None,
            "Simple" => TextureAlpha.Simple,
            "Full" => TextureAlpha.Full,
            null => DebugAndThrow("Variant cannot be null for 'TextureAlpha'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'TextureAlpha'"),
        };

        public override string WriteVariant(TextureAlpha value) => value switch
        {
            TextureAlpha.None => "None",
            TextureAlpha.Simple => "Simple",
            TextureAlpha.Full => "Full",
            _ => throw new ArgumentOutOfRangeException("TextureAlpha"),
        };
    }
}