namespace Mech3DotNet.Json.Anim
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Converters.NamePadConverter))]
    public struct NamePad
    {
        public string name;
        public byte[] pad;

        public NamePad(string name, byte[] pad)
        {
            this.name = name;
            this.pad = pad;
        }
    }
}
