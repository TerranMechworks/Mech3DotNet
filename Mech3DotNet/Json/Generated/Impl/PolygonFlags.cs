using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(PolygonFlagsConverter))]
    public class PolygonFlags
    {
        public bool unk2 = false;
        public bool unk3 = false;
        public bool triangleStrip = false;
        public bool unk6 = false;

        public PolygonFlags(bool unk2, bool unk3, bool triangleStrip, bool unk6)
        {
            this.unk2 = unk2;
            this.unk3 = unk3;
            this.triangleStrip = triangleStrip;
            this.unk6 = unk6;
        }
    }
}
