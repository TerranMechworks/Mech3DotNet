using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(NamePtrConverter))]
    public struct NamePtr
    {
        public string name;
        public uint pointer;

        public NamePtr(string name, uint pointer)
        {
            this.name = name;
            this.pointer = pointer;
        }
    }
}
