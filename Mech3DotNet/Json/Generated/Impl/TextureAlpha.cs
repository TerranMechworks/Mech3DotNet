namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.TextureAlphaConverter))]
    public enum TextureAlpha
    {
        None,
        Simple,
        Full,
    }
}
