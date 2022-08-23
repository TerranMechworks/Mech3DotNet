using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectOpacityConverter))]
    public struct ObjectOpacity
    {
        public float value;
        public short state;

        public ObjectOpacity(float value, short state)
        {
            this.value = value;
            this.state = state;
        }
    }
}
