namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.SoundConverter))]
    public class Sound
    {
        public string name;
        public AtNode atNode;

        public Sound(string name, AtNode atNode)
        {
            this.name = name;
            this.atNode = atNode;
        }
    }
}
