using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(XyzRotationConverter))]
    public class XyzRotation
    {
        public Vec3 value;
        public Vec3 unk;

        public XyzRotation(Vec3 value, Vec3 unk)
        {
            this.value = value;
            this.unk = unk;
        }
    }
}
