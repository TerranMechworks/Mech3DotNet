using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TextureStretchConverter))]
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
