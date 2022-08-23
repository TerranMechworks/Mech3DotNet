using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(IntervalTypeConverter))]
    public enum IntervalType
    {
        Unset,
        Time,
        Distance,
    }
}
