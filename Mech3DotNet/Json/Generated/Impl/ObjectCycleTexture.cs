using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectCycleTextureConverter))]
    public class ObjectCycleTexture
    {
        public string node;
        public ushort reset;

        public ObjectCycleTexture(string node, ushort reset)
        {
            this.node = node;
            this.reset = reset;
        }
    }
}
