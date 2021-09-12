using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mech3DotNet.Json
{
    public class InterpreterScript
    {
        [JsonProperty("name", Required = Required.Always)]
        public string name;
        [JsonProperty("last_modified", Required = Required.Always)]
        public DateTime lastModified;
        [JsonProperty("lines", Required = Required.Always)]
        public List<string> lines;

        public InterpreterScript(string name, DateTime lastModified, List<string> lines)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.lastModified = lastModified;
            this.lines = lines ?? throw new ArgumentNullException(nameof(lines));
        }

        [JsonConstructor]
        private InterpreterScript() { }
    }
}
