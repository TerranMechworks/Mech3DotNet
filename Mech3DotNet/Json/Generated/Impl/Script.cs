namespace Mech3DotNet.Json.Interp
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Interp.Converters.ScriptConverter))]
    public class Script
    {
        public string name;
        public System.DateTime lastModified;
        public System.Collections.Generic.List<string> lines;

        public Script(string name, System.DateTime lastModified, System.Collections.Generic.List<string> lines)
        {
            this.name = name;
            this.lastModified = lastModified;
            this.lines = lines;
        }
    }
}
