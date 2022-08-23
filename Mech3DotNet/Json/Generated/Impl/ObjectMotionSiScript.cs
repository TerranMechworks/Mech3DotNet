using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectMotionSiScriptConverter))]
    public class ObjectMotionSiScript
    {
        public string node;
        public List<ObjectMotionSiFrame> frames;

        public ObjectMotionSiScript(string node, List<ObjectMotionSiFrame> frames)
        {
            this.node = node;
            this.frames = frames;
        }
    }
}
