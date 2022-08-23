using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(IntervalConverter))]
    public class Interval
    {
        public IntervalType intervalType;
        public float intervalValue;
        public bool flag;

        public Interval(IntervalType intervalType, float intervalValue, bool flag)
        {
            this.intervalType = intervalType;
            this.intervalValue = intervalValue;
            this.flag = flag;
        }
    }
}
