using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(NodeFlagsConverter))]
    public class NodeFlags
    {
        public bool altitudeSurface = false;
        public bool intersectSurface = false;
        public bool intersectBbox = false;
        public bool landmark = false;
        public bool unk08 = false;
        public bool hasMesh = false;
        public bool unk10 = false;
        public bool terrain = false;
        public bool canModify = false;
        public bool clipTo = false;
        public bool unk25 = false;
        public bool unk28 = false;

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
    }
}
