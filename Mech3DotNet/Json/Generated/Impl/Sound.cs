namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.SoundConverter))]
    public class Sound
    {
        public string name;
        public Mech3DotNet.Json.Anim.Events.AtNode atNode;

        public Sound(string name, Mech3DotNet.Json.Anim.Events.AtNode atNode)
        {
            this.name = name;
            this.atNode = atNode;
        }
    }
}
