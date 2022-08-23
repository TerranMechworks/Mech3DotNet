using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(NamePtrFlagsConverter))]
    public struct NamePtrFlags
    {
        public string name;
        public uint pointer;
        public uint flags;

        public NamePtrFlags(string name, uint pointer, uint flags)
        {
            this.name = name;
            this.pointer = pointer;
            this.flags = flags;
        }
    }
}
