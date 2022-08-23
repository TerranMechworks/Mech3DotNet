using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(RandomWeightCondConverter))]
    public struct RandomWeightCond
    {
        public float value;

        public RandomWeightCond(float value)
        {
            this.value = value;
        }
    }
}
