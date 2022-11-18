namespace Mech3DotNet.Json.Image.Converters
{
    public class TextureStretchConverter : Mech3DotNet.Json.Converters.EnumConverter<Mech3DotNet.Json.Image.TextureStretch>
    {
        public override Mech3DotNet.Json.Image.TextureStretch ReadVariant(string? name) => name switch
        {
            "None" => Mech3DotNet.Json.Image.TextureStretch.None,
            "Vertical" => Mech3DotNet.Json.Image.TextureStretch.Vertical,
            "Horizontal" => Mech3DotNet.Json.Image.TextureStretch.Horizontal,
            "Both" => Mech3DotNet.Json.Image.TextureStretch.Both,
            "Unk4" => Mech3DotNet.Json.Image.TextureStretch.Unk4,
            "Unk7" => Mech3DotNet.Json.Image.TextureStretch.Unk7,
            "Unk8" => Mech3DotNet.Json.Image.TextureStretch.Unk8,
            null => DebugAndThrow("Variant cannot be null for 'TextureStretch'"),
            _ => DebugAndThrow($"Invalid variant '{name}' for 'TextureStretch'"),
        };

        public override string WriteVariant(Mech3DotNet.Json.Image.TextureStretch value) => value switch
        {
            Mech3DotNet.Json.Image.TextureStretch.None => "None",
            Mech3DotNet.Json.Image.TextureStretch.Vertical => "Vertical",
            Mech3DotNet.Json.Image.TextureStretch.Horizontal => "Horizontal",
            Mech3DotNet.Json.Image.TextureStretch.Both => "Both",
            Mech3DotNet.Json.Image.TextureStretch.Unk4 => "Unk4",
            Mech3DotNet.Json.Image.TextureStretch.Unk7 => "Unk7",
            Mech3DotNet.Json.Image.TextureStretch.Unk8 => "Unk8",
            _ => throw new System.ArgumentOutOfRangeException("TextureStretch"),
        };
    }
}
