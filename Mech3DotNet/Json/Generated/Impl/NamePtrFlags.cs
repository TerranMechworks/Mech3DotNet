namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.NamePtrFlagsConverter))]
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
