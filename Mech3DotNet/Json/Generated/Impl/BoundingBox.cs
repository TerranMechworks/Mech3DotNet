using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(BoundingBoxConverter))]
    public class BoundingBox
    {
        public Vec3 a;
        public Vec3 b;

        public BoundingBox(Vec3 a, Vec3 b)
        {
            this.a = a;
            this.b = b;
        }
    }
}
