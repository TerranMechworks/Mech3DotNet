namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.AnimNameConverter))]
    public class AnimName
    {
        public string name;
        public byte[] pad;
        public uint unknown;

        public AnimName(string name, byte[] pad, uint unknown)
        {
            this.name = name;
            this.pad = pad;
            this.unknown = unknown;
        }
    }
}
