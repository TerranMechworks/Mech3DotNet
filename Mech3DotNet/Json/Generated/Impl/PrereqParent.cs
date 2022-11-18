namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.PrereqParentConverter))]
    public struct PrereqParent
    {
        public string name;
        public bool required;
        public bool active;
        public uint pointer;

        public PrereqParent(string name, bool required, bool active, uint pointer)
        {
            this.name = name;
            this.required = required;
            this.active = active;
            this.pointer = pointer;
        }
    }
}
