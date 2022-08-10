using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ScriptConverter))]
    public class Script
    {
        public string name;
        public DateTime lastModified;
        public List<string> lines;

        public Script(string name, DateTime lastModified, List<string> lines)
        {
            this.name = name;
            this.lastModified = lastModified;
            this.lines = lines;
        }
    }
}
