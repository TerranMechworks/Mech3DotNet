using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(MapRcConverter))]
    public class MapRc
    {
        public uint unk04;
        public float maxX;
        public float maxY;
        public List<MapFeature> features;

        public MapRc(uint unk04, float maxX, float maxY, List<MapFeature> features)
        {
            this.unk04 = unk04;
            this.maxX = maxX;
            this.maxY = maxY;
            this.features = features;
        }
    }
}
