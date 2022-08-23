using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(PrereqObjectConverter))]
    public struct PrereqObject
    {
        public string name;
        public bool required;
        public bool active;
        public uint pointer;

        public PrereqObject(string name, bool required, bool active, uint pointer)
        {
            this.name = name;
            this.required = required;
            this.active = active;
            this.pointer = pointer;
        }
    }
}
