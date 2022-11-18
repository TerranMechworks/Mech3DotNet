namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.StopSequenceConverter))]
    public class StopSequence
    {
        public string name;

        public StopSequence(string name)
        {
            this.name = name;
        }
    }
}
