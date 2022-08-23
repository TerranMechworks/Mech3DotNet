using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(FogTypeConverter))]
    public enum FogType
    {
        Off,
        Linear,
        Exponential,
    }
}
