using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(FogStateConverter))]
    public class FogState
    {
        public string name;
        public FogType fogType;
        public Color color;
        public Range altitude;
        public Range range;

        public FogState(string name, FogType fogType, Color color, Range altitude, Range range)
        {
            this.name = name;
            this.fogType = fogType;
            this.color = color;
            this.altitude = altitude;
            this.range = range;
        }
    }
}
