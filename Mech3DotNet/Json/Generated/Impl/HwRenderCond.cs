using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(HwRenderCondConverter))]
    public struct HwRenderCond
    {
        public bool value;

        public HwRenderCond(bool value)
        {
            this.value = value;
        }
    }
}
