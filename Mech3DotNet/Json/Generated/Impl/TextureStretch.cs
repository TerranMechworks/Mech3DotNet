namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.TextureStretchConverter))]
    public enum TextureStretch
    {
        None,
        Vertical,
        Horizontal,
        Both,
        Unk4,
        Unk7,
        Unk8,
    }
}
