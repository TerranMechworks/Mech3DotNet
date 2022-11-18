using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(MapFeatureConverter))]
    public class MapFeature
    {
        public MapColor color;
        public List<MapVertex> vertices;
        public int objective;

        public MapFeature(MapColor color, List<MapVertex> vertices, int objective)
        {
            this.color = color;
            this.vertices = vertices;
            this.objective = objective;
        }
    }
}
