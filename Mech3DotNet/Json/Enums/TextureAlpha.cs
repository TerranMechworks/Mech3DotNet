using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TextureAlpha
    {
        None,
        Simple,
        Full,
    }
}
