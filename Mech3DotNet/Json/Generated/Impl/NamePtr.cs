namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.NamePtrConverter))]
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
