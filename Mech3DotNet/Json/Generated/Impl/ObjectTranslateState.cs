using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectTranslateStateConverter))]
    public class ObjectTranslateState
    {
        public string node;
        public Vec3 translate;
        public string? atNode = null;

        public ObjectTranslateState(string node, Vec3 translate, string? atNode)
        {
            this.node = node;
            this.translate = translate;
            this.atNode = atNode;
        }
    }
}
