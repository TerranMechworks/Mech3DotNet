namespace Mech3DotNet.Json.Anim
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Converters.AnimNameConverter))]
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
