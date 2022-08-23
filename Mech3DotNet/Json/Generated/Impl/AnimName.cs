using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(AnimNameConverter))]
    public class AnimName
    {
        public string name;
        public byte[] pad;
        public uint unknown;

        public AnimName(string name, byte[] pad, uint unknown)
        {
            this.name = name;
            this.pad = pad;
            this.unknown = unknown;
        }
    }
}
