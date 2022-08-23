using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(CallObjectConnectorConverter))]
    public class CallObjectConnector
    {
        public string node;
        public string fromNode;
        public string toNode;
        public Vec3 toPos;

        public CallObjectConnector(string node, string fromNode, string toNode, Vec3 toPos)
        {
            this.node = node;
            this.fromNode = fromNode;
            this.toNode = toNode;
            this.toPos = toPos;
        }
    }
}
