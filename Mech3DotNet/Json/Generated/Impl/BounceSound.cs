namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.BounceSoundConverter))]
    public class BounceSound
    {
        public string name;
        public float volume;

        public BounceSound(string name, float volume)
        {
            this.name = name;
            this.volume = volume;
        }
    }
}
