namespace Mech3DotNet.Json.Image
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Image.Converters.TextureAlphaConverter))]
    public enum TextureAlpha
    {
        None,
        Simple,
        Full,
    }
}
