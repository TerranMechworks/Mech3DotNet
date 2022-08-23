using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(NamePadConverter))]
    public struct NamePad
    {
        public string name;
        public byte[] pad;

        public NamePad(string name, byte[] pad)
        {
            this.name = name;
            this.pad = pad;
        }
    }
}
