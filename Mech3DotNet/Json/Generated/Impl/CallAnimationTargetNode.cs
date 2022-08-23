using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(CallAnimationTargetNodeConverter))]
    public class CallAnimationTargetNode
    {
        public string operandNode;

        public CallAnimationTargetNode(string operandNode)
        {
            this.operandNode = operandNode;
        }
    }
}
