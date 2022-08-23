using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(Vec3FromToConverter))]
    public class Vec3FromTo
    {
        public Vec3 from;
        public Vec3 to;
        public Vec3 delta;

        public Vec3FromTo(Vec3 from, Vec3 to, Vec3 delta)
        {
            this.from = from;
            this.to = to;
            this.delta = delta;
        }
    }
}
