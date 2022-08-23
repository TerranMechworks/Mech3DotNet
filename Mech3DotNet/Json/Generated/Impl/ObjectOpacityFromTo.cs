using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectOpacityFromToConverter))]
    public class ObjectOpacityFromTo
    {
        public string node;
        public ObjectOpacity opacityFrom;
        public ObjectOpacity opacityTo;
        public float runtime;
        public bool fudge = false;

        public ObjectOpacityFromTo(string node, ObjectOpacity opacityFrom, ObjectOpacity opacityTo, float runtime, bool fudge)
        {
            this.node = node;
            this.opacityFrom = opacityFrom;
            this.opacityTo = opacityTo;
            this.runtime = runtime;
            this.fudge = fudge;
        }
    }
}
