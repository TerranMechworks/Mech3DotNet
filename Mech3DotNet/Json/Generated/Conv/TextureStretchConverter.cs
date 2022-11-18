using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class TextureStretchConverter : EnumConverter<TextureStretch>
    {
        public override TextureStretch ReadVariant(string? name) => name switch
        {
            "None" => TextureStretch.None,
            "Vertical" => TextureStretch.Vertical,
            "Horizontal" => TextureStretch.Horizontal,
            "Both" => TextureStretch.Both,
            "Unk4" => TextureStretch.Unk4,
            "Unk7" => TextureStretch.Unk7,
            "Unk8" => TextureStretch.Unk8,
            null => DebugAndThrow("Variant cannot be null for 'TextureStretch'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'TextureStretch'"),
        };

        public override string WriteVariant(TextureStretch value) => value switch
        {
            TextureStretch.None => "None",
            TextureStretch.Vertical => "Vertical",
            TextureStretch.Horizontal => "Horizontal",
            TextureStretch.Both => "Both",
            TextureStretch.Unk4 => "Unk4",
            TextureStretch.Unk7 => "Unk7",
            TextureStretch.Unk8 => "Unk8",
            _ => throw new ArgumentOutOfRangeException("TextureStretch"),
        };
    }
}
