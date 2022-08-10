using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class NodeFlags
    {
        [JsonProperty("altitude_surface", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool altitudeSurface;
        [JsonProperty("intersect_surface", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool intersectSurface;
        [JsonProperty("intersect_bbox", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool intersectBbox;
        [JsonProperty("landmark", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool landmark;
        [JsonProperty("unk08", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool unk08;
        [JsonProperty("has_mesh", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool hasMesh;
        [JsonProperty("unk10", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool unk10;
        [JsonProperty("terrain", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool terrain;
        [JsonProperty("can_modify", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool canModify;
        [JsonProperty("clip_to", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool clipTo;
        [JsonProperty("unk25", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool unk25;
        [JsonProperty("unk28", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool unk28;

        public NodeFlags(bool altitudeSurface, bool intersectSurface, bool intersectBbox, bool landmark, bool unk08, bool hasMesh, bool unk10, bool terrain, bool canModify, bool clipTo, bool unk25, bool unk28)
        {
            this.altitudeSurface = altitudeSurface;
            this.intersectSurface = intersectSurface;
            this.intersectBbox = intersectBbox;
            this.landmark = landmark;
            this.unk08 = unk08;
            this.hasMesh = hasMesh;
            this.unk10 = unk10;
            this.terrain = terrain;
            this.canModify = canModify;
            this.clipTo = clipTo;
            this.unk25 = unk25;
            this.unk28 = unk28;
        }

        [JsonConstructor]
        private NodeFlags() { }
    }
}
